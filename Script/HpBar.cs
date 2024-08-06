using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    [SerializeField] private Slider[] _MaxHpSlider = new Slider[5];
    [SerializeField] private TextMeshProUGUI[] _MaxHpText = new TextMeshProUGUI[5];
    [SerializeField] private int[] _MaxHp = new int[10];
    [SerializeField] private int[] _NowHp = new int[10];
    [SerializeField] GameObject _Player = default;
    StateCharacter _state;
    public void SetBar()
    {
        _state=_Player.GetComponent<StateCharacter>();
        _MaxHp=_state.GetMaxHp();
        _NowHp=_state.GetNowCharacterHp();
        for(int i=0;i<5;i++)
        {
            _MaxHpSlider[i].value = 1;
            _MaxHpText[i].text = _NowHp[i].ToString();
        }
    }
    public void HpUpdete(int No)
    {
        _MaxHpSlider[No].value = (float)_NowHp[No]/(float)_MaxHp[No];
        _MaxHpText[No].text = _NowHp[No].ToString();
    }

}
