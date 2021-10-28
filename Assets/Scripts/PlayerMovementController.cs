using System.Collections;
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

    void Update(){
        ProcessInputs();
        if (isFacingLeft){
            player.transform.localScale = new Vector2(1, 1) * characterScale;
        }
        else {
            player.transform.localScale = new Vector2(-1, 1) * characterScale;
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
    }

    void Move(){
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        if (rb.velocity.x > 0)
        {
            isFacingLeft = false;
        }
        else if (rb.velocity.x < 0){
            isFacingLeft = true;
        }
        Debug.Log("switch");
    }
}
