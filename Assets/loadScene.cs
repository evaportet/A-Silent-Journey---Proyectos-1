using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour
{
    public AudioSource button;
    public void LoadMain()
    {
        StartCoroutine(MainFunction());
        
        
    }
    public void LoadCredits()
    {
        StartCoroutine(Credits());
    }
    IEnumerator MainFunction()
    {
        button.Play();
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Main_Menu");
    }
    IEnumerator Credits()
    {
        button.Play();
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Credits");
    }
   
}
