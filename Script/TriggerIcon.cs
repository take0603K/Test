using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;

public class TriggerIcon : MonoBehaviour
{
    //�{�^�����O�i�[���ꂽ�Q�[���I�u�W�F�N�g���i�[
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
        //�{�^���������Ă�I�u�W�F���\���ɂ���
        _skill.SetActive(false);
    }
    public void CharacterClick(string CharacterBotton)
    {
        //�L�����N�^�[�̃A�C�R���������ꂽ��X�L���{�^���\��
        //�O�ɉ����ꂽ�{�^�����\����
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
            print("�^�[�Q�b�g����");
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
                print("�Ώۂ��I�΂�܂���1");
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
                print("�Ώۂ��I�΂�܂���2");
            }
            _listChara.ButtonColor(_character);
        }      
    }
}
