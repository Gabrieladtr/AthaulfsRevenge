using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    Transform targetDestination;
    GameObject targetGameobject;
    Character targetCharacter;
    [SerializeField] float speed;

    public Animator animatorEnemy;
    PlayerMove playerMove;

    Rigidbody2D rgdbd2d;

    [SerializeField] int hp = 1000;
    [SerializeField] int damage = 1;
    [SerializeField] int experience_reward = 400;

    private void Awake()
    {
        rgdbd2d = GetComponent<Rigidbody2D>();
        
    }

    private void Start()
    {
        playerMove = GetComponent<PlayerMove>();
        animatorEnemy = GetComponent<Animator>();
        targetCharacter = targetGameobject.GetComponent<Character>();

    }

    public void SetTarget(GameObject target) 
    {
        targetGameobject = target;
        targetDestination = target.transform;
    }

    private void FixedUpdate()
    {
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        rgdbd2d.velocity = direction * speed;
        animatorEnemy.SetFloat("moveX", direction.x);
        animatorEnemy.SetFloat("moveY", direction.y);
    }

    private void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == targetGameobject)
        {

            animatorEnemy.SetBool("atack", true);
            Attack();
            //caso colida ataque e sete a animação
            //new WaitForSeconds(10f);
            

        }
        else {
            //Debug.Log("Não está atacando nem levando hit");
            targetCharacter.NotTakeDamage();
        }
        

    }

    internal void TakeDamage(object damage)
    {
        throw new NotImplementedException();
    }

    private void Attack()
    {
        if (targetCharacter == null) 
        {
            targetCharacter = targetGameobject.GetComponent<Character>();
            
        }

        targetCharacter.TakeDamage(damage);
        
        
        //dar dano no player
    }

    
    public void TakeDamage(int damage) 
    {   //caso morra
        hp -= damage;
        animatorEnemy.SetBool("hit",true);

        if (hp < 1) 
        {
            targetGameobject.GetComponent<Level>().AddExperience(experience_reward);
            GetComponent<DropOnDestroy>().CheckDrop();
            animatorEnemy.SetBool("die", true);
            Destroy(gameObject);
        }
    }

    public void NotTakeDamage() {
        animatorEnemy.SetBool("hit", false);
    }

}
