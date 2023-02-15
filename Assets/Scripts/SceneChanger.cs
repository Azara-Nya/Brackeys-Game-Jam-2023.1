using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private string scene="MainMenu";
    [SerializeField] private float transTime = 1f;
    [SerializeField] private Animator Andy;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("E");
        if(other.CompareTag("Player"))
        {
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
