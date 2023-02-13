using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regression : MonoBehaviour
{
    public List<Vector2> positions;
    public bool isPlaying;
    private Transform player;
    private Rigidbody2D rb;
    private BoxCollider2D Bc;
    public bool isUsed;

    void Start()
    {
        positions = new List<Vector2>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        Bc = GetComponent<BoxCollider2D>();
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
        if (positions.Count > Mathf.Round(30f / Time.fixedDeltaTime))
        {
            positions.RemoveAt(0);
        }

        positions.Add(player.position);
    }

    void Play()
    {
        if (positions.Count > 0)
        {
            transform.position = positions[0];
            positions.RemoveAt(0);
        }
        else
        {
            isPlaying = false;
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            rb.isKinematic = false;
            rb.gravityScale = 2f;
        }
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
