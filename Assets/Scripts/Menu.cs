using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private float transTime = 1f;
    [SerializeField] private string scene = "MainMenu";
    [SerializeField] private Animator Andy;
    public void Loader()
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
