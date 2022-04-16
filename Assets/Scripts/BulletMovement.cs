using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public Vector3 targetPos;
    public Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float bulletLifeTime;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, bulletLifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = targetPos * moveSpeed;
    }
}
