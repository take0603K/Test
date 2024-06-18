using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    //[SerializeField] GameObject playerObj;
    Damage Damage;
   [Header("�G��HP������")] [SerializeField]int _enemyHp = 500;
    private void OnTriggerEnter2D(Collider2D collision)
    {
      //�v���C���[�̍U�������������ۂɂ��̕���̍U���͂��Q�Ƃ���HP�����炷
        if (collision.gameObject.CompareTag("PlayerWeapon"))
        {
            Damage = collision.gameObject.GetComponent<Damage>();
            int damage = Damage._Damage;
            _enemyHp = _enemyHp - damage;
            print(_enemyHp);

            //Hp��0����������珈��������f�X�g���C�̓e�X�g
            if(_enemyHp<=0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
