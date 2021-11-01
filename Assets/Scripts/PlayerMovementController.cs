﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 moveDirection;
    private bool isFacingLeft = true;
    public GameObject player;
    public float characterScale = 0.13f;
    public Animator anim;
    public bool isSprinting;

    void Update(){
        ProcessInputs();
        if (isFacingLeft){
            player.transform.localScale = new Vector2(1, 1) * characterScale;
        }
        else {
            player.transform.localScale = new Vector2(-1, 1) * characterScale;
        }
        if (rb.velocity.x == 0 && rb.velocity.y == 0)
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isWalking", false);
        }
        else {
            anim.SetBool("isIdle", false);
            anim.SetBool("isWalking", true);
        }
    }
    void FixedUpdate()
    {
        Move();
    }
    void ProcessInputs(){
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
    
        moveDirection = new Vector2(moveX, moveY);
        if (Input.GetKey(KeyCode.LeftShift)) {
            isSprinting = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift)) {
            isSprinting = false;
        }
    }

    void Move(){
        if (isSprinting)
        {
            rb.velocity = new Vector2(moveDirection.x * moveSpeed * 2.0f, moveDirection.y * moveSpeed * 2.0f);
        }
        else {
            rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        }
        if (rb.velocity.x > 0)
        {
            isFacingLeft = false;
        }
        else if (rb.velocity.x < 0){
            isFacingLeft = true;
        }
    }
}
