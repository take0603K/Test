using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SubWeapon : MonoBehaviour
{
    //�N�i�C�p
    [SerializeField] GameObject player = null;
    [SerializeField] GameObject kunai = null;
 
    Rigidbody2D kunaiRd;

    //�u�[�������p

    [SerializeField] GameObject boomerang = null;
    [SerializeField] GameObject boomerangTraget = null;
    private float boomerangSpeed = 15f;
    private Vector3 _boomerangPos;

    bool existsBoomerang = false;
    bool shouldBoomerangRe = false;
    bool canReturn = false;
    //���܂������p

    [SerializeField] GameObject kamaitachi = null;

    //����

    private Vector2 _playerPos;
    PrayerC playerScript;
    public int _damage=0;

    void Start()
    {
        _playerPos = player.transform.position;
        kunai.transform.position = _playerPos;
        playerScript = player.GetComponent<PrayerC>();


        boomerang.SetActive(false);
        kamaitachi.SetActive(false);

       
    }
    void Update()
    {
        //�ȉ��e�X�g�p
        if (Input.GetKeyDown(KeyCode.E))
        {
            _damage = 0;
            KunaiWeapon();
        }
        if (Input.GetKeyDown(KeyCode.Q) && existsBoomerang == false)
        {
            _damage = 80;
            BoomerangWeapon();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            _damage = 300;
            KamaitachiWeapon();
        }
        if (existsBoomerang == true)
        {
            BoomerangOperation();
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            print("�v���C���["+_playerPos) ;
            print("�����n�_" + _boomerangPos);
            print("�u�[�������ʒu" + boomerang.transform.position);
            print("�u�[�������^�[�Q�b�g" + boomerangTraget.transform.position);
            print(shouldBoomerangRe);
        }
    }
        private void KamaitachiWeapon()
    {
        StartCoroutine(WeaponCoroutine(2,0));   
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
                shouldBoomerangRe = true;
                canReturn = true;
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
        _playerPos = player.transform.position;
        boomerang.SetActive(true);
        boomerang.transform.position = _playerPos;
        _boomerangPos = boomerangTraget.transform.position;
        existsBoomerang = true;
        StartCoroutine(WeaponCoroutine(1.2f, 1));
    }
    private void BoomerangOperation()
    {
        if (shouldBoomerangRe)
        {
            _boomerangPos = player.transform.position;
            boomerang.transform.position = Vector2.MoveTowards
                (boomerang.transform.position, _boomerangPos, boomerangSpeed * Time.deltaTime);
            return;
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
        _playerPos = player.transform.position;
        float _time=1f;
        GameObject newkunai = Instantiate(kunai);
        kunaiRd = newkunai.GetComponent<Rigidbody2D>();
        newkunai.transform.position = _playerPos;
        if (playerScript.rightNow == true)
        {
            this.kunaiRd.AddForce(new Vector2(1500f, 0f));
        }
        else
        {
            this.kunaiRd.AddForce(new Vector2(-1500f, 0f));
        }
        Destroy(newkunai, _time);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == boomerang)
        {
            if (canReturn)
            {
                print("����");
                canReturn = false;
                shouldBoomerangRe = false;
                existsBoomerang = false;
                boomerangSpeed = 15;
                boomerang.SetActive(false);
            }
        }
    }
}



