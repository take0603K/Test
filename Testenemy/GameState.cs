using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameState :MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _enemy;
    private Vector2 _playerPos=default;
    private Vector2 _enemyPos=default;
    [SerializeField]private int _enmeyHp=500;
    [SerializeField] private int _playerHp = 500;

    public Vector2 PlayerPosition 
    { 
        get { return _playerPos; }
    }
    public Vector2 EnemyPosition 
    {
        get { return _enemyPos; } 
    }
    public float PlayerHP 
    {
        get { return _playerHp; }
    }
    public float EnemyHP 
    {
        get { return _enmeyHp; }    
    }
    // ëºÇÃÉQÅ[ÉÄÇÃèÛë‘Ç…ä÷Ç∑ÇÈèÓïÒ
    private void FixedUpdate()
    {
        _playerPos = _player.transform.position;
        _enemyPos = _enemy.transform.position;
        //print(_enemyPos);
        //print(_playerPos);
    }
}
