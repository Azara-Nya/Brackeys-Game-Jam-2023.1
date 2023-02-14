using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private bool inRange;
    [SerializeField] Door door;

    void Update()
    {
        if(inRange)
        {
            door.isOpen = true;
        }
        else
        {
            door.isOpen = false;
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
