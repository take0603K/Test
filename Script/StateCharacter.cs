using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateCharacter : MonoBehaviour
{
    [SerializeField]private int[] _characterHp = new int[10];
    [SerializeField]private int[] _nowCharacterHp = new int[10];
    [SerializeField]private int[] _characterAttak=new int[10];
    [SerializeField]ListCharacter _ListCharacter=default(ListCharacter);
    [SerializeField]HpBar _hpBar;
    public int[] GetMaxHp()
    {
        return _characterHp;
    }
    public int[] GetNowCharacterHp()
    {
        return _nowCharacterHp;
    }
    public void StartStateSet()
    {
        //選ばれたキャラクターのHpとATKをデータベースから持ってくる
        List<Character> CharacterList=_ListCharacter.GetCharacters();
        for(int i=0;i<10;i++)
        {
            _characterAttak[i] = CharacterList[i].GetAttack();
            _characterHp[i] = CharacterList[i].GetHp();
            _nowCharacterHp[i] = CharacterList[i].GetHp();
        }
        //Hpバーに情報を送る
        _hpBar=this.gameObject.GetComponent<HpBar>();
        _hpBar.SetBar();
    }
}
