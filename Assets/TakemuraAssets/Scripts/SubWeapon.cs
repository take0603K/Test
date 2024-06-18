using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SubWeapon : MonoBehaviour
{
    //   if (Input.GetKeyDown(KeyCode.E))�̏������R���g���[���[�̃X�L�������L�[�ɒu�������āI�I�I
   
   
    //�N�i�C�p
    //�v���C���[�ʒu�ƃN�i�C�I�u�W�F
    [Header("�v���C���[������")][SerializeField] GameObject _player = null;
    [Header("�N�i�C������")][SerializeField] GameObject _kunai = null;
 
    Rigidbody2D _kunaiRd;

    //�u�[�������p

    [Header("�u�[������������")] [SerializeField] GameObject _boomerang = null;
    [Header("�u�[�������̓��B�n�_������")] [SerializeField] GameObject _boomerangTraget = null;
    private float _boomerangSpeed = 15f;
    private Vector3 _boomerangPos;


    //���ɓ������ォ�̔���E�u�[���������߂�ʒu�ɂ������̔���
    private  bool _exists_boomerang = default;
    private  bool _canReturn = default;
    //���܂������p

    [Header("���܂�����������")] [SerializeField] GameObject _kamaitachi = null;
    private bool _iskamaitati = default;

    //����

    private Vector2 _playerPos;
    PrayerC _playerScript;
    [Header("���݂̃T�u����C���x���g���ԍ�")] [SerializeField] private int _indexCnt = 1;
    public bool _isOpenBox = default;

    //�C���x���g���������Ă���I�u�W�F�N�g���i�[
    [Header("�C���x���g���X�N���v�g��������Obj������")] [SerializeField] Inventory _weaponInventory;
  
    void Start()
    {
        _playerPos = _player.transform.position;
        _playerScript = _player.GetComponent<PrayerC>();
        /**�v���C���[�̈ʒu���i�[
         * �v���C���[�ʒu�ɃN�i�C���i�[
         * �v���C���[�̃X�N���v�g���i�[
         * ���ݕ���̏�����
         **/

        //�u�[�������Ƃ��܂��������\���ɂ���
        _boomerang.SetActive(false);
        _kamaitachi.SetActive(false);
       
    }
    public void SubWeaponUpdate()
    {
        //�I������Ă��镐����A�b�v�f�[�g�ɌĂяo��
        switch (_weaponInventory._inventory[_indexCnt])
        {
            //����ۂ̎�
            case Inventory.WeaponSelect.nasi:
                break;
            //�N�i�C�̎�
            case Inventory.WeaponSelect.Kunai:
                KunaiWeapon();
                break;
            //�u�[�������̎�
            case Inventory.WeaponSelect._boomerang:
                _boomerangWeapon();
                break;
            //���܂������̎�
            case Inventory.WeaponSelect.kamaitachi:
                KamaitachiWeapon();
                break;
        }
        //�����󔠊J�����łȂ���Ε����؂�ւ����悤�ɂ���
        if (!_isOpenBox)
        {
            NotOpenBox();
        }

        //�u�[�������̈ړ������X�C�b�`���ɓ����Ƒ����΂���܂�
        if (_exists_boomerang)
        {
            _boomerangOperation();
        }
    }
   
    IEnumerator WeaponCoroutine(float time,int switchCor)
    {
        yield return new WaitForSeconds(time);
        switch(switchCor)  
        {
            case 0:
                _kamaitachi.SetActive(true);
                yield return new WaitForSeconds (2);
                _kamaitachi.SetActive (false);
                _iskamaitati = false;
                break;
            //���܂�������\�������Ă���Ɏw��b��ɏI������
            case 1:
                _boomerangSpeed = _boomerangSpeed + 5;
                _canReturn = true;
                break;
            //�u�[���������Ԃ��Ă���Ƃ��u�[���������x���グ��
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
    private void NotOpenBox()
    {
        /*R��L�ŃC���x���g�����E���ɑI������
         * �������ݑI�����Ă���C���x���g���ԍ����Ō�����邢�͐擪�̎�
         * �l�����Z�b�g����
         */
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (_indexCnt == _weaponInventory._maxIndex)
            {
                _indexCnt = 0;
                print("���݂̃C���x���g���ԍ�" + _indexCnt);
            }
            else
            {
                _indexCnt = _indexCnt + 1;
                print("���݂̃C���x���g���ԍ�" + _indexCnt);
            }
        }
        if(Input.GetKeyDown(KeyCode.L))
        {
            if (_indexCnt == 0)
            {
                _indexCnt = _weaponInventory._maxIndex;
                print("���݂̃C���x���g���ԍ�" + _indexCnt);
            }
            else
            {
                _indexCnt = _indexCnt - 1;
                print("���݂̃C���x���g���ԍ�" + _indexCnt);
            }
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
            _playerPos = _player.transform.position;
            _boomerang.SetActive(true);
            _boomerang.transform.position = _playerPos;
            _boomerangPos = _boomerangTraget.transform.position;
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
            _boomerangPos = _player.transform.position;
            _boomerang.transform.position = Vector2.MoveTowards
                (_boomerang.transform.position, _boomerangPos, _boomerangSpeed * Time.deltaTime);
        }
        else
        {
            //�u�[���������ڂ̋O��
            _boomerang.transform.position = Vector2.MoveTowards
           (_boomerang.transform.position, _boomerangPos, _boomerangSpeed * Time.deltaTime);
        }

    }
     private void KunaiWeapon()
    {
        //�N�i�C����
        if (Input.GetKeyDown(KeyCode.E))
        {
            //���ݒn�ɃN�i�C�𐶐����Ďw�莞�Ԍ�ɏ�������
            _playerPos = _player.transform.position;
            float time = 1f;
            GameObject newkunai = Instantiate(_kunai);
            _kunaiRd = newkunai.GetComponent<Rigidbody2D>();
            newkunai.transform.position = _playerPos;
            //�v���C���[�̌����ɂ���Ďˏo����������
            //�E�ɔ�΂�else�͍�
            if (_playerScript.rightNow)
            {
                newkunai.transform.Rotate(new Vector3(0, 0, -90));            
                this._kunaiRd.AddForce(new Vector2(1500f, 0f));
                Destroy(newkunai, time);
            }
            else
            {
                newkunai.transform.Rotate(new Vector3(0, -180, -90));
                this._kunaiRd.AddForce(new Vector2(-1500f, 0f));
                Destroy(newkunai, time);
            }
          
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



