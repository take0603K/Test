using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    [SerializeField] private Slider[] _MaxHpSlider = new Slider[10];
    [SerializeField] private TextMeshProUGUI[] _MaxHpText = new TextMeshProUGUI[10];
    [SerializeField] private int[] _MaxHp = new int[10];
    [SerializeField] private int[] _NowHp = new int[10];
    [SerializeField] private int[] _MaxHp2 = new int[10];
    [SerializeField] private int[] _NowHp2 = new int[10];
    [SerializeField] GameObject _statecp = default;
    StateCharacter _state;
    public void SetBar(bool player)
    {
        //��ԍŏ��̏�Ԃ̂��߃L�����ύX�ɔ�Ή�
        _state=_statecp.GetComponent<StateCharacter>();
        //�v���C���[�P�̏���
        //���C��
        if (player ) 
        {
            _MaxHp = _state.GetMaxHp();
            _NowHp = _state.GetNowCharacterHp();
            for (int i = 0; i < 5; i++)
            {
                _MaxHpSlider[i].value = 1;
                _MaxHpText[i].text = _NowHp[i].ToString();
            }
        }
        else
        {
            _MaxHp2 = _state.GetMaxHp2();
            _NowHp2 = _state.GetNowCharacterHp2();
            for (int i = 5; i < 10; i++)
            {
                _MaxHpSlider[i].value = 1;
                _MaxHpText[i].text = _NowHp2[i-5].ToString();
            }
        }
      
    }
    public void SetHpNowChara(int[] MaxHp)
    {
        _MaxHp = MaxHp;
    }
    public void HpUpdete(int No,int NowHp)
    {
        Debug.Log("Hp���X�V���܂���");
        print(NowHp);
        print(_MaxHp[No]);
        _MaxHpSlider[No].value = (float)NowHp/(float)_MaxHp[No];
        _MaxHpText[No].text = NowHp.ToString();
    }

}
