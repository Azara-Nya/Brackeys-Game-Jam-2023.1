using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private float transTime = 1f;
    [SerializeField] private string scene = "MainMenu";
    public void Loader()
    {
        StartCoroutine(LoadNextScene());
    }

    IEnumerator LoadNextScene()
    {
        //play scene transtion animation
        yield return new WaitForSeconds(transTime);
        SceneManager.LoadScene(scene);
    }
}
