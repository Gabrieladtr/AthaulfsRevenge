using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const float move_speed = 3f;
    private Rigidbody2D rigidbody2D;
    private Vector3 moveDir;
    private Animator animator_player;
    public float health_player = 100f;
    public BoxCollider2D boxColliderPlayer;




    private void Awake()
    {
        //funcao de pegar o componente de rigidbody2d da cena
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        //funcao de pegar o componente de Animator da cena
        animator_player = GetComponent<Animator>();
        boxColliderPlayer = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    private void Update()
    {
        UpdateAnimationAndMove();
    }

    private void FixedUpdate()
    {
        //ativa a colisao na cena e faz o personagem se mover.
        rigidbody2D.velocity = moveDir * move_speed;

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
            animator_player.SetBool("block", false);
            animator_player.SetBool("hit", false);
            animator_player.SetBool("die", false);

        }
        else
        {
            //player stoped
            animator_player.SetBool("mov_player", false);
            animator_player.SetBool("atack", false);
            animator_player.SetBool("block", false);
            animator_player.SetBool("hit", false);
            animator_player.SetBool("die", false);
        }

        if (Input.GetKey(KeyCode.Backspace))
        {
            //animation atack
            animator_player.SetBool("atack", true);
            animator_player.SetBool("block", false);
            animator_player.SetBool("hit", false);
            animator_player.SetBool("die", false);

        }
        if (Input.GetKey(KeyCode.RightShift))
        {
            //animation block
            animator_player.SetBool("block", true);
            animator_player.SetBool("atack", false);
            animator_player.SetBool("hit", false);
            animator_player.SetBool("die", false);

        }
        if (Input.GetKey(KeyCode.Delete))
        {
            //animation hit (teste)

            
            health_player -= 0.1f;
            
            animator_player.SetBool("hit", true);
            Console.WriteLine("health_player: " + health_player);
            
            animator_player.SetBool("block", false);
            animator_player.SetBool("walk", false);
            animator_player.SetBool("die", false);
            animator_player.SetBool("atack", false);


        }
    }

    public void player_damage()
    {
        health_player -= 0.1f;


        if (health_player == 0) 
        {
            animator_player.SetBool("die", true);
        }

    }


    //public void movimentation_player() = controlls animator webs movs and animation
    //its commented because i changed the state of animation of animation webs to animation blend tree.
    //so a needed create a new method to controll all settings of all these guys.
    /*
    public void movimentation_player()
    {
        //esse metodo vai usar o Animator padrao com flexas para movimentacao
        //se vc usar blend tree use o UpdateAnimationAndMove.

        //Esse metodo define padroes da movimentacao do player e animacao.

        float moveX = 0;
        float moveY = 0;


        //atribui movimentacao ao player.
        if (Input.GetKey(KeyCode.W))
            
        {
            moveY += 1;
            

        }
        if (Input.GetKey(KeyCode.S))
        {
            moveY -= 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveX -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveX += 1;
        }


        moveDir = new Vector3(moveX, moveY);

        
        //controla as animacoes do player

        if (moveX == 0 && moveY == 0)
        {
            //animation idle
            animator_player.SetInteger("mov_player", 0);
            //animator_player.Play(PLAYER_IDLE_HAIR_BLACK_0);   
            //animator_player.Play(PLAYER_IDLE_HAIR_BLACK_0);
            //animator_player.Play(PLAYER_IDLE_0);
            
            


        }
        
        if (moveX >= 1)
        
        {
            //animation right
            animator_player.SetInteger("mov_player", 1);
            
        }
        if (moveX <= -1)
        {
            //animation left
            animator_player.SetInteger("mov_player", 2);
        }
        if (moveY >= 1)
        {
            //animation up
            animator_player.SetInteger("mov_player", 3);
        }
        if (moveY <= -1)
        {
            //animation down
            animator_player.SetInteger("mov_player", 4);

            //verificar com o grupo se vamos segurar o botao pra atacar ou apenas apertar uma vez aq...
        }if (Input.GetKey(KeyCode.Backspace))
        {
            //animation atack
            animator_player.SetInteger("mov_player", 5);
           


        }
        if (Input.GetKey(KeyCode.RightShift))
        {
            //animation atack
            animator_player.SetInteger("mov_player", 6);
           


        }

    }
    
    */






}

