using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed;
    public float agroRange;

    public GameObject target;
    public bool isAgro;
    public bool isKnockedBack;
    public Rigidbody2D rb;
    public float knockBackTime;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(gameObject.transform.position, agroRange);
        foreach(Collider2D col in cols){
            if (col.gameObject.tag == "Player"){
                isAgro = true;
                target = col.gameObject;
            }
        }

        if(!isKnockedBack){
            if (isAgro){
                rb.velocity = (target.transform.position - transform.position).normalized * moveSpeed;
            }else{
                rb.velocity = new Vector3(0,0,0);
            }
        }
        if (!isAgro && !isKnockedBack){
            rb.velocity = new Vector3(0,0,0);
        }

        float distanceFromTarget = Vector3.Distance(transform.position, target.transform.position);
        if (distanceFromTarget > (agroRange * 1.2f)){
            isAgro = false;
            //target = null;
        }

        if(isKnockedBack){
            if(Time.time > knockBackTime){
                isKnockedBack = false;
            }
        }
    }
}
