using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//public class PlayerSp : MonoBehaviour
//{
//    [SerializeField]private int _Sp=0;
//    public int GetSp()
//    { 
//        return _Sp; 
//    }
//    [SerializeField]private const int _StartSp = 20;
//    [SerializeField]private int _plusSp = 35;
//    [SerializeField] ListCharacter _characterList;
//    private const int _maxSp = 200;

//    [SerializeField] private Slider _spSlider = default;
//    [SerializeField] private TextMeshProUGUI _spText = default;
//    void Start()
//    {
//        // �����z�z
//        _Sp = _StartSp;
//        SpUpdeta();
//    }
//    public void SpManagement (int turn)
//    {
//        //���ƂŃ��X�g���𑫂�����
//        _Sp = _Sp + _plusSp + (turn * 5);
//        //�ő及�������𒴂����ꍇ�Q�O�O�ɖ߂�
//        if (_Sp > _maxSp) 
//        { 
//            _Sp=_maxSp;
//        }
//        SpUpdeta() ;
//    }
//    public void SpUpdeta()
//    {
//        //Sp�X���C�_�[�̍X�V
//        _spSlider.value = (float)_Sp / (float)_maxSp;
//        _spText.text=_Sp.ToString();
//        //���X�g�L�����N���X��SP���𑗂�
//        _characterList.GetSp(_Sp);
//    }
//    public void SpManager(int SP)
//    {
//        _Sp = SP;
//        SpUpdeta();
//    }
//}
