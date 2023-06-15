using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipWeapon : WeaponBase
{
    [SerializeField] public GameObject leftWhipObject;
    [SerializeField] public GameObject rightWhipObject;
    [SerializeField] public GameObject upWhipObject;
    [SerializeField] public GameObject downWhipObject;
                     public Enemy enemyCharacter;

    Vector3 vectorDown = new Vector3(0,2,0);





    //[SerializeField] GameObject donwWhipObject;
    public Rigidbody2D rgbd2d;

    PlayerMove playerMove;

    [SerializeField] Vector2 attackSize = new Vector2(4f, 2f);

    private void Awake()
    {
        playerMove = GetComponentInParent<PlayerMove>();
        rgbd2d = GetComponent<Rigidbody2D>();
        enemyCharacter = GetComponent<Enemy>();

    }

    

    private void ApplyDamage(Collider2D[] colliders)
    {
        for (int i = 0; i < colliders.Length; i++) 
        {
            IDamageable e = colliders[i].GetComponent<IDamageable>();
            if (e != null)
            {
                PostDamage(weaponStats.damage, colliders[i].transform.position);
                e.TakeDamage(weaponStats.damage);
                enemyCharacter.TakeDamage(100);

            }
            else {
                enemyCharacter.NotTakeDamage();
            }
        }
    }


    
    public override void Attack()
    {
        StartCoroutine(AttackProcess());
            }

    
    
     IEnumerator  AttackProcess() 
    {
        
        
        for (int i = 0; i < weaponStats.numberOfAttacks; i++) 
        {

     
     
            if (playerMove.lastHorizontalVector > 0)
            {//RIGHT
                //rightWhipObject.SetActive(true);
                Debug.Log("leftWhipObject position" + leftWhipObject.transform.position);
                Debug.Log("rightWhipObject position" + rightWhipObject.transform.position);
                Debug.Log("player position" + playerMove.transform.position);

                Collider2D[] colliders = Physics2D.OverlapBoxAll(playerMove.transform.position, attackSize, 0f);

                ApplyDamage(colliders);
                //EnemyCharacter.TakeDamage(100);
                //Debug.Log("rightWhipObject.SetActive(true)");
            }
            else
            {//LEFT
                //leftWhipObject.SetActive(true);
                Collider2D[] colliders = Physics2D.OverlapBoxAll(playerMove.transform.position, attackSize, 0f);
                
                //EnemyCharacter.TakeDamage(100);
                ApplyDamage(colliders);

                Debug.Log("leftWhipObject position" + leftWhipObject.transform.position);
                Debug.Log("rightWhipObject position" + rightWhipObject.transform.position);
                Debug.Log("player position" + playerMove.transform.position);

                //Debug.Log("leftWhipObject.SetActive(true)");
            }
            

            yield return new WaitForSeconds(0.5f);
        }
        
    }
}
