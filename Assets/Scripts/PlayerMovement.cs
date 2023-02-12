using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed=0.5f;
    [SerializeField] private float jumpVelocity=5f;
    [SerializeField] private float jumpRememberTime=0.25f;
    [SerializeField] private float coyoteTimer;
    [SerializeField] private float horizontalDamping = 0.5f;
    [SerializeField] private float horizontalStoppingDaming = 0.75f;
    [SerializeField] private float horizontalTurningDamping = 0.25f;
    [SerializeField] private float shortJumpHeight = 0.5f;
    [SerializeField] private float checkRadius = 0.1f;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Transform grounderObject;
    private float jumpRemeber;
    private float coyoteTime;
    private bool isGrounded;

    void Update()
    {
    isGrounded = Physics2D.OverlapCircle(grounderObject.position, checkRadius, whatIsGround);

        coyoteTime -= Time.deltaTime;
        if(isGrounded)
        {
            coyoteTime = coyoteTimer;
        }

        jumpRemeber -= Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.Space))
        {
            jumpRemeber = jumpRememberTime;
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            if(rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * shortJumpHeight);
            }
        }

        if(jumpRemeber > 0f && coyoteTime > 0f)
        {
            jumpRemeber = 0f;
            coyoteTime = 0f;
            rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
        }

        float horizontalVelocity = rb.velocity.x;
        horizontalVelocity += Input.GetAxisRaw("Horizontal");

        if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) < 0.01f)
            {
                horizontalVelocity *= Mathf.Pow(1f - horizontalStoppingDaming, Time.deltaTime * 10f);
            }
        else if(Mathf.Sign(Input.GetAxisRaw("Horizontal")) != Mathf.Sign(horizontalVelocity))
            {
                horizontalVelocity *= Mathf.Pow(1f - horizontalTurningDamping, Time.deltaTime * 10f);
            }
        else
            {
            horizontalVelocity *= Mathf.Pow(1f - horizontalDamping, Time.deltaTime * 10f);
            }

        rb.velocity = new Vector2(horizontalVelocity, rb.velocity.y);
    }
}
