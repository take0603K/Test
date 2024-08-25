using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class ListSort : MonoBehaviour
//{
//    [SerializeField] private AudioSource _audioSource;
//    [SerializeField] private AudioClip _skillSe;

//    private List<int[]> _skillSort=new List<int[]>();

//    private int _wait2Player = 0;

//    [Header("まだ未完成")][SerializeField]SkillData _skillData;
//    // Start is called before the first frame update
//    private void Start()
//    {
//        _audioSource = GetComponent<AudioSource>();
//    }
//    public void MergeList(List<int[]> SKillList)
//    {
//        //二人のプレイヤー分のスキルをマージする
//        _skillSort.AddRange(SKillList);
//        print(_skillSort.Count + "ソート内の数");
//        _wait2Player++;
//        if (_wait2Player == 2)
//        {
//            _wait2Player = 0;
//            SpeedSort();
//        }
//    }
//    private void SpeedSort()
//    {
//        //スキルの速度値が高い順に並べなおす
//       //コピーを取っておく
//        List<int[]> skillList = new List<int[]>(_skillSort);
//        print(skillList.Count + "スキル個数");
//        _skillSort.Clear();
//        print(skillList.Count+"スキル個数") ;
//        int max;
//        int maxIndex;
//        bool isdarw=false;
//        //速度被りを格納するリスト
//        List<int>maxDarw = new List<int>();
//        for(int i=0;i<=skillList.Count-1;i++)
//        {
//            max = skillList[i][2];
//            maxIndex = i;
//            for(int j=i+1;j<=skillList.Count-1;j++)
//            {
//                if (max < skillList[j][2])
//                {
//                    max = skillList[j][2];
//                    maxIndex = j;
//                    //同速度のスキルリストを初期化
//                    maxDarw.Clear();
//                    maxDarw.Add(j);
//                    isdarw = false;
//                }
//                else if (max == skillList[j][2])
//                {
//                    //同速度のスキルが入ったときにその番号を保存しておく
//                    maxDarw.Add(j);
//                    isdarw = true;
//                }
//            }
//            //もし同速度のスキルがあればランダムに並べなおす
//            if (isdarw)
//            {
//                while (maxDarw.Count > 0)
//                {
//                    int no = maxDarw.GetAndRemoveAtRandom();
//                    _skillSort.Add(skillList[no]);
//                }         
//            }
//            //なければそのまま追加する
//            else
//            {
//                _skillSort.Add(skillList[maxIndex]);
//            }
//            isdarw=false;
//        }
//        Skill();
//    }
//    private async　void Skill()
//    {
//        print("実行");
//        //なぜかスキルソートが0！！！！
//        //速度順に並び替えられたリストを一つずつ実行していく
//        int[] skill;
//        while(_skillSort.Count>0)
//        {
//            print("実行2");
//            //とりあえず三秒ごとに実行していく
//            _audioSource.PlayOneShot(_skillSe);
//            await UniTask.Delay(TimeSpan.FromSeconds(3f));
//            print("実行3");
//            //実行後リストから排除
//            skill = _skillSort.Dequeue();
//            _skillData.Skill(skill);
//        }
//    }
   
//}
