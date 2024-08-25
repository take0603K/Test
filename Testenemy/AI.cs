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
  
    [Header("�N�i�C������")] [SerializeField] GameObject _kunai = null;
    [Header("�ߋ����U��")] [SerializeField] GameObject _attack = null;

    private bool _isAttack = false;
    private bool _isRecedes = true;
    Rigidbody2D _kunaiRd;
    private bool _isKunai = false;
    private void Start()
    {
        _kunaiRd = _kunai.GetComponent<Rigidbody2D>();
        _kunai.SetActive(false);

        //�����_���֐��̃V�[�h�l�����ݎ������Q�Ƃ��ĕύX
        UnityEngine.Random.InitState(DateTime.Now.Millisecond);
    }
    private void FixedUpdate()
    {
        string action = Evaluate(_state);
        PerformAction(action);

        // �v���C���[�ƓG�̋������v�Z
        _distance = Vector2.Distance(_state.PlayerPosition, _state.EnemyPosition);

        // �Q�[���̏�Ԃ��X�V���郍�W�b�N
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
            print("�e�X�g1");
            // �U���̎���
            Vector2 nowPos;
            //���ݒn�ɃN�i�C�𐶐����Ďw�莞�Ԍ�ɏ�������
            nowPos = gameObject.transform.position;
            _kunai.transform.position = nowPos;
            //�v���C���[�̌����ɂ���Ďˏo����������
            //�E�ɔ�΂�else�͍�
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
        print("�e�X�g2");
        // �h��̎���
    }

    private void Move()
    {
        // �ړ��̎���
        Vector2 direction = (transform.position - _player.transform.position).normalized;
        // �����ɉ����Ĕ���
        if(_isRecedes)
        {
            // �G���v���C���[���痣�������Ɉړ�������
            transform.position = Vector2.MoveTowards
                (transform.position, transform.position + (Vector3)direction, _speed * Time.deltaTime);
            if (direction.x > 0)
            {
                this.transform.eulerAngles = new Vector3(0, 0, 0);
                _isLeft = true;
                Debug.Log("�E�ɓ����Ă��܂��B");
            }
            else
            {
                _isLeft = false;
                this.transform.eulerAngles = new Vector3(0, 180, 0);
                Debug.Log("���ɓ����Ă��܂��B");
            }
        }
        else if(_distance>=1)
        {
            // �v���C���[�Ɍ����Đi��;
            // �G���v���C���[�ɋ߂Â�������Ɉړ�������
            transform.position = Vector2.MoveTowards(
                transform.position,
                _player.transform.position,  // �ړI�n���v���C���[�̈ʒu�ɐݒ�
                _speed * Time.deltaTime);
            if (direction.x > 0)
            {
                //_isLeft = false;
                this.transform.eulerAngles = new Vector3(0, 180, 0);
                Debug.Log("�E�ɓ����Ă��܂��B");
            }
            else
            {
                //_isLeft = true;
                this.transform.eulerAngles = new Vector3(0, 0, 0);
                Debug.Log("���ɓ����Ă��܂��B");
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
