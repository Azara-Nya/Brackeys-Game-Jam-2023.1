using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Water : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private AudioSource resetSFX;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            if (player.regressionsLeft != 0)
            {
                player.Regress();
            }
            else
            {
                resetSFX.Play();
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
