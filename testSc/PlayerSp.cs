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
//        // 初期配布
//        _Sp = _StartSp;
//        SpUpdeta();
//    }
//    public void SpManagement (int turn)
//    {
//        //あとでロスト分を足すこと
//        _Sp = _Sp + _plusSp + (turn * 5);
//        //最大所持制限を超えた場合２００に戻す
//        if (_Sp > _maxSp) 
//        { 
//            _Sp=_maxSp;
//        }
//        SpUpdeta() ;
//    }
//    public void SpUpdeta()
//    {
//        //Spスライダーの更新
//        _spSlider.value = (float)_Sp / (float)_maxSp;
//        _spText.text=_Sp.ToString();
//        //リストキャラクラスにSP情報を送る
//        _characterList.GetSp(_Sp);
//    }
//    public void SpManager(int SP)
//    {
//        _Sp = SP;
//        SpUpdeta();
//    }
//}
