using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    Test11,
    Test12,
    Test13,
    Test14,
    Test15,
}
public enum CharacterGroup
{
    Guardian,//���
    Gambling,//�q��
    Resonance,//����
    Onslaught,//�ҍU
    Counterattack,//�t�P
    Prayer,//�F��
    Blessing,//�j��
    Decay,//���H
}
public enum CharacterBattleStyle
{
    Guardian,//���
    Gambling,//�q��
    Resonance,//����
    Onslaught,//�ҍU
    Counterattack,//�t�P
    Prayer,//�F��
    Blessing,//�j��
    Decay,//���H
}

[CreateAssetMenu(fileName = "Character", menuName = "CreateCharacter")]
public class Character : ScriptableObject
{
    [Header("Item Properties")]
    [SerializeField]private string CharacterJpName;    // �L�����N�^�[�̊Ǘ��p�̖��O
    [SerializeField]private Sprite _icon;     // �L�����N�^�[�̂̃A�C�R���摜
   
    public CharacterEnum CharacterName;  // �L�����N�^�[�̖��O
    public CharacterGroup group;//�L�����N�^�[�̏���
    public CharacterBattleStyle battleStyle;//�L�����N�^�[�̐�p

    [SerializeField]private int Hp;//�L�����N�^�[��Hp
  
    [SerializeField]private int Attack;//�L�����N�^�[�̍U����

    

    [Header("�X�L���֐��i���o�[�E����SP�E���x�E���ʒl�E�ǉ��X�L���i���o�[�E���ʒl�E�^�[�Q�b�g")]
    [SerializeField] private int[] Skill1 = new int[7];
    [SerializeField] private int[] Skill2 = new int[7];
    [SerializeField] private int[] Skill3 = new int[7];
    //�C���X�y�N�^�[��ɓ񎟌��ȏ�̔z���\������ɂ͂�����Ƃ����H�v���K�v�炵��


    [TextArea]
    public string characterText; // �L�����N�^�[�̐���
    // �����ɕK�v�ɉ����ă��\�b�h��ǉ��̃v���p�e�B���`�ł��܂�
    public Sprite icon()
    {
        return _icon;
    }
    public int GetHp()
    {
        return Hp;
    }
    public int GetAttack()
    {
        return Attack;
    }
    public int[] GetSkill()
    {
        return Skill1;
    }
    public int[] GetSkill2()
    {
        return Skill2;
    }
    public int[] GetSkill3()
    {
        return Skill3;
    }
}