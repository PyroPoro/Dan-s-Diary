using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

    public Transform camFollow;
    public Transform Player;
    public bool vertFollow = false;

    void Update()
    {

        if (vertFollow)
        {
            camFollow.position = new Vector3(Player.position.x, Player.position.y, 0);
        }
        else
        {
            camFollow.position = new Vector3(Player.position.x, -3.5f, 0);
        }
        
    }
}