using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //�v���C���[�ɂ��Ă����N���X
    public enum WeaponSelect
    {
        nasi = 0,
        Kunai = 1,
        _boomerang = 2,
        kamaitachi = 3,
    }
    //[SerializeField]
    //private List<SubWeapon.WeaponSelect> _itemBoxList =
    //   new List<SubWeapon.WeaponSelect>();
    [SerializeField] public WeaponSelect[]_inventory = { 0,0,0 };
    public int _maxIndex = 2;
  
    //List<SubWeapon.WeaponSelect>
    //List<SubWeapon.WeaponSelect> selects,int weaponNo
    //SubWeapon.WeaponSelect.aaaa
    public void InventBox(WeaponSelect select)
    {
        int itemCnt = 0;
        print(select);
        for (int i = 0; i<=_maxIndex; i++)
        {
            itemCnt++;
            if (_inventory[i]==0)
            {
                _inventory[i] = select;
                break;
            }
        }
        //�C���x���g���ɋ󂫂��Ȃ������ꍇ�����������Ăяo��
        if(itemCnt<=_maxIndex)
        {
            print("�������Ȃ���");
        }
     
    }

    //internal void InventBox(SubWeapon.WeaponSelect weaponSelect, int item)
    //{
    //    print(weaponSelect);
    //    throw new NotImplementedException();
    //}
}
