using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutScene : MonoBehaviour
{
    [SerializeField] private Animator Andy;
    [SerializeField] private Animator CAndy;
    void Start()
    {
        StartCoroutine(cutty());
    }

    IEnumerator cutty()
    {
        yield return new WaitForSeconds(1f);
        Andy.SetBool("startCutscene", true);
        yield return new WaitForSeconds(5f);
        Andy.SetBool("startCutscene", false);
        CAndy.SetBool("StartFade", true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("MainMenu");
    }
}