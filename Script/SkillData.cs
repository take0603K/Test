using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SkillData : MonoBehaviour
{
    //�X�L���֐��i���o�[�E����SP�E���x�E���ʒl�E�ǉ��X�L���i���o�[�E���ʒl�E�^�[�Q�b�g
    private int[] _skillarrow;
   
    [Header("+-*/")][SerializeField] private int skillNum; //�X�L���ԍ�+-*/
    //[SerializeField] private int skillKindNum = 4; //�X�L���̎�ސ� 
    [SerializeField] private Action[,] _skill = new Action[5,5]; //�X�L���̊֐����i�[����z��

    //�L�����X�e�[�^�X�ɃA�N�Z�X���邽�߂̂���
    [SerializeField] private StateCharacter _state;
    [SerializeField] private FieldCharacter _field;
    private int[] _FieldAttack;

    private int _skillPower;
    private int _skillChara;

   // �X�L�������i���o�[0
   // �X�L���i���o�[1
   // ���x2
   // ����SP3
   // ���ʒl4
   // �ǉ��X�L�������i���o�[5
   // �X�L���i���o�[6
   // ���ʒl7
   // �^�Q8
   // �g�p��9
   // �p���^�[����10
   private void GetDate()
    {
        _FieldAttack = _state.GetCharacterAttak();
    }
    public void Skill(int[] skillarrow)
    { 
        _skillarrow = skillarrow;
        if (skillarrow == null)
        {
            Console.WriteLine("skillarrow �� null �ł�");
            return; // �����𒆒f
        }
        //�X�L������FieldCharacter�ɓ]��
        _field.GetSkillDate(_skillarrow);
        //�����Ă����X�L���̔ԍ����m�F���Ď��s
        _skillPower = _skillarrow[4];
        print(_skillPower + "�ς�[�I�I�I");
        _skillChara = _skillarrow[9];
        _skill[_skillarrow[0],_skillarrow[1]]();
        if (_skillarrow[5]>0)
        {
            //���ʒl�̓���ւ�
            _skillPower = _skillarrow[7];
            _skill[_skillarrow[5],_skillarrow[6]]();
        }
        print("�X�L�����s");
    }

    public void SkillSet()
    {
        //�P���珇�Ɏ��E�q��
        _skill[0, 0] = nulltest;
        _skill[1, 0] = Test1;
        _skill[1, 1] = Test2;
        _skill[2, 0] = Test3;
        _skill[3, 0] = Test4;
        _skill[4, 0] = Onslaught000Blow;
    }
    private void nulltest()
    {
        print("�X�L��������܂���I�I");
    }

    private void Start()
    {
        SkillSet();
        //�Q�b�g�f�[�^�̓^�[�����K�����邱��
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
