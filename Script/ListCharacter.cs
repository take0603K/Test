using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListCharacter : MonoBehaviour
{
    //�L�����N�^�[�f�[�^�x�[�X
    [SerializeField]
    private CharacterDataBase _characterDataBase;
    //�I�񂾃L�����N�^�[���X�g
    [SerializeField]
    private List<Character> _selectCharacterList =
        new List<Character>();

    private List<int[]> _skillList = new List<int[]>();
  

    //�I�񂾃L�����̃f�[�^�x�[�X���ł̔ԍ������̒��ɓ����
    [SerializeField] private int[] _selectCharacterNo = new int[10];

    //�f�[�^�x�[�X�̃L�����N�^�[���X�g�̓��e���R�s�[���邽�߂̊i�[�p���X�g
    [SerializeField] private List<Character> _CharacterList = default(List<Character>);

    //�L�����N�^�[�̃A�C�R��
   // [SerializeField]private Canvas _myCanvas=default(Canvas);
    [SerializeField]private Image[] _CharacterUi=new Image[5];
    // �A�N�Z�X�p
    [SerializeField]StateCharacter _stateCharacter=default(StateCharacter);
    [SerializeField]TriggerIcon _triggerIcon=default(TriggerIcon);
    [SerializeField]ListSort _listSort=default(ListSort);
    //�I�𒆃X�L��
    private bool[,] _isSkill = new bool[10,3];
    [SerializeField]private Button[] _skillButton=new Button[3];
    [SerializeField]private Sprite[] _buttonImage=new Sprite[2];
    private Image[] _sprites=new Image[3];
    private bool _stay = false;
    //���݂̎c��SP
    private int _nowSp=0;
    //�g�p���SP�i���j
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
        //�Z���N�g�����L�������i�[����
        _CharacterList = _characterDataBase.GetCharacterLists();
        for(int i=0;i<_selectCharacterNo.Length;i++)
        {
            _selectCharacterList.Add(_CharacterList[_selectCharacterNo[i]]);
            //�ܔԖڂ̃L�����܂ł��i�[����
            if(i<5)
            {
                _CharacterUi[i].GetComponent<Image>();
                _CharacterUi[i].sprite = _selectCharacterList[i].icon();
            }
          
        }
        //�{�^���̃I���I�t�Z�b�g
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
        print(_skillList + "�X�L���̐�����");
        _listSort.MergeList(_skillList);
    }
    public void ButtonColor(int CharaNo)
    {
        //�I�����ꂽ�L�����N�^�[��sy�L���ҋ@��Ԃ��{�^���ɔ��f
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
            //�P�O�̂��v���C���[��ʂȂ��ɕێ�
            //GetCharacter�͂�����int�^
            _stay = true;
            int CharaNo = _triggerIcon.GetCharacter();

            //�T�̂��v���C���[����ʂ��ĕێ�
            int CharaNoPlayer = CharaNo;
            if (CharaNo >= 5)
            {
                CharaNoPlayer = CharaNo - 5;
            }
            //�����Ń{�^���̐F���m�F����
            ButtonColor(CharaNo);
            switch (selectSKill)
            {
                //_isSkill��bool�̓񎟌��z��
                case "skill1":
                    print(CharaNoPlayer);
                    if (_isSkill[CharaNo, 0])
                    {
                        //�X�L�������X�g����폜
                        _skillList.Remove(_selectCharacterList[CharaNoPlayer].GetSkill());
                        //���炵���e�X�gSP�����ɖ߂�
                        _testSp = _testSp + _selectCharacterList[CharaNoPlayer].GetSkill()[3];
                        _isSkill[CharaNo, 0] = false;
                        print(_testSp);
                        print("��������܂����X�L���P");
                        
                        
                    }
                    //���݂̃e�X�gSP�ƑI�����ꂽ�L�����̃X�L���P�̏���SP���r���đ���Ă���Ύg�p������
                    else if (_testSp >= _selectCharacterList[CharaNoPlayer].GetSkill()[3])
                    {
                        print("�^�[�Q�b�g��I��ł��������X�L���P");
                        //�����Ƀ^�[�Q�b�g�����邽�߂̏���
                        _triggerIcon._targetSkill = true;
                        //�^�[�Q�b�g�����܂莟��쓮
                        await UniTask.WaitUntil(() => _triggerIcon._targetSkillSet);
                        _triggerIcon._targetSkill = false;
                        _triggerIcon._targetSkillSet = false;
                        //�I���ς̃X�L���̃^�[�Q�b�g���i�[
                        _selectCharacterList[CharaNoPlayer].GetSkill()[8] = _triggerIcon.GetCharacter();
                        _selectCharacterList[CharaNoPlayer].GetSkill()[9] = CharaNo;
                        //�X�L�������X�g�Ɋi�[
                        _skillList.Add(_selectCharacterList[CharaNoPlayer].GetSkill());
                        //�e�X�gSP������
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
                        //�X�L�������X�g����폜
                        _skillList.Remove(_selectCharacterList[CharaNoPlayer].GetSkill2());
                        //���炵���e�X�gSP�����ɖ߂�
                        _testSp = _testSp + _selectCharacterList[CharaNoPlayer].GetSkill2()[3];
                        _isSkill[CharaNo, 1] = false;
                        print(_testSp);
                        print("��������܂����X�L���Q");
                    }
                    //���݂̃e�X�gSP�ƑI�����ꂽ�L�����̃X�L���Q�̏���SP���r���đ���Ă���Ύg�p������
                    else if (_testSp >= _selectCharacterList[CharaNoPlayer].GetSkill2()[3])
                    {
                        print("�^�[�Q�b�g��I��ł��������X�L���Q");
                        //�����Ƀ^�[�Q�b�g�����邽�߂̏���
                        _triggerIcon._targetSkill = true;
                        //�^�[�Q�b�g�����܂莟��쓮
                        await UniTask.WaitUntil(() => _triggerIcon._targetSkillSet);
                        _triggerIcon._targetSkill = false;
                        _triggerIcon._targetSkillSet = false;
                        //�I���ς̃X�L���̃^�[�Q�b�g���i�[
                        _selectCharacterList[CharaNoPlayer].GetSkill2()[8] = _triggerIcon.GetCharacter();
                        _selectCharacterList[CharaNoPlayer].GetSkill2()[9] = CharaNo;
                        //�X�L�������X�g�Ɋi�[
                        _skillList.Add(_selectCharacterList[CharaNoPlayer].GetSkill2());
                        //�e�X�gSP������
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
                        //�X�L�������X�g����폜
                        _skillList.Remove(_selectCharacterList[CharaNoPlayer].GetSkill3());
                        //���炵���e�X�gSP�����ɖ߂�
                        _testSp = _testSp + _selectCharacterList[CharaNoPlayer].GetSkill3()[3];
                        _isSkill[CharaNo, 2] = false;
                        print("��������܂����X�L���R");
                    }
                    //���݂̃e�X�gSP�ƑI�����ꂽ�L�����̃X�L���R�̏���SP���r���đ���Ă���Ύg�p������
                    else if (_testSp >= _selectCharacterList[CharaNoPlayer].GetSkill3()[3])
                    {
                        print("�^�[�Q�b�g��I��ł��������X�L���R");
                        //�����Ƀ^�[�Q�b�g�����邽�߂̏���
                        _triggerIcon._targetSkill = true;
                        //�^�[�Q�b�g�����܂莟��쓮
                        await UniTask.WaitUntil(() => _triggerIcon._targetSkillSet);
                        _triggerIcon._targetSkill = false;
                        _triggerIcon._targetSkillSet = false;
                        //�I���ς̃X�L���̃^�[�Q�b�g���i�[
                        _selectCharacterList[CharaNoPlayer].GetSkill3()[8] = _triggerIcon.GetCharacter();
                        _selectCharacterList[CharaNoPlayer].GetSkill3()[9] = CharaNo;
                        //�X�L�������X�g�Ɋi�[
                        _skillList.Add(_selectCharacterList[CharaNoPlayer].GetSkill3());
                        //�e�X�gSP������
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
