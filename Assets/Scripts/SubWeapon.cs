using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SubWeapon : MonoBehaviour
{
    //クナイ用
    [SerializeField] GameObject player = null;
    [SerializeField] GameObject kunai = null;
 
    Rigidbody2D kunaiRd;

    //ブーメラン用

    [SerializeField] GameObject boomerang = null;
    [SerializeField] GameObject boomerangTraget = null;
    private float boomerangSpeed = 13f;
    private Vector3 _boomerangPos;

    bool existsBoomerang = false;
    bool shouldBoomerangRe = false;
    bool canReturn = false;
    //かまいたち用

    [SerializeField] GameObject kamaitachi = null;

    //共通

    private Vector2 _playerPos;
    PrayerC playerScript;
    public int _damage=0;

  

    private float startAt;
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
        //以下テスト用
        if (Input.GetKeyDown(KeyCode.E))
        {
            _damage = 50;
            KunaiWeapon();
        }
         //&& existsBoomerang == false
        if (Input.GetKeyDown(KeyCode.Q))
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
            print("プレイヤー"+_playerPos) ;
            print("到着地点" + _boomerangPos);
            print("ブーメラン位置" + boomerang.transform.position);
            print("ブーメランターゲット" + boomerangTraget.transform.position);
            print(shouldBoomerangRe);
        }
    }
        private void KamaitachiWeapon()
    {
        StartCoroutine(WeaponCoroutine(2,0));   
    }
    IEnumerator WeaponCoroutine(float time,int switchCor)
    {
        print("コルーチン");
        yield return new WaitForSeconds(time);
        switch(switchCor)  
        {
            case 0:
                kamaitachi.SetActive(true);
                yield return new WaitForSeconds (2);
                kamaitachi.SetActive (false);
                break;
            case 1:
                print("戻り");
                boomerangSpeed = boomerangSpeed + 3;
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
        boomerangSpeed = 10;
        boomerang.transform.position = _playerPos;
        _boomerangPos = boomerangTraget.transform.position;
        existsBoomerang = true;
        StartCoroutine(WeaponCoroutine(1.5f, 1));
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
            //ブーメラン一回目の軌道
            boomerang.transform.position = Vector2.MoveTowards
           (boomerang.transform.position, _boomerangPos, boomerangSpeed * Time.deltaTime);
        }

    }
     private void KunaiWeapon()
    {
        _playerPos = player.transform.position;
        float _time=1f;
        print("生成");
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
        //if (collision.gameObject.CompareTag("PlayerWeapon"))
        //{
        //    print("HIIIIT");
        //}
        if (collision.gameObject == boomerang)
        {
            if (canReturn)
            {
                print("消滅");
                canReturn = false;
                shouldBoomerangRe = false;
                existsBoomerang = false;
                boomerang.SetActive(false);
            }
        }
    }
}



