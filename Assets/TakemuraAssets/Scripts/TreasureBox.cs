using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treasureBox : MonoBehaviour
{
    [SerializeField] private GameObject _Invent = null;
    [SerializeField] private List<Inventory.WeaponSelect> _itemBoxList =
        new List<Inventory.WeaponSelect>();
    [SerializeField] private int _item = 0;
    private bool _openBox = default;

    Inventory inventorycs;
    //�C���x���g���̔z��[0]���P�̓\�[�h���i�[
    //public int[] _inventory = { 1, 0, 0 };
    //[SerializeField] int item = default;

    void Update()
    {
        if(_openBox)
        {
            WeaponGet();
        }
    }

    private void WeaponGet()
    {
        //�I�ԃI�u�W�F�N�g���E��
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (_item == _itemBoxList.Count-1)
            {
                _item = 0;
            }
            else
            {
                _item = _item+1;
            }
        }
        //�I�ԃI�u�W�F�N�g������
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (_item == 0)
            {
                _item = _itemBoxList.Count-1;
            }
            else
            {
                _item = _item-1;
            }
        }
        //�I�𒆂̕�����C���x���g���ɓ����悤��
        if (Input.GetKeyDown(KeyCode.G))
        {
            inventorycs = _Invent.GetComponent<Inventory>();
            inventorycs.InventBox(_itemBoxList[_item]);
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")&&!_openBox)
        {     
                if (Input.GetKey(KeyCode.F))
                {
                    print("��");
                    print(_itemBoxList.Count);
                    _openBox = true;
                }                     
        }
        /*�󔠂̃I�u�W�F�N�g�Ƀv���C���[���G��Ă����
         * �󔠂��J���邩�ǂ������󂯕t����
         * �����J�����ꍇ_openBox��^�ɂ�
         * �A�b�v�f�[�g�����Ăяo��
         */
    }
}
