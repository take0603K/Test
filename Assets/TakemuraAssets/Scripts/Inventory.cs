using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //�v���C���[�ɂ��Ă����N���X
    /// <summary>
    /// ���킲�ƂɐU��ꂽ�ŗL�ԍ��Ǘ��p��Enum
    /// </summary>
    public enum WeaponSelect
    {
        nasi = 0,
        Kunai = 1,
        _boomerang = 2,
        kamaitachi = 3,
    }
    [Header("���݂̃C���x���g�����")]public WeaponSelect[]_inventory = { 0,0,0 };
    [Header("�C���x���g���z��̂̍Ō��")] public int _maxIndex = 2;
    public void InventBox(WeaponSelect select)
    {
        //�g�����邩�̊m�F�ϐ��i���ł͕K�v�Ȃ��j
        int itemCnt = 0;
        //����I�΂ꂽ����
        print(select);

        //�z��̈�ԍŌ�܂Ŕ�r���J��Ԃ�
        for (int i = 0; i<=_maxIndex; i++)
        {
            itemCnt++;
            //�C���x���g������������͊��ɕ�����������Ă����炻���ɕ�����i�[
            if (_inventory[i]==0||_inventory[i]==select)
            {
                _inventory[i] = select;
                break;
            }
        }
        //�C���x���g���ɋ󂫂��Ȃ������ꍇ�����������Ăяo��
        //�܂������������łɉe���Ȃ�
        if(itemCnt<=_maxIndex)
        {
            print("�������Ȃ���");
        }
     
    }
}
