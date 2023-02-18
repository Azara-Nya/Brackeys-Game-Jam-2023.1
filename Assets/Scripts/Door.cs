using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private BoxCollider2D bc;
    [SerializeField] private SpriteRenderer Sr;
    [SerializeField] private Color turnOff;
    [SerializeField] private Color turnOn;
    [SerializeField] private bool isInverted;
    public bool isOpen;

    void Update()
    {
        if (!isInverted)
        {
            if (isOpen)
            {
                Sr.color = turnOn;
                bc.isTrigger = false;
            }
            else
            {
                Sr.color = turnOff;
                bc.isTrigger = true;
            }
        }
        else
        {
            if (isOpen)
            {
                Sr.color = turnOff;
                bc.isTrigger = true;
            }
            else
            {
                Sr.color = turnOn;
                bc.isTrigger = false;
            }
        }
    }

}
