using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] private bool turnedOn;
    [SerializeField] private bool inRange;
    [SerializeField] Door door;

    void Update()
    {
        if(inRange && Input.GetKeyDown(KeyCode.Q))
        {
            door.isOpen = !door.isOpen;
            turnedOn = !turnedOn;
        }
    }


    void OnTriggerEnter2D(Collider2D other)
     {
        if(other.CompareTag("Player"))
        {
            inRange = true;
        }
     }

     void OnTriggerExit2D(Collider2D other)
     {
        if(other.CompareTag("Player"))
        {
            inRange = false;
        }
     }
}
