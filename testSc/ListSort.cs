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

//    [Header("�܂�������")][SerializeField]SkillData _skillData;
//    // Start is called before the first frame update
//    private void Start()
//    {
//        _audioSource = GetComponent<AudioSource>();
//    }
//    public void MergeList(List<int[]> SKillList)
//    {
//        //��l�̃v���C���[���̃X�L�����}�[�W����
//        _skillSort.AddRange(SKillList);
//        print(_skillSort.Count + "�\�[�g���̐�");
//        _wait2Player++;
//        if (_wait2Player == 2)
//        {
//            _wait2Player = 0;
//            SpeedSort();
//        }
//    }
//    private void SpeedSort()
//    {
//        //�X�L���̑��x�l���������ɕ��ׂȂ���
//       //�R�s�[������Ă���
//        List<int[]> skillList = new List<int[]>(_skillSort);
//        print(skillList.Count + "�X�L����");
//        _skillSort.Clear();
//        print(skillList.Count+"�X�L����") ;
//        int max;
//        int maxIndex;
//        bool isdarw=false;
//        //���x�����i�[���郊�X�g
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
//                    //�����x�̃X�L�����X�g��������
//                    maxDarw.Clear();
//                    maxDarw.Add(j);
//                    isdarw = false;
//                }
//                else if (max == skillList[j][2])
//                {
//                    //�����x�̃X�L�����������Ƃ��ɂ��̔ԍ���ۑ����Ă���
//                    maxDarw.Add(j);
//                    isdarw = true;
//                }
//            }
//            //���������x�̃X�L��������΃����_���ɕ��ׂȂ���
//            if (isdarw)
//            {
//                while (maxDarw.Count > 0)
//                {
//                    int no = maxDarw.GetAndRemoveAtRandom();
//                    _skillSort.Add(skillList[no]);
//                }         
//            }
//            //�Ȃ���΂��̂܂ܒǉ�����
//            else
//            {
//                _skillSort.Add(skillList[maxIndex]);
//            }
//            isdarw=false;
//        }
//        Skill();
//    }
//    private async�@void Skill()
//    {
//        print("���s");
//        //�Ȃ����X�L���\�[�g��0�I�I�I�I
//        //���x���ɕ��ёւ���ꂽ���X�g��������s���Ă���
//        int[] skill;
//        while(_skillSort.Count>0)
//        {
//            print("���s2");
//            //�Ƃ肠�����O�b���ƂɎ��s���Ă���
//            _audioSource.PlayOneShot(_skillSe);
//            await UniTask.Delay(TimeSpan.FromSeconds(3f));
//            print("���s3");
//            //���s�ナ�X�g����r��
//            skill = _skillSort.Dequeue();
//            _skillData.Skill(skill);
//        }
//    }
   
//}
