using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SkillData : MonoBehaviour
{
    private int[] _skillarrow;
   
    [Header("+-*/")][SerializeField] private int skillNum; //�X�L���ԍ�+-*/
    //[SerializeField] private int skillKindNum = 4; //�X�L���̎�ސ� 
    [SerializeField] private Action[] _skill = new Action[5]; //�X�L���̊֐����i�[����z��
    [SerializeField] private int[] _int = new int[2];
    [SerializeField] private int _ans = default;
    public void Skill(int[] skillarrow)
    { 
        _skillarrow = skillarrow;
        //�����Ă����X�L���̔ԍ����m�F���Ď��s
        _skill[_skillarrow[1]]();
    }

    public void SkillSet()
    {
        _skill[0] = Test1;
        _skill[1] = Test2;
        _skill[2] = Test3;
        _skill[3] = Test4;
        _skill[4] = Test5;
    }

    private void Start()
    {
        SkillSet();
    }

    public void Test1()
    {
        _ans = _int[0] + _int[1];
        _skill[4]();
    }
    public void Test2()
    {
        _ans = _int[0] - _int[1];
    }
    public void Test3()
    {
        _ans = _int[0] * _int[1];
    }
    private void Test4()
    {
        _ans = _int[0] / _int[1];
    }
    private void Test5()
    {
        _ans = _ans + 15;
    }
}
