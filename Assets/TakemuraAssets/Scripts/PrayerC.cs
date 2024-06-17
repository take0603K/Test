using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrayerC : MonoBehaviour
{
    
    Rigidbody2D rigid2D;
    //�ő��X�s�[�h
    [SerializeField]public float _LimitSpeed=100f;
 �@ //�ړ��X�s�[�h
    private float move = 25f;

    public bool rightNow = true;
   

    //���n����
     bool isGround = false;
    [SerializeField] private LayerMask groundLayer;

    public float jump = 450f;
    private float F = 0.25f;
    //[SerializeField] bool PlayMain = true;

    [SerializeField]
    private AudioClip jumpSound;
    private AudioSource audioSource;
    private bool sound = true;



    //��������ǉ��I�I�I�I�I�I
    [SerializeField] private GameObject _player;
    private SubWeapon _subWeapon;


    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        // ��������ǉ��I�I�I�I�I�I�I�I�I
        _subWeapon = _player.GetComponent<SubWeapon>();
    }
    private void Update()
    {
        // �T�u������Ăяo��
        _subWeapon.SubWeaponUpdate();
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        //���݂̑��x���L�^����
        float speedX = Mathf.Abs(this.rigid2D.velocity.x);
        //�ړ�����
        if (speedX < this._LimitSpeed)
        {
            if (Input.GetKey(KeyCode.D))
            {
                this.rigid2D.AddForce(new Vector2(move, 0f));
                if(rightNow==false)
                {
                    transform.Rotate(new Vector3(0, 180, 0));
                    rightNow = true;
                }
                
            }
            if (Input.GetKey(KeyCode.A))
            {
                this.rigid2D.AddForce(new Vector2(-move, 0f));
                if(rightNow==true)
                { 
                    transform.Rotate(new Vector3(0, 180, 0)); 
                    rightNow = false;
                }
            }

        }


        //���C�𔭎ˁi�����P�G���C�̎n�_�A�����Q�G���C�̌����A�����R�G���C�̋����A�����S�G���C���[�}�X�N�j
        RaycastHit2D hit = Physics2D.CircleCast(transform.position,0.43f, Vector2.down, F, groundLayer);
        //���C������
       // Gizmos.DrawSphere(transform.position,0.8f, Vector2.down * F, Color.red);

        //���n���菈��
        if (hit)
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }

        //�X�y�[�X�L�[�������ꂽ�Ƃ��W�����v����
        if (Input.GetKey(KeyCode.Space) && isGround)
        {
            this.rigid2D.AddForce(new Vector2(0f, jump));
            if(sound)
            {
                audioSource.PlayOneShot(jumpSound);
                sound = false;
                Invoke("SoundJump", 0.1f);
            }
           
            
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            this.rigid2D.AddForce(new Vector2(0, -jump / 2));
        }

    }
    private void SoundJump()
    {
        sound = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Move")
        {
            transform.parent = collision.gameObject.transform;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.parent = null;
    }

}
