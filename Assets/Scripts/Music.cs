using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] private GameObject[] musique;
    void Awake()
    {
         DontDestroyOnLoad(gameObject);
    }
    void Update()
    {
        musique = GameObject.FindGameObjectsWithTag("Music");
        if(musique.Length > 1)
        {
            Destroy(musique[1]);
        }
    }
}
