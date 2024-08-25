using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//public class GameProgress : MonoBehaviour
//{
//    [Header("最終ターン")][SerializeField] private int _lastTurn = 10;
//    [Header("ターン管理テキスト")] [SerializeField] private TextMeshProUGUI _turnText;


//    //SPを配布するために使う
//    [Header("プレイヤー１")][SerializeField] private GameObject _player1 = default;
//    [Header("プレイヤー２")][SerializeField] private GameObject _player2 = default;
//    [Header("プレイヤー１")][SerializeField] PlayerSp _classPlayerSp1;
//    [Header("プレイヤー２")][SerializeField] PlayerSp _classPlayerSp2;
//    //リストを格納
//    [Header("プレイヤー１")][SerializeField] ListCharacter _listCharaP1;
//    [Header("プレイヤー２")][SerializeField] ListCharacter _listCharaP2;
//    //キャラクターのステータス状態を格納
//    [Header("キャラクターステータス")][SerializeField] StateCharacter _stateCharacter;

//    private bool _awaitSKil = default;
//    //プレイヤーを待つ
//    private int _awaitPlayer = default;
//    //public bool getAwaitSkill
//    //{
//    //    get { return _awaitSKil; } 
//    //    set {  _awaitSKil = value; }
//    //}
//    void Start()
//    {
//        //ゲームが始まったら初期Spを配布してゲームコントロールを呼ぶ
//        _classPlayerSp1 = _player1.GetComponent<PlayerSp>();
//        _classPlayerSp2 = _player2.GetComponent<PlayerSp>();
//        _listCharaP1=_player1.GetComponent<ListCharacter>();
//        _listCharaP2=_player2.GetComponent<ListCharacter>();
       
//        GameControl(1,_lastTurn);
//        _listCharaP1.CharacterSet();
//        _listCharaP2.CharacterSet();

//        //キャラクターステータスの管理
//        _stateCharacter.StartStateSet();
//    }
//    public void WaitPlayer()
//    {
//        //ボタンが押されるとカウントが進む
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

//            //スキルの選択を待つ
//            await UniTask.WaitUntil(() => _awaitSKil);
//            _awaitSKil = false;
//            //最終的なSPを確定する
//            int sp1 = _listCharaP1.ReturnSP();
//            int sp2 = _listCharaP2.ReturnSP();
//            _classPlayerSp1.SpManager(sp1);
//            _classPlayerSp2.SpManager(sp2);
//            //リストの並び替えを呼び出す
//            _listCharaP1.SortList();
//            _listCharaP2.SortList();
//            turn = turn + 1;
//        }
//        _turnText.text = "DorwGame";

//    }
//}
