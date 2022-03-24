using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    private Vector3 targetPos;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float bulletLifeTime;
    // Start is called before the first frame update
    void Start()
    {
        targetPos = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        Destroy(this.gameObject, bulletLifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, shootDirection, moveSpeed * Time.deltaTime);
        // if(transform.position == shootDirection){
        //     Destroy(this.gameObject);
        // }
        transform.Translate(targetPos * Time.deltaTime * moveSpeed);
    }
}
