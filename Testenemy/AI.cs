using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Cysharp.Threading.Tasks;

public class AI : MonoBehaviour
{

    //[SerializeField] private GameObject _player;
    //[SerializeField] private GameObject _enemy;
    //private Vector2 _playerPos = default;
    //private Vector2 _enemyPos = default;
    //[SerializeField] private int _enmeyHp = 500;
    //[SerializeField] private int _playerHp = 500;
    [SerializeField] private GameState _state;
    [SerializeField] private GameObject _player;
    private float _speed = 5f;
    private bool _isLeft = true;
    private float _distance = default;
  
    [Header("クナイを入れる")] [SerializeField] GameObject _kunai = null;
    [Header("近距離攻撃")] [SerializeField] GameObject _attack = null;

    private bool _isAttack = false;
    private bool _isRecedes = true;
    Rigidbody2D _kunaiRd;
    private bool _isKunai = false;
    private void Start()
    {
        _kunaiRd = _kunai.GetComponent<Rigidbody2D>();
        _kunai.SetActive(false);

        //ランダム関数のシード値を現在時刻を参照して変更
        UnityEngine.Random.InitState(DateTime.Now.Millisecond);
    }
    private void FixedUpdate()
    {
        string action = Evaluate(_state);
        PerformAction(action);

        // プレイヤーと敵の距離を計算
        _distance = Vector2.Distance(_state.PlayerPosition, _state.EnemyPosition);

        // ゲームの状態を更新するロジック
    }
    public string Evaluate(GameState state)
    {
        //GameStateを変更する
        if (state.PlayerHP < 30)
        {
            return "Defend";
        }
        else if (_distance >= 10 && _distance <= 20)
        {
            return "KunaiAttack";
        }
        else
        {
            return "Move";       
        }
     
    }
    public void PerformAction(string action)
    {
        switch (action)
        {
            case "KunaiAttack":
                KunaiAttack();
                break;
            case "Defend":
                Defend();
                break;
            case "Move":
                Move();
                break;
        }
    }

    private async void KunaiAttack()
    {
        if(!_isKunai)
        {
            _kunai.SetActive(true);
            _isKunai = true;
            print("テスト1");
            // 攻撃の実装
            Vector2 nowPos;
            //現在地にクナイを生成して指定時間後に消去する
            nowPos = gameObject.transform.position;
            _kunai.transform.position = nowPos;
            //プレイヤーの向きによって射出方向を決定
            //右に飛ばすelseは左
            if (_isLeft)
            {
                _kunai.transform.eulerAngles = new Vector3(0, -180, -90);
                this._kunaiRd.AddForce(new Vector2(-1500f, 0f));
            }
            else
            {
                _kunai.transform.eulerAngles = new Vector3(0, 0, -90);
                this._kunaiRd.AddForce(new Vector2(1500f, 0f));
            }
            await UniTask.Delay(TimeSpan.FromSeconds(1f));
            _isKunai = false;
            _kunai.SetActive(false);
       
        }
       
    }

    private void Defend()
    {
        print("テスト2");
        // 防御の実装
    }

    private void Move()
    {
        // 移動の実装
        Vector2 direction = (transform.position - _player.transform.position).normalized;
        // 方向に応じて判定
        if(_isRecedes)
        {
            // 敵をプレイヤーから離れる方向に移動させる
            transform.position = Vector2.MoveTowards
                (transform.position, transform.position + (Vector3)direction, _speed * Time.deltaTime);
            if (direction.x > 0)
            {
                this.transform.eulerAngles = new Vector3(0, 0, 0);
                _isLeft = true;
                Debug.Log("右に動いています。");
            }
            else
            {
                _isLeft = false;
                this.transform.eulerAngles = new Vector3(0, 180, 0);
                Debug.Log("左に動いています。");
            }
        }
        else if(_distance>=1)
        {
            // プレイヤーに向けて進む;
            // 敵をプレイヤーに近づける方向に移動させる
            transform.position = Vector2.MoveTowards(
                transform.position,
                _player.transform.position,  // 目的地をプレイヤーの位置に設定
                _speed * Time.deltaTime);
            if (direction.x > 0)
            {
                //_isLeft = false;
                this.transform.eulerAngles = new Vector3(0, 180, 0);
                Debug.Log("右に動いています。");
            }
            else
            {
                //_isLeft = true;
                this.transform.eulerAngles = new Vector3(0, 0, 0);
                Debug.Log("左に動いています。");
            }
        }
      
        if(!_isAttack)
        {
            int number = UnityEngine.Random.Range(3,10);
            Attack(number);
            print(number);
        }
        _isAttack = true;
    }
    private async void Attack(int attacktime)
    {
        await UniTask.Delay(TimeSpan.FromSeconds(attacktime));
        _isRecedes = !_isRecedes;
        _isAttack = false;
    }
}
