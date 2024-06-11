using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SubWeapon : MonoBehaviour
{
    //   if (Input.GetKeyDown(KeyCode.E))の条件をコントローラーのスキル発動キーに置き換えて！！！
    /// <summary>
    /// 武器ごとに振られた固有番号管理用のEnum
    /// </summary>
    public enum WeaponSelect
    {
        Sword=0,
        Kunai=1,
        Boomerang=2,
        kamaitachi=3,
    }
    //クナイ用
    //プレイヤー位置とクナイオブジェ
    [Header("プレイヤー入れてね")][SerializeField] GameObject player = null;
    [SerializeField] GameObject kunai = null;
 
    Rigidbody2D kunaiRd;

    //ブーメラン用

    [SerializeField] GameObject boomerang = null;
    [SerializeField] GameObject boomerangTraget = null;
    private float boomerangSpeed = 15f;
    private Vector3 _boomerangPos;

    private  bool _existsBoomerang = default;
    private  bool _shouldBoomerangRe = default;
    private  bool _canReturn = default;
    //かまいたち用

    [SerializeField] GameObject kamaitachi = null;

    //共通

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
        //武器の切り替え
        if (Input.GetKeyDown(KeyCode.R))
        {
         
            if ((int)_weaponSelect == 3)
            {
                print("押してるよ");
                _weaponSelect = 0;
            }
            else
            {
                print((int)_weaponSelect);
             _weaponSelect++ ;
            }
        }
        //ブーメランの戻り処理かなんか
        if (_existsBoomerang)
        {
            BoomerangOperation();
        }
        //以下テスト用
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
                print("戻り");
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
            //ブーメラン一回目の軌道
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
                print("消滅");
                _canReturn = false;
                _shouldBoomerangRe = false;
                _existsBoomerang = false;
                boomerangSpeed = 15;
                boomerang.SetActive(false);
            }
        }
    }
}



