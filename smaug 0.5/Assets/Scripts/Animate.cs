using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    Animator animator;
    PlayerMove PlayerMove;

    public float horizontal;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {

        //animator.SetFloat("Horizontal", horizontal);
    }
}
