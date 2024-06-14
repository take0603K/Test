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
    //インベントリの配列[0]＝１はソードを格納
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
        //選ぶオブジェクトを右に
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
        //選ぶオブジェクトを左に
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
        //選択中の武器をインベントリに入れるように
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
                    print("宝箱");
                    print(_itemBoxList.Count);
                    _openBox = true;
                }                     
        }
        /*宝箱のオブジェクトにプレイヤーが触れている間
         * 宝箱を開けるかどうかを受け付ける
         * もし開けた場合_openBoxを真にし
         * アップデート文を呼び出す
         */
    }
}
