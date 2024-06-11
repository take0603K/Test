using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SubWeapon : MonoBehaviour
{
    //   if (Input.GetKeyDown(KeyCode.E))�̏������R���g���[���[�̃X�L�������L�[�ɒu�������āI�I�I
    /// <summary>
    /// ���킲�ƂɐU��ꂽ�ŗL�ԍ��Ǘ��p��Enum
    /// </summary>
    public enum WeaponSelect
    {
        Sword=0,
        Kunai=1,
        Boomerang=2,
        kamaitachi=3,
    }
    //�N�i�C�p
    //�v���C���[�ʒu�ƃN�i�C�I�u�W�F
    [Header("�v���C���[����Ă�")][SerializeField] GameObject player = null;
    [SerializeField] GameObject kunai = null;
 
    Rigidbody2D kunaiRd;

    //�u�[�������p

    [SerializeField] GameObject boomerang = null;
    [SerializeField] GameObject boomerangTraget = null;
    private float boomerangSpeed = 15f;
    private Vector3 _boomerangPos;

    private  bool _existsBoomerang = default;
    private  bool _shouldBoomerangRe = default;
    private  bool _canReturn = default;
    //���܂������p

    [SerializeField] GameObject kamaitachi = null;

    //����

    private Vector2 _playerPos;
    PrayerC playerScript;
    public int _damage=0;
    public WeaponSelect _weaponSelect=0;
  
  
    void Start()
    {
        _playerPos = player.transform.position;
        kunai.transform.position = _playerPos;
        playerScript = player.GetComponent<PrayerC>();
        _weaponSelect = 0;


        boomerang.SetActive(false);
        kamaitachi.SetActive(false);    
    }
    void Update()
    {
      switch(_weaponSelect)
        {
            case WeaponSelect.Sword:
                break;
            case WeaponSelect.Kunai:
                KunaiWeapon();
                break;
            case WeaponSelect.Boomerang:
                BoomerangWeapon();
                break;
            case WeaponSelect.kamaitachi:
                KamaitachiWeapon();
                break;
        }
        //����̐؂�ւ�
        if (Input.GetKeyDown(KeyCode.R))
        {
         
            if ((int)_weaponSelect == 3)
            {
                print("�����Ă��");
                _weaponSelect = 0;
            }
            else
            {
                print((int)_weaponSelect);
             _weaponSelect++ ;
            }
        }
        //�u�[�������̖߂菈�����Ȃ�
        if (_existsBoomerang)
        {
            BoomerangOperation();
        }
        //�ȉ��e�X�g�p
    }
        private void KamaitachiWeapon()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(WeaponCoroutine(2, 0));
        }    
    }
    IEnumerator WeaponCoroutine(float time,int switchCor)
    {
        yield return new WaitForSeconds(time);
        switch(switchCor)  
        {
            case 0:
                kamaitachi.SetActive(true);
                yield return new WaitForSeconds (2);
                kamaitachi.SetActive (false);
                break;
            case 1:
                print("�߂�");
                boomerangSpeed = boomerangSpeed + 5;
                _shouldBoomerangRe = true;
                _canReturn = true;
                break;
            default: 
                break;
       
                //case 2:
                //    break;
                //case 3:
                //    break;
                //case 4:
                //break;
        }
    }
    private void BoomerangWeapon()
    {
        if (Input.GetKeyDown(KeyCode.E) && !_existsBoomerang)
        {
            _playerPos = player.transform.position;
            boomerang.SetActive(true);
            boomerang.transform.position = _playerPos;
            _boomerangPos = boomerangTraget.transform.position;
            _existsBoomerang = true;
            StartCoroutine(WeaponCoroutine(1.2f, 1));
        }
       
    }
    private void BoomerangOperation()
    {
        if (_shouldBoomerangRe)
        {
            _boomerangPos = player.transform.position;
            boomerang.transform.position = Vector2.MoveTowards
                (boomerang.transform.position, _boomerangPos, boomerangSpeed * Time.deltaTime);
        }
        else
        {
            //�u�[���������ڂ̋O��
            boomerang.transform.position = Vector2.MoveTowards
           (boomerang.transform.position, _boomerangPos, boomerangSpeed * Time.deltaTime);
        }

    }
     private void KunaiWeapon()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _playerPos = player.transform.position;
            float time = 1f;
            GameObject newkunai = Instantiate(kunai);
            kunaiRd = newkunai.GetComponent<Rigidbody2D>();
            newkunai.transform.position = _playerPos;
            if (playerScript.rightNow)
            {
                this.kunaiRd.AddForce(new Vector2(1500f, 0f));
            }
            else
            {
                this.kunaiRd.AddForce(new Vector2(-1500f, 0f));
            }
            Destroy(newkunai, time);
          
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == boomerang)
        {
            if (_canReturn)
            {
                print("����");
                _canReturn = false;
                _shouldBoomerangRe = false;
                _existsBoomerang = false;
                boomerangSpeed = 15;
                boomerang.SetActive(false);
            }
        }
    }
}



