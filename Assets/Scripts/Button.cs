using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] Door door;
    [SerializeField] private Sprite Off;
    [SerializeField] private Sprite On;
    [SerializeField] private SpriteRenderer Fanta;
    [SerializeField] private AudioSource buttonSFX;
    [SerializeField] private bool isInverted;
    private bool inRange;

    void Update()
    {
        if (isInverted)
        {
            if (inRange)
            {
                door.isOpen = true;
                Fanta.sprite = On;
            }
            else
            {
                door.isOpen = false;
                Fanta.sprite = Off;
            }
        }
        else
        {
            if (inRange)
            {
                door.isOpen = false;
                Fanta.sprite = On;
            }
            else
            {
                door.isOpen = true;
                Fanta.sprite = Off;
            }
        }
    }


    void OnTriggerEnter2D(Collider2D other)
     {
        if(other.CompareTag("Player") | other.CompareTag("RegressionCat"))
        {
            buttonSFX.Play();
            inRange = true;
        }
        if(other.CompareTag("Box"))
        {
            buttonSFX.Play();
        }
     }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Box"))
        {
            inRange = true;
        }
    }

     void OnTriggerExit2D(Collider2D other)
     {
        if(other.CompareTag("Player") | other.CompareTag("RegressionCat"))
        {
            inRange = false;
        }
        if(other.CompareTag("Box"))
        {
            inRange = false;
        }
     }
}
