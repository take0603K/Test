using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//public class GameProgress : MonoBehaviour
//{
//    [Header("�ŏI�^�[��")][SerializeField] private int _lastTurn = 10;
//    [Header("�^�[���Ǘ��e�L�X�g")] [SerializeField] private TextMeshProUGUI _turnText;


//    //SP��z�z���邽�߂Ɏg��
//    [Header("�v���C���[�P")][SerializeField] private GameObject _player1 = default;
//    [Header("�v���C���[�Q")][SerializeField] private GameObject _player2 = default;
//    [Header("�v���C���[�P")][SerializeField] PlayerSp _classPlayerSp1;
//    [Header("�v���C���[�Q")][SerializeField] PlayerSp _classPlayerSp2;
//    //���X�g���i�[
//    [Header("�v���C���[�P")][SerializeField] ListCharacter _listCharaP1;
//    [Header("�v���C���[�Q")][SerializeField] ListCharacter _listCharaP2;
//    //�L�����N�^�[�̃X�e�[�^�X��Ԃ��i�[
//    [Header("�L�����N�^�[�X�e�[�^�X")][SerializeField] StateCharacter _stateCharacter;

//    private bool _awaitSKil = default;
//    //�v���C���[��҂�
//    private int _awaitPlayer = default;
//    //public bool getAwaitSkill
//    //{
//    //    get { return _awaitSKil; } 
//    //    set {  _awaitSKil = value; }
//    //}
//    void Start()
//    {
//        //�Q�[�����n�܂����珉��Sp��z�z���ăQ�[���R���g���[�����Ă�
//        _classPlayerSp1 = _player1.GetComponent<PlayerSp>();
//        _classPlayerSp2 = _player2.GetComponent<PlayerSp>();
//        _listCharaP1=_player1.GetComponent<ListCharacter>();
//        _listCharaP2=_player2.GetComponent<ListCharacter>();
       
//        GameControl(1,_lastTurn);
//        _listCharaP1.CharacterSet();
//        _listCharaP2.CharacterSet();

//        //�L�����N�^�[�X�e�[�^�X�̊Ǘ�
//        _stateCharacter.StartStateSet();
//    }
//    public void WaitPlayer()
//    {
//        //�{�^�����������ƃJ�E���g���i��
//        _awaitPlayer++;
//        if(_awaitPlayer==1)
//        {
//            _awaitPlayer = 0;
//            _awaitSKil = true;
//        }
//    }

//    private async void GameControl(int turn,int lastTurn)
//    {
//        while(turn<=lastTurn)
//        {
//            _turnText.text = "Turn" + turn;
//            _classPlayerSp1.SpManagement(turn);
//            _classPlayerSp2.SpManagement(turn);

//            //�X�L���̑I����҂�
//            await UniTask.WaitUntil(() => _awaitSKil);
//            _awaitSKil = false;
//            //�ŏI�I��SP���m�肷��
//            int sp1 = _listCharaP1.ReturnSP();
//            int sp2 = _listCharaP2.ReturnSP();
//            _classPlayerSp1.SpManager(sp1);
//            _classPlayerSp2.SpManager(sp2);
//            //���X�g�̕��ёւ����Ăяo��
//            _listCharaP1.SortList();
//            _listCharaP2.SortList();
//            turn = turn + 1;
//        }
//        _turnText.text = "DorwGame";

//    }
//}
