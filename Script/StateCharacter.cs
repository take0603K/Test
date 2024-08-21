using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateCharacter : MonoBehaviour
{
    //�A�N�Z�X�p
    [SerializeField] private FieldCharacter _fieldCharacter;
    //������������Ȃ��Ă�����
    [SerializeField]private int[] _characterHp = new int[10];
    [SerializeField]private int[] _nowCharacterHp = new int[10];
   
    //[SerializeField] private int[] _nowcharacterAttak = new int[10];
    [SerializeField]ListCharacter _ListCharacter=default(ListCharacter);


    [SerializeField] private int[] _characterHp2 = new int[10];
    [SerializeField] private int[] _nowCharacterHp2 = new int[10];
    //[SerializeField] private int[] _fieldCharaAttack2 = new int[10];
    //[SerializeField] private int[] _nowcharacterAttak2 = new int[10];
    [SerializeField]ListCharacter _ListCharacter2 =default(ListCharacter);

    //���݃t�B�[���h�ɂ���L�������i�[
    [SerializeField]List<Character> FieldChara =default(List<Character>);
    [SerializeField] private int[] _fieldCharaAttack = new int[10];
    [SerializeField] private int[] _fieldCharaNowHp = new int[10];
                     private int[] _fieldCharaMaxHp = new int[10];

    [SerializeField]List<Character>_characterList1 =default(List<Character>);
    [SerializeField]List<Character>_characterList2 =default(List<Character>);

    [SerializeField] GameObject _players;

    [SerializeField] HpBar _hpBar;
    public int[] GetMaxHp()
    {
        return _characterHp;
    }
    public int[] GetNowCharacterHp()
    {
        return _nowCharacterHp;
    }
    public int[] GetCharacterAttak()
    {
        //SkillData�Ŏg�p
        return _fieldCharaAttack;
    }
    public int[] GetMaxHp2()
    {
        return _characterHp2;
    }
    public int[] GetNowCharacterHp2()
    {
        return _nowCharacterHp2;
    }
    public void StartStateSet()
    {
        //�I�΂ꂽ�L�����N�^�[��Hp��ATK���f�[�^�x�[�X���玝���Ă���
        //���X�g�L�����N�^�[�N���X����̎Q��
       _characterList1=_ListCharacter.GetCharacters();
        for(int i=0;i<10;i++)
        {
           
            //_nowcharacterAttak[i] = _characterList1[i].GetAttack();
            _characterHp[i] = _characterList1[i].GetHp();
            _nowCharacterHp[i] = _characterList1[i].GetHp();
        }
        //Hp�o�[�ɏ��𑗂�
        _hpBar=_players.GetComponent<HpBar>();
        _hpBar.SetBar(true);
        StartStateSet2();
    }
    public void StartStateSet2()
    {
        //�v���C���[�Q�̕���ݒ�
        //�I�΂ꂽ�L�����N�^�[��Hp��ATK���f�[�^�x�[�X���玝���Ă���
        //���X�g�L�����N�^�[�N���X����̎Q��
        _characterList2 = _ListCharacter2.GetCharacters();
        for (int i = 0; i < 10; i++)
        {
           
            //_nowcharacterAttak2[i] = _characterList2[i].GetAttack();
            _characterHp2[i] = _characterList2[i].GetHp();
            _nowCharacterHp2[i] = _characterList2[i].GetHp();
        }
        //Hp�o�[�ɏ��𑗂�
        _hpBar = _players.GetComponent<HpBar>();
        _hpBar.SetBar(false);
        NowCharaList();
    }
    private void NowCharaList()
    {
        //�ŏ��̓���ւ��O�̂ݗL��
        for (int i = 0;i < 10;i++) 
        {
           if(i<=5)
            {
                FieldChara.Add(_characterList1[i]);
                _fieldCharaAttack[i] = _characterList1[i].GetAttack();
                _fieldCharaNowHp[i]= _characterList1[i].GetHp();
                _fieldCharaMaxHp[i] = _characterList1[i].GetHp();
            }
           else
            {
                FieldChara.Add(_characterList2[i-5]);
                _fieldCharaAttack[i] = _characterList2[i-5].GetAttack();
                _fieldCharaNowHp[i] = _characterList2[i-5].GetHp();
                _fieldCharaMaxHp[i] = _characterList2[i-5].GetHp();
            }
        }
        _fieldCharacter.GetChara(FieldChara);
        _hpBar.SetHpNowChara(_fieldCharaMaxHp);
    }
    public void HpUpdate(int Damage,bool Down,int No)
    {
        print(Damage);

        print(Down);

        print(No);
        if (Down)
        {
            _fieldCharaNowHp[No] = _fieldCharaNowHp[No] - Damage;
        }
        else
        {
            _fieldCharaNowHp[No]= _fieldCharaNowHp[No] + Damage;
            //Hp�ő�l�𒴉߂���ꍇ�u��������
            if (_fieldCharaNowHp[No] > _fieldCharaMaxHp[No])
            {
                _fieldCharaNowHp[No] = _fieldCharaMaxHp[No];
            }
        }
        _hpBar.HpUpdete(No, _fieldCharaNowHp[No]);
    }
}
