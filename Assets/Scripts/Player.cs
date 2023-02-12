using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpVelocity;
    [SerializeField] private float jumpRememberTime;
    [SerializeField] private float coyoteTimer;
    [SerializeField] private float horizontalDamping;
    [SerializeField] private float horizontalStoppingDaming;
    [SerializeField] private float horizontalTurningDamping;
    [SerializeField] private float shortJumpHeight;
    [SerializeField] private float checkRadius;
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

        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
