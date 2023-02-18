using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private bool inRange;
    [SerializeField] Door door;
    [SerializeField] private Sprite Off;
    [SerializeField] private Sprite On;
    [SerializeField] private SpriteRenderer Fanta;

    void Update()
    {
        if(inRange)
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


    void OnTriggerEnter2D(Collider2D other)
     {
        if(other.CompareTag("Player") | other.CompareTag("RegressionCat"))
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
     }
}
