using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryMovement : MonoBehaviour
{
    public GameObject player;
    public GameObject target;
    public Rigidbody2D rb;
    public Rigidbody2D playerRB;
    [SerializeField] private float followDistance;
    [SerializeField] private float moveSpeed;
    private bool move;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPoint = target.transform.position;
        Vector3 distance = target.transform.position - transform.position;
        
        if (distance.magnitude >= followDistance)
        {
            move = true;
        }
        if (distance.magnitude <= 0.001f){
            move = false;
            //transform.position = targetPoint;
        }
        if(move){
            if (distance.magnitude < 1.5f & distance.magnitude > 0.01f){
                rb.velocity = playerRB.velocity + new Vector2(distance.x * 10, distance.y * 10);
            }else{
                rb.velocity = distance * moveSpeed;
            }
            if (playerRB.velocity.magnitude > 1){
                if(rb.velocity.magnitude > playerRB.velocity.magnitude & distance.magnitude < 0.1f){
                    rb.velocity = playerRB.velocity;
                }
            }
        }
        else{
            rb.velocity = new Vector2(0, 0);
        }
    }
}
