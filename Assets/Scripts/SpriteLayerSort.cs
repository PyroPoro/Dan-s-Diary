using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLayerSort : MonoBehaviour
{
    public float offset;

    public bool runOnlyOnce;
    private GameObject child;

    void Start(){
        child = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        child.transform.position = new Vector3(child.transform.position.x, child.transform.position.y, transform.position.y - offset);
        if (runOnlyOnce){
            Destroy(this);
        }
    }
}
