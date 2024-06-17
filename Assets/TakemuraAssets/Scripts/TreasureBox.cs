using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureBox : MonoBehaviour
{
    [SerializeField] private GameObject _Invent = null;
    [SerializeField] private GameObject _player = null;
    [SerializeField] private List<Inventory.WeaponSelect> _itemBoxList =
        new List<Inventory.WeaponSelect>();
    [SerializeField] private int _item = 0;
    public bool _openBox = default;

    Inventory _inventorycs;
    SubWeapon _subWeapon;
    private bool _isCnt = default;
    //�C���x���g���̔z��[0]���P�̓\�[�h���i�[
    //public int[] _inventory = { 1, 0, 0 };
    //[SerializeField] int item = default;
    private void Start()
    {
        _subWeapon = _player.GetComponent<SubWeapon>();
        _inventorycs = _player.GetComponent<Inventory>();
    }

    void Update()
    {
        if(_openBox)
        {
            WeaponGet();
        }
    }

    private void WeaponGet()
    {
       
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(_isCnt)
            {
                print("�󔠕���");
                _isCnt = false;
                _subWeapon._isOpenBox = false;
                _openBox = false;
            }
          else
            {
                _isCnt = true;
            }
        }
        //�I�ԃI�u�W�F�N�g���E��
        if (Input.GetKeyDown(KeyCode.R))
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
        if (Input.GetKeyDown(KeyCode.L))
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
            _inventorycs = _Invent.GetComponent<Inventory>();
            _inventorycs.InventBox(_itemBoxList[_item]);
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")&&!_openBox)
        {
        
            if(!_openBox)
            {
                if (Input.GetKey(KeyCode.F))
                {
                    print("�󔠊J��");
                    _openBox = true;
                    _subWeapon._isOpenBox = true;
                }
            }                    
        }
        /*�󔠂̃I�u�W�F�N�g�Ƀv���C���[���G��Ă����
         * �󔠂��J���邩�ǂ������󂯕t����
         * �����J�����ꍇ_openBox��^�ɂ�
         * �A�b�v�f�[�g�����Ăяo��
         */
    }
}
