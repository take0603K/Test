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
//        //�t�B�[���h��̃L�������l��
//        //StateCharacter����
//        _fieldChara=characters;
//    }
//    public void GetSkillDate(int[] skillarrow)
//    {
//        _skillarrow = skillarrow;
//        // �X�L�������i���o�[0
//        // �X�L���i���o�[1
//        // ���x2
//        // ����SP3
//        // ���ʒl4
//        // �ǉ��X�L�������i���o�[5
//        // �X�L���i���o�[6
//        // ���ʒl7
//        // �^�Q8
//        // �g�p��9
//        //�p���^�[����10
//    }
//    //private void Start()
//    //{
//    //    //// �z��̊e�v�f��������
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
//        //�e��U���Ɍʂŏ��o�t���ʂ�^����
//        //���switch���ɕύX
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
//        //���ׂĂ̍U���ɏ�Z�����o�t
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
//        //�^�[�Q�b�g�̖h��͎Q��
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
//        // �؂�グ�čł��߂��������擾
//        attack = (float)Math.Ceiling(attack);

//        // float ���� int �ւ̕ϊ�
//        int damage = (int)attack;
//        //�����Hp���点��
//        HpUpdete(damage, true);
//    }
//    private void HpUpdete(int damage,bool down)
//    {
//       //down����ŉ񕜂��\
//        int No = _skillarrow[8];

//        //����Ȃ����ǈꉞ�ύX���������Ƃ��̂���
//        _character.HpUpdate(damage, down, No);
//    }
//}
