using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private string scene="MainMenu";
    [SerializeField] private float transTime = 1f;
    [SerializeField] private Animator Andy;
    [SerializeField] private AudioSource completeSFX;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            completeSFX.Play();
            Loader();
        }
    }

    void Loader()
    {
        StartCoroutine(LoadNextScene());
    }

    IEnumerator LoadNextScene()
    {
        Andy.SetTrigger("StartFade");
        yield return new WaitForSeconds(transTime);
        SceneManager.LoadScene(scene);
    }
}
