using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //[SerializeField]
    //private List<SubWeapon.WeaponSelect> _itemBoxList =
    //   new List<SubWeapon.WeaponSelect>();
    [SerializeField] public SubWeapon.WeaponSelect[]_inventory = { 0, (SubWeapon.WeaponSelect)(int)1,0 };
    private int _maxIndex = 2;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    //List<SubWeapon.WeaponSelect>
    //List<SubWeapon.WeaponSelect> selects,int weaponNo
    //SubWeapon.WeaponSelect.aaaa
    public void InventBox(SubWeapon.WeaponSelect select)
    {
        print(select);
        for (int i = 0; i<=_maxIndex; i++)
        {
            if (_inventory[i]==0)
            {
                _inventory[i] = select;
                break;
            }
        }
        print("ŒðŠ·‚µ‚È‚³‚¢");
    }

    //internal void InventBox(SubWeapon.WeaponSelect weaponSelect, int item)
    //{
    //    print(weaponSelect);
    //    throw new NotImplementedException();
    //}
}
