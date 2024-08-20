using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;

public class TriggerIcon : MonoBehaviour
{
    //ボタンが三つ格納されたゲームオブジェクトを格納
    [SerializeField] private GameObject _skill = default(GameObject);
    [SerializeField] private ListCharacter _listChara = new ListCharacter();
    [SerializeField] private int _skillIndex = default;
    [SerializeField] private int _character = 0;
    [SerializeField] private bool _isPlayer=false;

    public bool _targetSkill = false;
    public bool _targetSkillSet = false;
    public int GetCharacter()
    { 
        return _character; 
    }
    private void Start()
    {
        //ボタンが入ってるオブジェを非表示にする
        _skill.SetActive(false);
    }
    public void CharacterClick(string CharacterBotton)
    {
        //キャラクターのアイコンが押されたらスキルボタン表示
        //前に押されたボタンを非表示に
        if (_targetSkill)
        {
            switch (CharacterBotton)
            {
                case "CP1":
                    _character = 0;
                    break;
                case "CP2":
                    _character = 1;
                    break;
                case "CP3":
                    _character = 2;
                    break;
                case "CP4":
                    _character = 3;
                    break;
                case "CP5":
                    _character = 4;
                    break;
                case "CE1":
                    _character = 5;
                    break;
                case "CE2":
                    _character = 6;
                    break;
                case "CE3":
                    _character = 7;
                    break;
                case "CE4":
                    _character = 8;
                    break;
                case "CE5":
                    _character = 9;
                    break;
            }
            print("ターゲット決定");
            _targetSkillSet = true ;
        }
        else
        {
           // _skill[_skillIndex].SetActive(false);
            if (_isPlayer)
            {
                switch (CharacterBotton)
                {
                    case "CP1":
                        _skill.SetActive(true);
                        _skillIndex = 0;
                        _character = 0;
                        break;
                    case "CP2":
                        _skill.SetActive(true);
                        _skillIndex = 0;
                        _character = 1;
                        break;
                    case "CP3":
                        _skill.SetActive(true);
                        _skillIndex = 0;
                        _character = 2;
                        break;
                    case "CP4":
                        _skill.SetActive(true);
                        _skillIndex = 0;
                        _character = 3;
                        break;
                    case "CP5":
                        _skill.SetActive(true);
                        _skillIndex = 0;
                        _character = 4;
                        break;
                }
                print("対象が選ばれました1");
            }
            else
            {
                switch (CharacterBotton)
                {
                    case "CE1":
                        _skill.SetActive(true);
                        _skillIndex = 1;
                        _character = 5;
                        break;
                    case "CE2":
                        _skill.SetActive(true);
                        _skillIndex = 1;
                        _character = 6;
                        break;
                    case "CE3":
                        _skill.SetActive(true);
                        _skillIndex = 1;
                        _character = 7;
                        break;
                    case "CE4":
                        _skill.SetActive(true);
                        _skillIndex = 1;
                        _character = 8;
                        break;
                    case "CE5":
                        _skill.SetActive(true);
                        _skillIndex = 1;
                        _character = 9;
                        break;
                      
                }
                print("対象が選ばれました2");
            }
            _listChara.ButtonColor(_character);
        }      
    }
}
