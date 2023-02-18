using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpen;
    [SerializeField] private BoxCollider2D bc;

    void Update()
    {
        if (isOpen)
        {
            bc.isTrigger = false;
        }
        else
        {
            bc.isTrigger = true;
        }
    }

}
