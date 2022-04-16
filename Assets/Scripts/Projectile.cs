using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    
    public float damage;
    public int pierce;
    public float kb;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pierce <= 0){
            Destroy(this.gameObject);
        }
    }
    
}
