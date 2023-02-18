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
    [SerializeField] private float transTime = 1f;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Transform grounderObject;
    [SerializeField] private Transform startingPosition;
    [SerializeField] private Transform regressionPoolPosition;
    [SerializeField] private GameObject regressionCat;
    [SerializeField] private Animator Andy;
    [SerializeField] private Animator CAndy;
    [SerializeField] private AudioSource JumpSFX;
    [SerializeField] private AudioSource RegressionSFX;
    [SerializeField] private AudioSource ResetSFX;
    private GameObject[] RegaeCats;
    private float jumpRemeber;
    private float coyoteTime;
    private float moveInput;
    private bool facingLeft;
    private bool isGrounded;
    public int regressionAmount = 1;
    public int regressionsLeft;
    void Start()
    {
        rb.transform.position = startingPosition.transform.position;
        regressionsLeft = regressionAmount;
        for (int i = 0; i < regressionAmount; i++)
        {
            Instantiate(regressionCat, regressionPoolPosition.transform.position, regressionPoolPosition.transform.rotation);
        }
    }

    void Update()
    {

    if(Input.GetKeyDown(KeyCode.Return))
        {
            Regress();
        }
    isGrounded = Physics2D.OverlapCircle(grounderObject.position, checkRadius, whatIsGround);

        coyoteTime -= Time.deltaTime;
        if(isGrounded)
        {
            coyoteTime = coyoteTimer;
            Andy.SetBool("isJump", false);
        }

        jumpRemeber -= Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {        
            JumpSFX.Play();
            Andy.SetBool("isJump", true);
            jumpRemeber = jumpRememberTime;
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            Andy.SetBool("isJump", false);
            if(rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * shortJumpHeight);
            }
        }

        if(rb.velocity.y < 0)
        {
            Andy.SetBool("isFalling", true);
        }
        else
        {
            Andy.SetBool("isFalling", false);
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
                horizontalVelocity *= Mathf.Pow(1f - horizontalStoppingDaming, Time.fixedDeltaTime * 10f);
            }
        else if(Mathf.Sign(Input.GetAxisRaw("Horizontal")) != Mathf.Sign(horizontalVelocity))
            {
                horizontalVelocity *= Mathf.Pow(1f - horizontalTurningDamping, Time.fixedDeltaTime * 10f);
            }
        else
            {
            horizontalVelocity *= Mathf.Pow(1f - horizontalDamping, Time.fixedDeltaTime * 10f);
            }

        rb.velocity = new Vector2(horizontalVelocity, rb.velocity.y);

        if(Input.GetKeyDown(KeyCode.R))
        {
            ResetSFX.Play();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(carte());
        }

        moveInput = Input.GetAxisRaw("Horizontal");
        if(moveInput == 0)
        {
            Andy.SetBool("isWalking", false);
        }
        else 
        {
            Andy.SetBool("isWalking", true);
        }

        if(facingLeft && moveInput > 0)
        {
            Kowalski();
        }
        else if(!facingLeft && moveInput < 0)
        {
            Kowalski();
        }
    }

    void Kowalski()
    {
        facingLeft = !facingLeft;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    public void Regress()
    {
            for (int i = 0; i < regressionAmount; i++)
            {
                RegaeCats = GameObject.FindGameObjectsWithTag("RegressionCat");
                if (!RegaeCats[i].GetComponent<Regression>().isUsed)
                {
                    regressionsLeft--;
                    RegressionSFX.Play();
                    CAndy.SetTrigger("RegressionFade");
                    RegaeCats[i].transform.position = startingPosition.transform.position;
                    RegaeCats[i].GetComponent<Regression>().StartReplay();
                    RegaeCats[i].GetComponent<Regression>().isUsed = true;
                    if(i < RegaeCats.Length-1)
                    {
                        RegaeCats[i + 1].GetComponent<Regression>().positions = new List<Vector2>();
                        RegaeCats[i + 1].GetComponent<Regression>().movePositions = new List<float>();
                    }
                    rb.transform.position = startingPosition.transform.position;
                    break;
                }

            }

    }

    IEnumerator carte()
    {
        CAndy.SetTrigger("StartFade");
        yield return new WaitForSeconds(transTime);
        SceneManager.LoadScene("MainMenu");
    }
}
