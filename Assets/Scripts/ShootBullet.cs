using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    public GameObject bullet;
    public GameObject diary;
    
    [SerializeField] private float shootDelay;
    [SerializeField] private float specialCD;
    private float timeUntilNextShot;
    private float timeUntilSpecial;
    private Vector3 mousePos;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mousePos = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - diary.transform.position).normalized;
        if(Input.GetKey(KeyCode.Mouse0) && Time.time >= timeUntilNextShot){
            timeUntilNextShot = Time.time + shootDelay;
            normalAttack();
        }
        if(Input.GetKey(KeyCode.Mouse1) && Time.time >= timeUntilSpecial){
            timeUntilSpecial = Time.time + specialCD;
            specialAttack();
        }
    }
    private void normalAttack(){
        GameObject b = Instantiate(bullet, diary.transform.position, Quaternion.identity);
        b.GetComponent<BulletMovement>().targetPos = mousePos;
    }

    private void specialAttack(){
        GameObject b1 = Instantiate(bullet, diary.transform.position, Quaternion.identity);
        GameObject b2 = Instantiate(bullet, diary.transform.position, Quaternion.identity);
        GameObject b3 = Instantiate(bullet, diary.transform.position, Quaternion.identity);
        b1.GetComponent<BulletMovement>().targetPos = mousePos + new Vector3(0, 0.1f, 0);
        b2.GetComponent<BulletMovement>().targetPos = mousePos;
        b3.GetComponent<BulletMovement>().targetPos = mousePos + new Vector3(0, -0.1f, 0);
    }
}
