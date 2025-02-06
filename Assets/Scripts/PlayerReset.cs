using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReset : MonoBehaviour
{
    private Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            
            transform.position = position;
        }
    }
}
