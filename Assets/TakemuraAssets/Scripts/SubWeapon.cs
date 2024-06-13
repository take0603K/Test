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
        _boomerang=2,
        kamaitachi=3,
    }
    //�N�i�C�p
    //�v���C���[�ʒu�ƃN�i�C�I�u�W�F
    [Header("�v���C���[����Ă�")][SerializeField] GameObject player = null;
    [SerializeField] GameObject kunai = null;
 
    Rigidbody2D kunaiRd;

    //�u�[�������p

    [SerializeField] GameObject _boomerang = null;
    [SerializeField] GameObject __boomerangTraget = null;
    private float _boomerangSpeed = 15f;
    private Vector3 __boomerangPos;


    //���ɓ������ォ�̔���E�u�[���������߂�ʒu�ɂ������̔���
    private  bool _exists_boomerang = default;
    private  bool _canReturn = default;
    //���܂������p

    [SerializeField] GameObject kamaitachi = null;
    private bool _iskamaitati = default;

    //����

    private Vector2 _playerPos;
    PrayerC playerScript;
    public int _damage=0;
    public WeaponSelect _weaponSelect=0;
  
  
    void Start()
    {
       
        _playerPos = player.transform.position;
       // kunai.transform.position = _playerPos;
        playerScript = player.GetComponent<PrayerC>();
        _weaponSelect = 0;
        /**�v���C���[�̈ʒu���i�[
         * �v���C���[�ʒu�ɃN�i�C���i�[
         * �v���C���[�̃X�N���v�g���i�[
         * ���ݕ���̏�����
         **/

        _boomerang.SetActive(false);
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
            case WeaponSelect._boomerang:
                _boomerangWeapon();
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
        if (_exists_boomerang)
        {
            _boomerangOperation();
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
                _iskamaitati = false;
                break;
            case 1:
                print("�߂�");
                _boomerangSpeed = _boomerangSpeed + 5;
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
        if (Input.GetKeyDown(KeyCode.E)&&!_iskamaitati)
        {
            _iskamaitati = true;
            //��b��ɃX�L������      
            StartCoroutine(WeaponCoroutine(2, 0));
        }
    }
    private void _boomerangWeapon()
    {
        if (Input.GetKeyDown(KeyCode.E) && !_exists_boomerang)
        {
            //�u�[�������̈ʒu�Ȃǂ��Z�b�g���ău�[�������𓊂���
            _playerPos = player.transform.position;
            _boomerang.SetActive(true);
            _boomerang.transform.position = _playerPos;
            __boomerangPos = __boomerangTraget.transform.position;
            _exists_boomerang = true;
            //1.2�b��Ƀu�[�������̈ړ�������ύX����
            StartCoroutine(WeaponCoroutine(1.2f, 1));
        }
       
    }
    private void _boomerangOperation()
    {
        if (_canReturn)
        {
            //�u�[�������̖߂�O��
            __boomerangPos = player.transform.position;
            _boomerang.transform.position = Vector2.MoveTowards
                (_boomerang.transform.position, __boomerangPos, _boomerangSpeed * Time.deltaTime);
        }
        else
        {
            //�u�[���������ڂ̋O��
            _boomerang.transform.position = Vector2.MoveTowards
           (_boomerang.transform.position, __boomerangPos, _boomerangSpeed * Time.deltaTime);
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
        if (collision.gameObject == _boomerang)
        {
            //���ɖ߂菈���ɓ˓����Ă���̂Ȃ�������
            if (_canReturn)
            {
                print("����");
                _canReturn = false;
                _exists_boomerang = false;
                _boomerangSpeed = 15;
                _boomerang.SetActive(false);
            }
        }
    }
}



