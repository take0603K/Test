using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListCharacter : MonoBehaviour
{
    //キャラクターデータベース
    [SerializeField]
    private CharacterDataBase _characterDataBase;
    //選んだキャラクターリスト
    [SerializeField]
    private List<Character> _selectCharacterList =
        new List<Character>();

    private List<int[]> _skillList = new List<int[]>();
  

    //選んだキャラのデータベース内での番号をこの中に入れる
    [SerializeField] private int[] _selectCharacterNo = new int[10];

    //データベースのキャラクターリストの内容をコピーするための格納用リスト
    [SerializeField] private List<Character> _CharacterList = default(List<Character>);

    //キャラクターのアイコン
   // [SerializeField]private Canvas _myCanvas=default(Canvas);
    [SerializeField]private Image[] _CharacterUi=new Image[5];
    // アクセス用
    [SerializeField]StateCharacter _stateCharacter=default(StateCharacter);
    [SerializeField]TriggerIcon _triggerIcon=default(TriggerIcon);
    [SerializeField]ListSort _listSort=default(ListSort);
    //選択中スキル
    private bool[,] _isSkill = new bool[10,3];
    [SerializeField]private Button[] _skillButton=new Button[3];
    [SerializeField]private Sprite[] _buttonImage=new Sprite[2];
    private Image[] _sprites=new Image[3];
    private bool _stay = false;
    //現在の残りSP
    private int _nowSp=0;
    //使用後のSP（仮）
    private int _testSp=0;

    public int ReturnSP()
    {
        return _testSp;
    }

    public Image[] GetCharacterImage()
    {
        return _CharacterUi;
    }
    public List<Character> GetCharacters()
    {
        return _selectCharacterList;
    }
    public void CharacterSet()
    {
        //セレクトしたキャラを格納する
        _CharacterList = _characterDataBase.GetCharacterLists();
        for(int i=0;i<_selectCharacterNo.Length;i++)
        {
            _selectCharacterList.Add(_CharacterList[_selectCharacterNo[i]]);
            //五番目のキャラまでを格納する
            if(i<5)
            {
                _CharacterUi[i].GetComponent<Image>();
                _CharacterUi[i].sprite = _selectCharacterList[i].icon();
            }
          
        }
        //ボタンのオンオフセット
        for (int i = 0; i <= 2; i++)
        {
            _sprites[i] = _skillButton[i].GetComponent<Image>();
        }
    }
    public void GetSp(int Sp)
    {
        _nowSp = Sp;
        _testSp = _nowSp;
    }
    public void SortList()
    {
        print(_skillList + "スキルの数だよ");
        _listSort.MergeList(_skillList);
    }
    public void ButtonColor(int CharaNo)
    {
        //選択されたキャラクターのsyキル待機状態をボタンに反映
       for(int i=0;i<=2;i++)
        {
            if (_isSkill[CharaNo,i]==true)
            {
                _sprites[i].sprite = _buttonImage[1];
            }
            else
            {
                _sprites[i].sprite= _buttonImage[0];
            }
        }
    }
    public async void SkillSelect(string selectSKill)
    {
        if (!_stay)
        {
            //１０体をプレイヤー区別なしに保持
            //GetCharacterはただのint型
            _stay = true;
            int CharaNo = _triggerIcon.GetCharacter();

            //５体をプレイヤーを区別して保持
            int CharaNoPlayer = CharaNo;
            if (CharaNo >= 5)
            {
                CharaNoPlayer = CharaNo - 5;
            }
            //ここでボタンの色を確認する
            ButtonColor(CharaNo);
            switch (selectSKill)
            {
                //_isSkillはboolの二次元配列
                case "skill1":
                    print(CharaNoPlayer);
                    if (_isSkill[CharaNo, 0])
                    {
                        //スキルをリストから削除
                        _skillList.Remove(_selectCharacterList[CharaNoPlayer].GetSkill());
                        //減らしたテストSPを元に戻す
                        _testSp = _testSp + _selectCharacterList[CharaNoPlayer].GetSkill()[3];
                        _isSkill[CharaNo, 0] = false;
                        print(_testSp);
                        print("解除されましたスキル１");
                        
                        
                    }
                    //現在のテストSPと選択されたキャラのスキル１の消費SPを比較して足りていれば使用を許可
                    else if (_testSp >= _selectCharacterList[CharaNoPlayer].GetSkill()[3])
                    {
                        print("ターゲットを選んでくださいスキル１");
                        //ここにターゲットを入れるための処理
                        _triggerIcon._targetSkill = true;
                        //ターゲットが決まり次第作動
                        await UniTask.WaitUntil(() => _triggerIcon._targetSkillSet);
                        _triggerIcon._targetSkill = false;
                        _triggerIcon._targetSkillSet = false;
                        //選択済のスキルのターゲットを格納
                        _selectCharacterList[CharaNoPlayer].GetSkill()[8] = _triggerIcon.GetCharacter();
                        _selectCharacterList[CharaNoPlayer].GetSkill()[9] = CharaNo;
                        //スキルをリストに格納
                        _skillList.Add(_selectCharacterList[CharaNoPlayer].GetSkill());
                        //テストSPを減少
                        _testSp = _testSp - _selectCharacterList[CharaNoPlayer].GetSkill()[1];
                        _isSkill[CharaNo, 0] = true;
                        print(_testSp);
                        _stay = false;
                    }
                    break;
                case "skill2":
                    print(CharaNoPlayer);
                    if (_isSkill[CharaNo, 1])
                    {
                        //スキルをリストから削除
                        _skillList.Remove(_selectCharacterList[CharaNoPlayer].GetSkill2());
                        //減らしたテストSPを元に戻す
                        _testSp = _testSp + _selectCharacterList[CharaNoPlayer].GetSkill2()[3];
                        _isSkill[CharaNo, 1] = false;
                        print(_testSp);
                        print("解除されましたスキル２");
                    }
                    //現在のテストSPと選択されたキャラのスキル２の消費SPを比較して足りていれば使用を許可
                    else if (_testSp >= _selectCharacterList[CharaNoPlayer].GetSkill2()[3])
                    {
                        print("ターゲットを選んでくださいスキル２");
                        //ここにターゲットを入れるための処理
                        _triggerIcon._targetSkill = true;
                        //ターゲットが決まり次第作動
                        await UniTask.WaitUntil(() => _triggerIcon._targetSkillSet);
                        _triggerIcon._targetSkill = false;
                        _triggerIcon._targetSkillSet = false;
                        //選択済のスキルのターゲットを格納
                        _selectCharacterList[CharaNoPlayer].GetSkill2()[8] = _triggerIcon.GetCharacter();
                        _selectCharacterList[CharaNoPlayer].GetSkill2()[9] = CharaNo;
                        //スキルをリストに格納
                        _skillList.Add(_selectCharacterList[CharaNoPlayer].GetSkill2());
                        //テストSPを減少
                        _testSp = _testSp - _selectCharacterList[CharaNoPlayer].GetSkill2()[3];
                        _isSkill[CharaNo, 1] = true;
                        print(_testSp);
                        //_stay = false;
                    }
                    break;
                case "skill3":
                    print(CharaNoPlayer);
                    if (_isSkill[CharaNo, 2])
                    {
                        //スキルをリストから削除
                        _skillList.Remove(_selectCharacterList[CharaNoPlayer].GetSkill3());
                        //減らしたテストSPを元に戻す
                        _testSp = _testSp + _selectCharacterList[CharaNoPlayer].GetSkill3()[3];
                        _isSkill[CharaNo, 2] = false;
                        print("解除されましたスキル３");
                    }
                    //現在のテストSPと選択されたキャラのスキル３の消費SPを比較して足りていれば使用を許可
                    else if (_testSp >= _selectCharacterList[CharaNoPlayer].GetSkill3()[3])
                    {
                        print("ターゲットを選んでくださいスキル３");
                        //ここにターゲットを入れるための処理
                        _triggerIcon._targetSkill = true;
                        //ターゲットが決まり次第作動
                        await UniTask.WaitUntil(() => _triggerIcon._targetSkillSet);
                        _triggerIcon._targetSkill = false;
                        _triggerIcon._targetSkillSet = false;
                        //選択済のスキルのターゲットを格納
                        _selectCharacterList[CharaNoPlayer].GetSkill3()[8] = _triggerIcon.GetCharacter();
                        _selectCharacterList[CharaNoPlayer].GetSkill3()[9] = CharaNo;
                        //スキルをリストに格納
                        _skillList.Add(_selectCharacterList[CharaNoPlayer].GetSkill3());
                        //テストSPを減少
                        _testSp = _testSp - _selectCharacterList[CharaNoPlayer].GetSkill3()[3];
                        _isSkill[CharaNo, 2] = true;
                        print(_testSp);
                        //_stay = false;
                    }
                    break;
            }
            ButtonColor(CharaNo);
            _stay = false;
        }
    }
}
