using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class SuperEnemy : MonoBehaviour
{
    [Header("+-*/")] [SerializeField] public int skillNum; //スキル番号+-*/
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _kunai = default;
    [SerializeField] private Action[] _skill = new Action[5]; //スキルの関数を格納する配列
    [SerializeField] private const float _enemySpeed = 17.5f;
    private bool _isLeft = true;
    private bool _isKunai = default;
    private bool _isStayAttackState = default;
    private bool _isBack = default;
    private bool _isAttack = default;
    private int _randomPar = 33;

    Rigidbody2D _rigidbody2D;
    Rigidbody2D _kunaiRd;

    //制動用
    private float _speedX;//X軸のプレイヤーの速度の絶対値
    private float _speedY;//Y軸のプレイヤーの速度の絶対値
    private Transform _transform;//transformを取得
    private Vector3 _prevPosition;//前フレームの位置取得

    [Header("横移動減速速度")] [SerializeField] private float _decelerationSpeed = 200.0f;
    [Header("調整中・完全停止処理の基準")] [SerializeField] private float _stopMovePoint = 1f;//完全停止処理の基準　x軸だけでよろし？//名前訂正?

    private bool _isGround = false;
    [SerializeField] private LayerMask groundLayer;

    private float _jump = 550f;
    private float F = 1.5f;
    public int _jumpPar = 10;

    public enum EnemyState
    {
        Walk,
        Wait,
        Chase,
        Attack,
        Back
    };
    public void SkillSet()
    {
        _skill[0] = Stay;
        _skill[1] = KunaiThrow;
        _skill[3] = AttackState;
    }

    private void Start()
    {
        this.transform.eulerAngles = new Vector3(0, 0, 0);
        _kunai.SetActive(false);
        _kunaiRd = _kunai.GetComponent<Rigidbody2D>();
        _rigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();
        //関数の配列
        SkillSet();

        //ランダム関数のシード値を現在時刻を参照して変更
        UnityEngine.Random.InitState(DateTime.Now.Millisecond);
    }
    private void FixedUpdate()
    {
        _skill[skillNum]();
        Move();
        if (_isBack)
        {
            BackStep();
        }
        if (_isAttack)
        {
            Attack();
        }
    }
    private void Move()
    {
        Vector2 position = this.transform.position;

        // 前フレーム位置
        Vector2 delta = _prevPosition;

        // 前フレーム位置更新
        _prevPosition = position;
        float delX = position.x - delta.x;

        //プレイヤー速度
        _speedX = Mathf.Abs(this._rigidbody2D.velocity.x);
        _speedY = Mathf.Abs(this._rigidbody2D.velocity.y);

        //横移動減速
        if (_speedX > 0.1f)
        {
            this._rigidbody2D.AddForce(new Vector2(delX * -_decelerationSpeed, 0));
        }

        ////完全停止処理
        //if (_speedX + _speedY <= _stopMovePoint)
        //{
        //    _rigidbody2D.velocity = new Vector2(0, 0);
        //}

        //レイを発射（因数１；レイの始点、因数２；レイの向き、因数３；レイの距離、因数４；レイヤーマスク）
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, F, groundLayer);
        //着地判定処理
        if (hit)
        {
            _isGround = true;
        }
        else
        {
            _isGround = false;
        }
      
    }
    private void Stay()
    {

    }
    public async void AttackState()
    {
        if(!_isStayAttackState&&_isGround)
        {
           
            _isStayAttackState = true;
            // １から１００までの中からランダムに数字を選択する。
            int number = UnityEngine.Random.Range(1, 100);
             _jumpPar = UnityEngine.Random.Range(1, 100);

            // （出現率33％）
            if (number >= _randomPar)
            {
                _randomPar = _randomPar+15;
                
                if (_jumpPar <= 20)
                {
                    Jump();
                }
                //await UniTask.Delay(TimeSpan.FromSeconds(0.f));
                _isBack = true;
                await UniTask.Delay(TimeSpan.FromSeconds(2f));
                _isBack = false;
                await UniTask.Delay(TimeSpan.FromSeconds(1f));
            }
            // （出現率64％）
            else
            {
                _randomPar = 30;
                _isAttack = true;
                int attackNumber = UnityEngine.Random.Range(1,100);
                if(attackNumber<=43)
                {
                    _isKunai = true;
                    if (_jumpPar <= 15)
                    {
                        Jump();
                    }
                   
                    await UniTask.Delay(TimeSpan.FromSeconds(1.2f));
                    _isAttack = false;
                    await UniTask.Delay(TimeSpan.FromSeconds(0.5f));
                }
                else
                {
                    if (_jumpPar <= 15)
                     {
                        Jump();
                     }
                   
                    await UniTask.Delay(TimeSpan.FromSeconds(0.6f));
                    _isAttack = false;
                    await UniTask.Delay(TimeSpan.FromSeconds(0.25f));
                  
                }
            }
            _isStayAttackState = false;
        }
      
    }
    private void BackStep()
    {
        float playerPos = _player.transform.position.x;
        float X = this.transform.position.x;
       
        //プレイヤーの位置が自分より左にいるならプレイヤーから離れる
        if (playerPos < X)
        {
            //右 移動    
            _isLeft = false;
            this.transform.eulerAngles = new Vector3(0, 0, 0);
            _rigidbody2D.AddForce(Vector2.right * ((_enemySpeed - _rigidbody2D.velocity.x) * 5));
        }
        else
        {
            //左  移動     
            _isLeft = true;
            this.transform.eulerAngles = new Vector3(0, 180, 0);         
            _rigidbody2D.AddForce(Vector2.right * ((-_enemySpeed - _rigidbody2D.velocity.x) * 5));
        }
       
    }
    private void Attack()
    {
        float playerPos = _player.transform.position.x;
        float X = this.transform.position.x;
        //プレイヤーの位置が自分より左にいるならプレイヤーから離れる
        if (playerPos < X)
        {
            //左  移動     
            _isLeft = false;
            this.transform.eulerAngles = new Vector3(0, 0, 0);
            _rigidbody2D.AddForce(Vector2.right * ((-_enemySpeed - _rigidbody2D.velocity.x) * 3));

        }
        else
        {
            //右 移動    
            _isLeft = true;
            this.transform.eulerAngles = new Vector3(0, 180, 0);
            _rigidbody2D.AddForce(Vector2.right * ((_enemySpeed - _rigidbody2D.velocity.x) * 3));
        }
       
    }

    public void Jump()
    { 
       //ジャンプする
       if (_isGround)
       {
              this._rigidbody2D.AddForce(new Vector2(0f, _jump));
       }
    }
    public async void KunaiThrow()
    {
        //現在地にクナイを生成して指定時間後に消去する
        if (!_isKunai)
        {
            _isKunai = true;
            _kunai.SetActive(true);
            _kunai.transform.position = gameObject.transform.position;
            float time = 1.2f;
            //プレイヤーの向きによって射出方向を決定
            //右に飛ばすelseは左
            if (_isLeft)
            {
                _kunai.transform.eulerAngles = new Vector3(0, 180, 90);
                this._kunaiRd.AddForce(new Vector2(1300f, 0f));
            }
            else
            {
                _kunai.transform.eulerAngles = new Vector3(0, 0, 90);
                this._kunaiRd.AddForce(new Vector2(-1300f, 0f));
            }
            await UniTask.Delay(TimeSpan.FromSeconds(time));
            _isKunai = false;
            _kunai.SetActive(false);
        }
      
    }
 }
