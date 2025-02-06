using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{

    private bool canDash = true;
    private bool isDashing;
    [SerializeField] private float dashingPower = 12.0f;
    [SerializeField] private float dashingTime = .2f;
    [SerializeField] private float dashingCoolDown = 1.0f;

    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private PlayerMovement move;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing || move.dir == .0f || move.isGrounded)
        {
            return;
        }

        if((Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.S)) && canDash)
        {
            StartCoroutine(Dash());
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = .0f;
        rb.velocity = new Vector2(move.dir / Mathf.Abs(move.dir) * transform.localScale.x * dashingPower, .0f);
        yield return new WaitForSeconds(dashingTime);
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCoolDown);
        canDash = true;
    }
}
