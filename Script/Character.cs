using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    Test11,
    Test12,
    Test13,
    Test14,
    Test15,
}
public enum CharacterGroup
{
    Guardian,//守護
    Gambling,//賭博
    Resonance,//共鳴
    Onslaught,//猛攻
    Counterattack,//逆襲
    Prayer,//祈祷
    Blessing,//祝福
    Decay,//腐食
}
public enum CharacterBattleStyle
{
    Guardian,//守護
    Gambling,//賭博
    Resonance,//共鳴
    Onslaught,//猛攻
    Counterattack,//逆襲
    Prayer,//祈祷
    Blessing,//祝福
    Decay,//腐食
}

[CreateAssetMenu(fileName = "Character", menuName = "CreateCharacter")]
public class Character : ScriptableObject
{
    [Header("Item Properties")]
    [SerializeField]private string CharacterJpName;    // キャラクターの管理用の名前
    [SerializeField]private Sprite _icon;     // キャラクターののアイコン画像
   
    public CharacterEnum CharacterName;  // キャラクターの名前
    public CharacterGroup group;//キャラクターの所属
    public CharacterBattleStyle battleStyle;//キャラクターの戦術

    [SerializeField]private int Hp;//キャラクターのHp
  
    [SerializeField]private int Attack;//キャラクターの攻撃力

    

    [Header("スキル関数ナンバー・消費SP・速度・効果値・追加スキルナンバー・効果値・ターゲット")]
    [SerializeField] private int[] Skill1 = new int[7];
    [SerializeField] private int[] Skill2 = new int[7];
    [SerializeField] private int[] Skill3 = new int[7];
    //インスペクター上に二次元以上の配列を表示するにはちょっとした工夫が必要らしい


    [TextArea]
    public string characterText; // キャラクターの説明
    // ここに必要に応じてメソッドや追加のプロパティを定義できます
    public Sprite icon()
    {
        return _icon;
    }
    public int GetHp()
    {
        return Hp;
    }
    public int GetAttack()
    {
        return Attack;
    }
    public int[] GetSkill()
    {
        return Skill1;
    }
    public int[] GetSkill2()
    {
        return Skill2;
    }
    public int[] GetSkill3()
    {
        return Skill3;
    }
}