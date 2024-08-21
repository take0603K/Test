using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateCharacter : MonoBehaviour
{
    //アクセス用
    [SerializeField] private FieldCharacter _fieldCharacter;
    //もしかしたらなくても動く
    [SerializeField]private int[] _characterHp = new int[10];
    [SerializeField]private int[] _nowCharacterHp = new int[10];
   
    //[SerializeField] private int[] _nowcharacterAttak = new int[10];
    [SerializeField]ListCharacter _ListCharacter=default(ListCharacter);


    [SerializeField] private int[] _characterHp2 = new int[10];
    [SerializeField] private int[] _nowCharacterHp2 = new int[10];
    //[SerializeField] private int[] _fieldCharaAttack2 = new int[10];
    //[SerializeField] private int[] _nowcharacterAttak2 = new int[10];
    [SerializeField]ListCharacter _ListCharacter2 =default(ListCharacter);

    //現在フィールドにいるキャラを格納
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
        //SkillDataで使用
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
        //選ばれたキャラクターのHpとATKをデータベースから持ってくる
        //リストキャラクタークラスからの参照
       _characterList1=_ListCharacter.GetCharacters();
        for(int i=0;i<10;i++)
        {
           
            //_nowcharacterAttak[i] = _characterList1[i].GetAttack();
            _characterHp[i] = _characterList1[i].GetHp();
            _nowCharacterHp[i] = _characterList1[i].GetHp();
        }
        //Hpバーに情報を送る
        _hpBar=_players.GetComponent<HpBar>();
        _hpBar.SetBar(true);
        StartStateSet2();
    }
    public void StartStateSet2()
    {
        //プレイヤー２の分を設定
        //選ばれたキャラクターのHpとATKをデータベースから持ってくる
        //リストキャラクタークラスからの参照
        _characterList2 = _ListCharacter2.GetCharacters();
        for (int i = 0; i < 10; i++)
        {
           
            //_nowcharacterAttak2[i] = _characterList2[i].GetAttack();
            _characterHp2[i] = _characterList2[i].GetHp();
            _nowCharacterHp2[i] = _characterList2[i].GetHp();
        }
        //Hpバーに情報を送る
        _hpBar = _players.GetComponent<HpBar>();
        _hpBar.SetBar(false);
        NowCharaList();
    }
    private void NowCharaList()
    {
        //最初の入れ替え前のみ有効
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
            //Hp最大値を超過する場合置き換える
            if (_fieldCharaNowHp[No] > _fieldCharaMaxHp[No])
            {
                _fieldCharaNowHp[No] = _fieldCharaMaxHp[No];
            }
        }
        _hpBar.HpUpdete(No, _fieldCharaNowHp[No]);
    }
}
