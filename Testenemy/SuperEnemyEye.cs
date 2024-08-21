using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Cysharp.Threading.Tasks;


public class SuperEnemyEye : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private EnemyObj _enemy;
    [SerializeField] private GameObject _enemyObj;
    SuperEnemy _superEnemy;
    private bool _isJumpAwait = default;

    public enum EnemyObj
    {
        Kunai,
        Wait,
        Jump,
        Chase,
        Attack,
        Back
    };
    // Start is called before the first frame update
    void Start()
    {
        _superEnemy = _enemyObj.GetComponent<SuperEnemy>();
    }
    private async void Jumpawait()
    {
        //壁で連続ジャンプループに入らないようにする    
        _superEnemy.Jump();
        //_superEnemy.skillNum = 0;

        await UniTask.Delay(TimeSpan.FromSeconds(1f));
        _isJumpAwait = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == _player)
        {
            switch (_enemy)
            {
                case EnemyObj.Kunai:
                    _superEnemy.KunaiThrow();
                    break;
                case EnemyObj.Back:
                    _superEnemy.AttackState();
                    break;
                case EnemyObj.Attack:
                    _superEnemy.skillNum = 2;
                    break;
            }
        }
        if (collision.gameObject.CompareTag("ground") && _enemy == EnemyObj.Jump && !_isJumpAwait)
        {
            _isJumpAwait = true;
            print("飛べ！！！");
            Jumpawait();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == _player)
        {
            _superEnemy.skillNum = 0;
            print("離れた");
        }
    }
}
