using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Character
{    
    [SerializeField]
    private Rigidbody2D rigidbody2D;

    [SerializeField]
    private GameTime gameTime;

    [SerializeField]
    private bool OnGround;

    [SerializeField]
    private Fire fireMch;

    [SerializeField]
    private Fire1 fireMch2;

    [SerializeField]
    private SpriteRenderer[] playerSprites;

    [SerializeField]
    private Animator playerAnimator;

    [SerializeField]
    private Animator jacketAnimator;


    public bool simetricSkil;


    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        Message();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && gameTime.MyGameMode)
        {
            fireMch.FiringAmmo();
        }
        else if (Input.GetMouseButtonDown(0))
        {
            fireMch.FiringAmmo();
        }

        if (Input.GetMouseButtonDown(1))
        {
            fireMch2.FiringAmmo();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            simetricSkil = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            simetricSkil = true;
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (OnGround)
            {
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, JumpSpeed);
            }
            
        }

        if (Input.GetKey(KeyCode.D))
        {
            rigidbody2D.velocity = new Vector2(MoveSpeed, rigidbody2D.velocity.y);
            playerAnimator.SetBool("IsWalking", true);
            jacketAnimator.SetBool("IsWalking", true);
            //DisRefletPlayer();
        }

        else if (Input.GetKey(KeyCode.A))
        {
            rigidbody2D.velocity = new Vector2(-MoveSpeed, rigidbody2D.velocity.y);
            playerAnimator.SetBool("IsWalking", true);
            jacketAnimator.SetBool("IsWalking", true);
        }
        else
        {
            playerAnimator.SetBool("IsWalking", false);
            jacketAnimator.SetBool("IsWalking", false);
        }

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            OnGround = true;
        }

        Message();
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            OnGround = false;
        }

        Message();
    }

    private void Message()
    {
        if (OnGround == true)
        {
            Debug.Log("Yerdesin");
        }
        else
        {
            Debug.Log("Havadasın");
        }
    }

    public void ReflectPlayer()
    {
        foreach (var i in playerSprites)
        {
            i.flipX = true;
        }

        //if (simetricSkil)
        //{
        //    playerSprites[3].flipX = true;
        //}

    }
    public void DisRefletPlayer()
    {
        foreach (var i in playerSprites)
        {
            i.flipX = false;    
        }
    }

}