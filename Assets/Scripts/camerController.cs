using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerController : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    public Transform fade;

    // Update is called once per frame
    void Update()
    { 
        transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z);
        fade.position = new Vector3(transform.position.x, transform.position.y, -2.25f);
    }
}
