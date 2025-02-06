using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D r;
    public bool isGrounded;
    public float dir;

    public float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        dir = Input.GetAxis("Horizontal") * speed;
        transform.Translate(dir * Time.deltaTime, 0, 0);

        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                r.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                isGrounded = false;
                transform.parent = null;
            }

        }
        float XRotation = transform.rotation.x;
        float YRotation = transform.rotation.y;
        transform.rotation = Quaternion.Euler(Mathf.Clamp(XRotation, -40f, 40f), -Mathf.Clamp(YRotation, -40f, 40f), 0f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            this.GetComponentInParent<PlayerMovement>().isGrounded = true;
            transform.parent = collision.gameObject.transform;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Goal"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
