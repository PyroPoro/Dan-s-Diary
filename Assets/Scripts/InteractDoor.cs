using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractDoor : Interact_Object
{
    public GameObject teleportTarget;

    public override void startInteraction(){
        player.transform.position = teleportTarget.transform.position + (Vector3.up * -1f);
    }
}
