using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class NewAiTest : MonoBehaviour
{
    [SerializeField] private GameState _state;
    [SerializeField] private GameObject _player;

    [Header("�N�i�C������")] [SerializeField] GameObject _kunai = null;
    [Header("�ߋ����U��")] [SerializeField] GameObject _attack = null;

    Rigidbody2D _kunaiRd;
    private bool _isKunai = false;

    private bool _isLeft = false;
    private bool _isAttack = false;
    //��Ɋm�F�ς݂�

    private float _speed = 5f;
   
    private float _distance = default;

  

  
    private bool _isRecedes = true;


    //�X�[�p�[�̂ق�

    [SerializeField] private const float _enemySpeed = 17.5f;
    private bool _isStayAttackState = default;
    private bool _isBack = default;
    private int _randomPar = 33;

    Rigidbody2D _rigidbody2D;

    //�����p
    private float _speedX;//X���̃v���C���[�̑��x�̐�Βl
    private float _speedY;//Y���̃v���C���[�̑��x�̐�Βl
    private Transform _transform;//transform���擾
    private Vector3 _prevPosition;//�O�t���[���̈ʒu�擾

    [Header("���ړ��������x")] [SerializeField] private float _decelerationSpeed = 200.0f;
    [Header("�������E���S��~�����̊")] [SerializeField] private float _stopMovePoint = 1f;//���S��~�����̊�@x�������ł�낵�H//���O����?

    private bool _isGround = false;
    [SerializeField] private LayerMask groundLayer;

    private float _jump = 550f;
    private float F = 1.5f;
    public int _jumpPar = 10;


    private void Start()
    {
        this.transform.eulerAngles = new Vector3(0, 0, 0);
        _kunaiRd = _kunai.GetComponent<Rigidbody2D>();
        _kunai.SetActive(false);
        _rigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();

        //�����_���֐��̃V�[�h�l�����ݎ������Q�Ƃ��ĕύX
        UnityEngine.Random.InitState(DateTime.Now.Millisecond);
    }
    private void FixedUpdate()
    {
        Move();
        string action = Evaluate(_state);
        PerformAction(action);

        // �v���C���[�ƓG�̋������v�Z
        _distance = Vector2.Distance(_state.PlayerPosition, _state.EnemyPosition);

        // �Q�[���̏�Ԃ��X�V���郍�W�b�N
    }
    private void Move()
    {
        Vector2 position = this.transform.position;

        // �O�t���[���ʒu
        Vector2 delta = _prevPosition;

        // �O�t���[���ʒu�X�V
        _prevPosition = position;
        float delX = position.x - delta.x;

        //�v���C���[���x
        _speedX = Mathf.Abs(this._rigidbody2D.velocity.x);
        _speedY = Mathf.Abs(this._rigidbody2D.velocity.y);

        //���ړ�����
        if (_speedX > 0.1f)
        {
            this._rigidbody2D.AddForce(new Vector2(delX * -_decelerationSpeed, 0));
        }

        ////���S��~����
        //if (_speedX + _speedY <= _stopMovePoint)
        //{
        //    _rigidbody2D.velocity = new Vector2(0, 0);
        //}

        //���C�𔭎ˁi�����P�G���C�̎n�_�A�����Q�G���C�̌����A�����R�G���C�̋����A�����S�G���C���[�}�X�N�j
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, F, groundLayer);
        //���n���菈��
        if (hit)
        {
            _isGround = true;
        }
        else
        {
            _isGround = false;
        }

    }
    public string Evaluate(GameState state)
    {
        //GameState��ύX����
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
            return "MoveEnemy";
        }

    }
    public void PerformAction(string action)
    {
        switch (action)
        {
            case "KunaiAttack":
                KunaiAttack();
                if (_isBack)
                {
                    BackStep();
                }
                if (_isAttack)
                {
                    Attack();
                }
                break;
            case "Defend":
              //  Defend();
                break;
            case "Move":
                MoveEnemy();
                break;
        }
    }
    public async void MoveEnemy()
    {
        if (!_isStayAttackState && _isGround)
        {

            _isStayAttackState = true;
            // �P����P�O�O�܂ł̒����烉���_���ɐ�����I������B
            int number = UnityEngine.Random.Range(1, 100);
            _jumpPar = UnityEngine.Random.Range(1, 100);

            // �i�o����33���j
            if (number >= _randomPar)
            {
                _randomPar = _randomPar + 15;

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
            // �i�o����64���j
            else
            {
                _randomPar = 30;
                _isAttack = true;
                int attackNumber = UnityEngine.Random.Range(1, 100);
                if (attackNumber <= 43)
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

        //�v���C���[�̈ʒu��������荶�ɂ���Ȃ�v���C���[���痣���
        if (playerPos < X)
        {
            //�E �ړ�    
            _isLeft = false;
            this.transform.eulerAngles = new Vector3(0, 0, 0);
            _rigidbody2D.AddForce(Vector2.right * ((_enemySpeed - _rigidbody2D.velocity.x) * 5));
        }
        else
        {
            //��  �ړ�     
            _isLeft = true;
            this.transform.eulerAngles = new Vector3(0, 180, 0);
            _rigidbody2D.AddForce(Vector2.right * ((-_enemySpeed - _rigidbody2D.velocity.x) * 5));
        }

    }
    private void Attack()
    {
        float playerPos = _player.transform.position.x;
        float X = this.transform.position.x;
        //�v���C���[�̈ʒu��������荶�ɂ���Ȃ�v���C���[�ɋ߂Â�
        if (playerPos < X)
        {
            //��  �ړ�     
            _isLeft = false;
            this.transform.eulerAngles = new Vector3(0, 0, 0);
            _rigidbody2D.AddForce(Vector2.right * ((-_enemySpeed - _rigidbody2D.velocity.x) * 3));

        }
        else
        {
            //�E �ړ�    
            _isLeft = true;
            this.transform.eulerAngles = new Vector3(0, 180, 0);
            _rigidbody2D.AddForce(Vector2.right * ((_enemySpeed - _rigidbody2D.velocity.x) * 3));
        }

    }
    public void Jump()
    {
        //�W�����v����
        if (_isGround)
        {
            this._rigidbody2D.AddForce(new Vector2(0f, _jump));
        }
    }

    public async void KunaiAttack()
    {
        //���ݒn�ɃN�i�C�𐶐����Ďw�莞�Ԍ�ɏ�������
        if (!_isKunai)
        {
            _isKunai = true;
            _kunai.SetActive(true);
            _kunai.transform.position = gameObject.transform.position;
            float time = 1.2f;
            //�v���C���[�̌����ɂ���Ďˏo����������
            //�E�ɔ�΂�else�͍�
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
