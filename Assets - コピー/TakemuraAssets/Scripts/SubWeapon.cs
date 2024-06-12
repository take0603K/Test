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


    //���ɓ������ォ�̔���E�u�[���������߂�ʒu�ɂ������̔���
    private  bool _existsBoomerang = default;
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
        /**�v���C���[�̈ʒu���i�[
         * �v���C���[�ʒu�ɃN�i�C���i�[
         * �v���C���[�̃X�N���v�g���i�[
         * ���ݕ���̏�����
         **/

        boomerang.SetActive(false);
        kamaitachi.SetActive(false);    
    }
    void Update()
    {
        //�I������Ă��镐����A�b�v�f�[�g�ɌĂяo��
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
        //�e�X�g�p�̋@�\�Ȃ̂ŃC���x���g���@�\���ł�����u�������܂�
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
        //�u�[�������̈ړ������X�C�b�`���ɓ����Ƒ����΂���܂�
        if (_existsBoomerang)
        {
            BoomerangOperation();
        }
        //�ȉ��e�X�g�p
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
    private void KamaitachiWeapon()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //��b��ɃX�L������
            StartCoroutine(WeaponCoroutine(2, 0));
        }
    }
    private void BoomerangWeapon()
    {
        if (Input.GetKeyDown(KeyCode.E) && !_existsBoomerang)
        {
            //�u�[�������̈ʒu�Ȃǂ��Z�b�g���ău�[�������𓊂���
            _playerPos = player.transform.position;
            boomerang.SetActive(true);
            boomerang.transform.position = _playerPos;
            _boomerangPos = boomerangTraget.transform.position;
            _existsBoomerang = true;
            //1.2�b��Ƀu�[�������̈ړ�������ύX����
            StartCoroutine(WeaponCoroutine(1.2f, 1));
        }
       
    }
    private void BoomerangOperation()
    {
        if (_canReturn)
        {
            //�u�[�������̖߂�O��
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
        //�N�i�C����
        if (Input.GetKeyDown(KeyCode.E))
        {
            //���ݒn�ɃN�i�C�𐶐����Ďw�莞�Ԍ�ɏ�������
            _playerPos = player.transform.position;
            float time = 1f;
            GameObject newkunai = Instantiate(kunai);
            kunaiRd = newkunai.GetComponent<Rigidbody2D>();
            newkunai.transform.position = _playerPos;
            //�v���C���[�̌����ɂ���Ďˏo����������
            //�E�ɔ�΂�else�͍�
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
        //�v���C���[�ɂԂ������I�u�W�F�N�g���u�[�������Ȃ珈��������
        if (collision.gameObject == boomerang)
        {
            //���ɖ߂菈���ɓ˓����Ă���̂Ȃ�������
            if (_canReturn)
            {
                print("����");
                _canReturn = false;
                _existsBoomerang = false;
                boomerangSpeed = 15;
                boomerang.SetActive(false);
            }
        }
    }
}



