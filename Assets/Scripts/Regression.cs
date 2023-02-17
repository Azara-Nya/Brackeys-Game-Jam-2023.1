using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regression : MonoBehaviour
{
    public List<Vector2> positions;
    public List<float> movePositions;
    public bool isPlaying;
    private Transform player;
    private Rigidbody2D rb;
    private BoxCollider2D Bc;
    private Animator Andy;
    private bool facingLeft;
    public bool isUsed;

    void Start()
    {
        positions = new List<Vector2>();
        movePositions = new List<float>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        Bc = GetComponent<BoxCollider2D>();
        Andy = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if(isPlaying)
        {
            Play();
        }
        else
        {
            Record();
        }
    }

    public void StartReplay()
    {
        isPlaying = true;
        rb.isKinematic = true;
        StartCoroutine(Invis());
    }
    
    void Record()
    {
        Andy.SetBool("isSitting", true);
        if (positions.Count > Mathf.Round(30f / Time.fixedDeltaTime))
        {
            positions.RemoveAt(0);
            movePositions.RemoveAt(0);
        }

        positions.Add(player.position);
        movePositions.Add(Input.GetAxisRaw("Horizontal"));
    }

    void Play()
    {
        Andy.SetBool("isSitting", false);
        if (positions.Count > 0)
        {
            transform.position = positions[0];
            if(movePositions[0]==0)
            {
                Andy.SetBool("isWalking", false);
            }
            else if(movePositions[0] != 0)
            {
                Andy.SetBool("isWalking", true);
            }

            if(facingLeft && movePositions[0] > 0)
            {
                Skipper();
            }
            else if(!facingLeft && movePositions[0] < 0)
            {
                Skipper();
            }

            movePositions.RemoveAt(0);
            positions.RemoveAt(0);
        }
        else
        {
            isPlaying = false;
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            rb.isKinematic = false;
            rb.gravityScale = 2f;
            Andy.SetBool("isWalking", false);
            Andy.SetBool("isJump", false);
        }
    }

    void Skipper()
    {
        facingLeft = !facingLeft;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    IEnumerator Invis()
    {
        if (positions.Count > 0)
        {
            Bc.isTrigger = true;
            yield return new WaitForSeconds(1f);
            Bc.isTrigger = false;
            Play();
        }
        else
        { 
            isPlaying = false;
        }
    }
}
