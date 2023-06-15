using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{

    public Player player;
    public BoxCollider2D boxCollider;
    
    




    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        boxCollider = GetComponent<BoxCollider2D>();   
    }

    

    // Update is called once per frame
    void Update()
    {
        //player.transform.position = boxCollider.transform.position;

        //float dist = Vector3.Distance(player.transform.position, player.transform.position); ;

       
       //player.player_damage(player.health_player);

        
        

    }
}
