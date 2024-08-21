using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SkillData : MonoBehaviour
{
    //スキル関数ナンバー・消費SP・速度・効果値・追加スキルナンバー・効果値・ターゲット
    private int[] _skillarrow;
   
    [Header("+-*/")][SerializeField] private int skillNum; //スキル番号+-*/
    //[SerializeField] private int skillKindNum = 4; //スキルの種類数 
    [SerializeField] private Action[,] _skill = new Action[5,5]; //スキルの関数を格納する配列

    //キャラステータスにアクセスするためのもの
    [SerializeField] private StateCharacter _state;
    [SerializeField] private FieldCharacter _field;
    private int[] _FieldAttack;

    private int _skillPower;
    private int _skillChara;

   // スキル所属ナンバー0
   // スキルナンバー1
   // 速度2
   // 消費SP3
   // 効果値4
   // 追加スキル所属ナンバー5
   // スキルナンバー6
   // 効果値7
   // タゲ8
   // 使用者9
   // 継続ターン数10
   private void GetDate()
    {
        _FieldAttack = _state.GetCharacterAttak();
    }
    public void Skill(int[] skillarrow)
    { 
        _skillarrow = skillarrow;
        if (skillarrow == null)
        {
            Console.WriteLine("skillarrow は null です");
            return; // 処理を中断
        }
        //スキル情報をFieldCharacterに転送
        _field.GetSkillDate(_skillarrow);
        //入ってきたスキルの番号を確認して実行
        _skillPower = _skillarrow[4];
        print(_skillPower + "ぱわー！！！");
        _skillChara = _skillarrow[9];
        _skill[_skillarrow[0],_skillarrow[1]]();
        if (_skillarrow[5]>0)
        {
            //効果値の入れ替え
            _skillPower = _skillarrow[7];
            _skill[_skillarrow[5],_skillarrow[6]]();
        }
        print("スキル実行");
    }

    public void SkillSet()
    {
        //１から順に守護・賭博
        _skill[0, 0] = nulltest;
        _skill[1, 0] = Test1;
        _skill[1, 1] = Test2;
        _skill[2, 0] = Test3;
        _skill[3, 0] = Test4;
        _skill[4, 0] = Onslaught000Blow;
    }
    private void nulltest()
    {
        print("スキルがありません！！");
    }

    private void Start()
    {
        SkillSet();
        //ゲットデータはターン毎適応すること
        GetDate();
    }

    public void Test1()
    {

    }
    public void Test2()
    {
        
    }
    public void Test3()
    {
        
    }
    private void Test4()
    {
        
    }
    private void Onslaught000Blow()
    {
        float Attack = _FieldAttack[_skillChara];
        Attack = Attack * (_skillPower/100);
        _field.AttackBuff(Attack);
    }
}
