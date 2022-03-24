using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    public GameObject bullet;
    public GameObject diary;
    
    [SerializeField] private float shootDelay;
    private float timeUntilNextShot;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0) && Time.time >= timeUntilNextShot){
            timeUntilNextShot = Time.time + shootDelay;
            Instantiate(bullet, diary.transform.position, Quaternion.identity);
        }
    }
}
