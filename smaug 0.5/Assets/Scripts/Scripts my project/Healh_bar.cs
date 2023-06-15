using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healh_bar : MonoBehaviour
{

    public Slider slider;
    public Player player;



    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        player = GetComponent<Player>();
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        //slider.value = player.health_player;
        
    }
}
