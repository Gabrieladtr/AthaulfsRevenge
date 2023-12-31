using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int maxHp = 10000;
    public int currentHp = 10000;
    public int armor = 0;

    public float hpRegenerationRate = 1f;
    public float hpRegenerationTimer;

    [SerializeField] StatusBar hpBar;

    [HideInInspector] public Level level;
    [HideInInspector] public Coins coins;
    public PlayerMove playerMove;
    private bool isDead;

    private void Awake()
    {
        level = GetComponent<Level>();
        coins = GetComponent<Coins>();
        playerMove = GetComponent<PlayerMove>();
    }

    private void Start()
    {
        hpBar.SetState(currentHp, maxHp);
    }

    private void Update()
    {
        hpRegenerationTimer += Time.deltaTime * hpRegenerationRate;

        if (hpRegenerationTimer > 1f) 
        {
            Heal(1);
            hpRegenerationTimer -= 1f;
        

    }
}
    public void TakeDamage(int damage) 
    {

        
        if (isDead == true){ return;}
        ApplyArmor(ref damage);


        currentHp -= damage;
        
        playerMove.animator_player.SetBool("hit", true);

        Debug.Log("HP player atual: " + currentHp);


        if (currentHp <= 0) 
        {
            Debug.Log("HP player atual: " + currentHp);
            GetComponent<CharacterGameOver>().GameOver();
            isDead = true;
        }
        hpBar.SetState(currentHp, maxHp);
    }

    public void NotTakeDamage() {
        Debug.Log("N�o est� levando dano");
        playerMove.animator_player.SetBool("hit", false);
    }

    private void ApplyArmor(ref int damage)
    {
        damage -= armor;
        if (damage < 0) { damage = 0; }
        
    }

    public void Heal(int amount) 
    {
        if (currentHp <= 0) { return; }

        currentHp += amount;
        if (currentHp > maxHp) 
        {
            currentHp = maxHp;
        }
        hpBar.SetState(currentHp, maxHp);
    }


}
