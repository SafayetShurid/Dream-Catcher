using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
 
    private Rigidbody2D rb;
    private Animator animator;
    public TransitionPosition transitionPosition;
    
   // public NPC currentNPC;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        transform.position = transitionPosition.initialValue;
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
    }

    private void Walk()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 movePos = new Vector3(x, y);

        if (movePos != Vector3.zero)
        {
            animator.SetFloat("Horizontal", movePos.x);
            animator.SetFloat("Vertical", movePos.y);
            animator.SetBool("isWalking", true);
            //transform.position += movePos * speed * Time.deltaTime;

        }
        else
        {
            animator.SetBool("isWalking", false);
        }
        rb.velocity = movePos * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided");

    }
}
