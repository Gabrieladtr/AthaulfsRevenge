using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{


    public float move_speed = 3f;
    public Rigidbody2D rgbd2d;
    public Vector3 moveDir;
    public Animator animator_player;
    public Enemy enemyCharacter2;
    Collision2D collisionPlayer;
    PlayerMove playerMove;
    Enemy characterEnemy;


    public float lastHorizontalVector = -1f;
    public float lastVerticalVector = 1f;


    private void Awake()
    {
        //funcao de pegar o componente de rigidbody2d da cena
        rgbd2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        //funcao de pegar o componente de Animator da cena
        animator_player = GetComponent<Animator>();
        enemyCharacter2 = GetComponent<Enemy>();
        collisionPlayer = GetComponent<Collision2D>();

        lastHorizontalVector = -1f;
        lastVerticalVector = 1f;

    }

    // Update is called once per frame
    private void Update()
    {
        UpdateAnimationAndMove();
    }

    private void FixedUpdate()
    {
        //ativa a colisao na cena e faz o personagem se mover.
        rgbd2d.velocity = moveDir * move_speed;

        //catch the moviments of player and assing to x and y variables 
        moveDir = Vector3.zero;
        moveDir.x = Input.GetAxisRaw("Horizontal");
        moveDir.y = Input.GetAxisRaw("Vertical");
    }


    private void UpdateAnimationAndMove()
    {
        //this method will controll the movement of player and yours bools variables animations 
        if (moveDir != Vector3.zero)
        {
            //player walking
            animator_player.SetFloat("moveX", moveDir.x);
            animator_player.SetFloat("moveY", moveDir.y);
            animator_player.SetBool("mov_player", true);
            animator_player.SetBool("atack", false);
            //animator_player.SetBool("hit", false);
            //animator_player.SetBool("die", false);

            lastHorizontalVector = moveDir.x;
            lastVerticalVector = moveDir.y;
        }
        else
        {
            //player stoped//idle
            animator_player.SetBool("mov_player", false);
            animator_player.SetBool("atack", false);
            //animator_player.SetBool("hit", false);
            //animator_player.SetBool("die", false);
        }

        if (Input.GetKey(KeyCode.Backspace))
        {

            animator_player.SetBool("atack", true);

            //enemyCharacter2.TakeDamage(100);
            
            

        }



    }
    public void OnCollisionEnter2D(Collision2D collision2D)
    {
        //Destroy(collision2D.gameObject);
        Debug.Log("Houve colisao");


    }




    public void hitCombo(bool var) {
        animator_player.SetBool("hit", var);
    }







    /*
    private void Awake()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
        movementVector = new Vector3();
        animate = GetComponent<Animate>();
    }

    private void Start()
    {
        lastHorizontalVector = -1f;
        lastVerticalVector = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");

        if(movementVector.x != 0) 
        {
            lastHorizontalVector = movementVector.x;
        }
        if (movementVector.y != 0) 
        {
            lastVerticalVector = movementVector.y;
        }

        animate.horizontal = movementVector.x;

        movementVector *= speed;

        rgbd2d.velocity = movementVector;
    }
    */
}
