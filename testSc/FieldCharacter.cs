using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

//public class FieldCharacter : MonoBehaviour
//{
//    [SerializeField]private StateCharacter _character;
//    private int[] _skillarrow;
//    [SerializeField] List<Character> _fieldChara = default(List<Character>);
//    List<int[]>[] _blowAttackBuff = new List<int[]>[10];
//    List<int[]>[] _AttackBuff = new List<int[]>[10];
//    List<int[]>[] _Defense = new List<int[]>[10];

//    public void GetChara(List<Character> characters)
//    {
//        //フィールド上のキャラを獲得
//        //StateCharacterから
//        _fieldChara=characters;
//    }
//    public void GetSkillDate(int[] skillarrow)
//    {
//        _skillarrow = skillarrow;
//        // スキル所属ナンバー0
//        // スキルナンバー1
//        // 速度2
//        // 消費SP3
//        // 効果値4
//        // 追加スキル所属ナンバー5
//        // スキルナンバー6
//        // 効果値7
//        // タゲ8
//        // 使用者9
//        //継続ターン数10
//    }
//    //private void Start()
//    //{
//    //    //// 配列の各要素を初期化
//    //    //for (int i = 0; i < _blowAttackBuff.Length; i++)
//    //    //{
//    //    //    _blowAttackBuff[i] = new List<int[]>();
//    //    //}

//    //}
//    public void BuffPlas()
//    {
//        int index = _skillarrow[8];
//        int[] buff={ _skillarrow[4], _skillarrow[10] };
//        _blowAttackBuff[index].Add(buff);
//    }
//    public void AttackBuff(float attack)
//    {
//        //各種攻撃に個別で乗るバフ効果を与える
//        //後でswitch文に変更
//        List<int[]> Buffs;
//        Buffs = _blowAttackBuff[_skillarrow[9]];
//        if (Buffs != null)
//        {
//            for (int i = 0; i < Buffs.Count; i++)
//            {
//                int[] arrow = Buffs[i];
//                float Buff = arrow[0] / 100;
//                attack = attack * Buff;
//            }
//        }
           
//        LastAttackBuff(attack);
//    }
//    private void LastAttackBuff(float attack)
//    {
//        //すべての攻撃に乗算されるバフ
//        List<int[]> Buffs;
//        Buffs = _AttackBuff[_skillarrow[9]];
//        if (Buffs != null)
//        {
//            for (int i = 0; i < Buffs.Count; i++)
//            {
//                int[] arrow = Buffs[i];
//                float Buff = arrow[0] / 100;
//                attack = attack * Buff;
//            }
//        }   
//        Damage(attack);
//    }
//    private void Damage(float attack)
//    {
//        //ターゲットの防御力参照
//        List<int[]> Buffs;
//        Buffs = _Defense[_skillarrow[8]];
//        if (Buffs != null)
//        {
//            for (int i = 0; i < Buffs.Count; i++)
//            {
//                int[] arrow = Buffs[i];
//                float Buff = arrow[0] / 100;
//                attack = attack * Buff;
//            }
//        } 
//        // 切り上げて最も近い整数を取得
//        attack = (float)Math.Ceiling(attack);

//        // float から int への変換
//        int damage = (int)attack;
//        //やっとHp減らせる
//        HpUpdete(damage, true);
//    }
//    private void HpUpdete(int damage,bool down)
//    {
//       //down判定で回復も可能
//        int No = _skillarrow[8];

//        //いらないけど一応変更があったときのため
//        _character.HpUpdate(damage, down, No);
//    }
//}
