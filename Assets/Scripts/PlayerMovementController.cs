using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W)){
            transform.Translate(0, moveSpeed, 0);
        }
        if(Input.GetKey(KeyCode.S)){
            transform.Translate(0, -moveSpeed, 0);
        }
        if(Input.GetKey(KeyCode.A)){
            transform.Translate(-moveSpeed, 0, 0);
        }
        if(Input.GetKey(KeyCode.D)){
            transform.Translate(moveSpeed, 0, 0);
        }
    }
}
