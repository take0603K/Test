using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//キャラクターを表す列挙型
public enum CharacterEnum
{
    Test1,
    Test2,
    Test3,
    Test4,
    Test5,
    Test6,
    Test7,
    Test8,
    Test9,
    Test10,
}
public enum CharacterLevel
{
    mongrelEnemy,//雑魚敵
    eliteEnemy,//精鋭
    bossEnemy,//ボス
}

[CreateAssetMenu(fileName = "Enemy", menuName = "CreateEnemy")]
public class Character : ScriptableObject
{
    [SerializeField]private string _characterJpName;    // キャラクターの管理用の名前
    [SerializeField]private Sprite _icon;     // キャラクターののアイコン画像
   
    [SerializeField]private CharacterEnum _enemyName;  // キャラクターの名前
    [SerializeField]private CharacterLevel _group;//キャラクターの所属

    [SerializeField]private int Hp;//キャラクターのHp
    [SerializeField]private GameObject _enemy;//オブジェクト

    [TextArea]
    public string _characterText; // キャラクターの説明
    // ここに必要に応じてメソッドや追加のプロパティを定義できます
    public GameObject enemy()
    {
        return _enemy;
    }
    public int GetHp()
    {
        return Hp;
    }
    public CharacterLevel GetGroup()
    { 
        return _group;
    }
}