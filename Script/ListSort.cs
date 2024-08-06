using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ListSort : MonoBehaviour
{
    private List<int[]> _skillSort=new List<int[]>();

    private int _wait2Player = 0;

    [SerializeField]SkillData _skillData;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void SpeedSort(List<int[]> List)
    {
        //�X�L���̑��x�l���������ɕ��ׂȂ���
        print(List.Count);
        int max;
        int maxIndex;
        bool isdarw=false;
        //���x�����i�[���郊�X�g
        List<int>maxDarw = new List<int>();
        for(int i=0;i<=List.Count-1;i++)
        {
            max = List[i][2];
            maxIndex = i;
            for(int j=i+1;j<=List.Count-1;j++)
            {
                if (max < List[i][2])
                {
                    max = List[i][2];
                    maxIndex = i;
                    //�����x�̃X�L�����X�g��������
                    maxDarw.Clear();
                    maxDarw.Add(i);
                    isdarw = false;
                }
                else if (max == List[i][2])
                {
                    //�����x�̃X�L�����������Ƃ��ɂ��̔ԍ���ۑ����Ă���
                    maxDarw.Add(i);
                    isdarw = true;
                }
            }
            //���������x�̃X�L��������΃����_���ɕ��ׂȂ���
            if (isdarw)
            {
                while (maxDarw.Count > 0)
                {
                    int no = maxDarw.GetAndRemoveAtRandom();
                    _skillSort.Add(List[no]);
                }         
            }
            //�Ȃ���΂��̂܂ܒǉ�����
            else
            {
                _skillSort.Add(List[maxIndex]);
            }
        }
        Skill();
    }
    private void Skill()
    {
        //���x���ɕ��ёւ���ꂽ���X�g��������s���Ă���
        int[] skill;
        while(_skillSort.Count>0)
        {
            skill = _skillSort.Dequeue();
            _skillData.Skill(skill);
        }
    }
    public void MergeList(List<int[]>SKillList)
    {
        _skillSort.AddRange(SKillList);
        _wait2Player++;
        if(_wait2Player==2)
        {
            _wait2Player = 0;
            SpeedSort(_skillSort);
        }
    }
}
