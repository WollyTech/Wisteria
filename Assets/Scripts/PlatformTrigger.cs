using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            this.GetComponentInParent<PlayerMovement>().isGrounded = true;
            this.transform.parent.transform.parent = collision.gameObject.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            this.transform.parent.transform.parent = null;
        }
    }
}
