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
    private float boomerangSpeed = 10f;
    private Vector3 _boomerangPos;

    bool existsBoomerang = false;
    bool shouldBoomerangRe = false;
    bool _boomerangCnt = false;

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
            print("プレイヤー"+_playerPos) ;
            print("到着地点" + _boomerangPos);
            print("ブーメラン位置" + boomerang.transform.position);
            print("ブーメランターゲット" + boomerangTraget.transform.position);
        }
    }
        private void KamaitachiWeapon()
    {
        StartCoroutine(TestCoroutine(2,0));   
    }
    IEnumerator TestCoroutine(float time,int switchCor)
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
            default: 
                break;
            //case 1:
            //    break;
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

        if (boomerang.transform.position == _boomerangPos)
        {
            print("到着");
            boomerangSpeed = boomerangSpeed + 3;
            shouldBoomerangRe = true;
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
        if(collision.gameObject==boomerang)
        {
            if (_boomerangCnt)
            {
                print("消滅");
                _boomerangCnt = false;
                shouldBoomerangRe = false;
                existsBoomerang = false;
                boomerang.transform.position = _playerPos;
                _boomerangPos = boomerangTraget.transform.position;
                boomerang.SetActive(false);
            }
            else
            {
                _boomerangCnt = true;
            }
        }
    }
}



