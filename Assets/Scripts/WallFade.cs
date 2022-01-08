using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class WallFade : MonoBehaviour
{
    public GameObject player;
    private float distanceFromPlayer;

    public GameObject wall;

    // Update is called once per frame
    void Update()
    {
        distanceFromPlayer = player.transform.position.y - transform.position.y - 2.5f;
        // Color tmp = wall.gameObject.GetComponent<SpriteShapeRenderer>().color;
        // tmp.a = (int)(distanceFromPlayer / 2.5f * 255);
        //Debug.Log((float)(distanceFromPlayer / 2.5f));    
        wall.GetComponent<SpriteShapeRenderer>().color = new Color(1,1,1,(float)(distanceFromPlayer / 2.5f));  
    }
}
