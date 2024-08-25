using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//�L�����N�^�[��\���񋓌^
public enum CharacterEnum
{
    Test1,
    Test2,
    Test3,
    Test4,
    Test5,
    Test6,
    Test7,
    Test8,
    Test9,
    Test10,
}
public enum CharacterLevel
{
    mongrelEnemy,//�G���G
    eliteEnemy,//���s
    bossEnemy,//�{�X
}

[CreateAssetMenu(fileName = "Enemy", menuName = "CreateEnemy")]
public class Character : ScriptableObject
{
    [SerializeField]private string _characterJpName;    // �L�����N�^�[�̊Ǘ��p�̖��O
    [SerializeField]private Sprite _icon;     // �L�����N�^�[�̂̃A�C�R���摜
   
    [SerializeField]private CharacterEnum _enemyName;  // �L�����N�^�[�̖��O
    [SerializeField]private CharacterLevel _group;//�L�����N�^�[�̏���

    [SerializeField]private int Hp;//�L�����N�^�[��Hp
    [SerializeField]private GameObject _enemy;//�I�u�W�F�N�g

    [TextArea]
    public string _characterText; // �L�����N�^�[�̐���
    // �����ɕK�v�ɉ����ă��\�b�h��ǉ��̃v���p�e�B���`�ł��܂�
    public GameObject enemy()
    {
        return _enemy;
    }
    public int GetHp()
    {
        return Hp;
    }
    public CharacterLevel GetGroup()
    { 
        return _group;
    }
}