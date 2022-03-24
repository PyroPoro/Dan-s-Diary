using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public float horMoveSpeed = 3;
    public float verMoveSpeed = 2;
    public float runSpeed = 5;
    public Rigidbody2D rb;
    private Vector2 moveDirection;
    private bool isFacingLeft = true;
    public GameObject player;
    public float characterScale = 0.13f;
    public Animator anim;
    public bool isRunning;
    public GameObject followTarget;

    void Update(){
        ProcessInputs();
        if (isFacingLeft){
            player.transform.localScale = new Vector2(1, 1) * characterScale;
            followTarget.transform.position = new Vector3(-0.6f, 0.1f, 0) + transform.position;
        }
        else {
            player.transform.localScale = new Vector2(-1, 1) * characterScale;
            followTarget.transform.position = new Vector3(0.6f, -0.3f, 0) + transform.position;
        }
        if (rb.velocity.x == 0 && rb.velocity.y == 0)
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isRunning", false);
        }
        else if(rb.velocity.x != 0){
            anim.SetBool("isIdle", false);
            //anim.SetBool("isWalking", true);
            anim.SetBool("isFacingSideways", true);
            if (isRunning){
                anim.SetBool("isRunning", true);
                anim.SetBool("isWalking", false);
            }else{
                anim.SetBool("isRunning", false);
                anim.SetBool("isWalking", true);
            }
        }else {
            anim.SetBool("isIdle", false);
            //anim.SetBool("isWalking", true);
            anim.SetBool("isFacingSideways", false);
            if (isRunning){
                anim.SetBool("isRunning", true);
                anim.SetBool("isWalking", false);
            }else{
                anim.SetBool("isRunning", false);
                anim.SetBool("isWalking", true);
            }
            if (rb.velocity.y > 0){
                anim.SetBool("isForward", false);
                followTarget.transform.position = new Vector3(0.3f, 0.3f, 0) + transform.position;
            }
            else if (rb.velocity.y < 0){
                anim.SetBool("isForward", true);
                followTarget.transform.position = new Vector3(-0.4f, -0.44f, 0) + transform.position;
            }
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
            isRunning = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift)) {
            isRunning = false;
        }
    }

    void Move(){
        if (isRunning)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y).normalized * runSpeed;
        }
        else {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y).normalized * new Vector2 (horMoveSpeed, verMoveSpeed);
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
