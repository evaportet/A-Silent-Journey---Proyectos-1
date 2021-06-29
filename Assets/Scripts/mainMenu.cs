using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class mainMenu : MonoBehaviour
{
    public AudioSource button;
    public void PlayGame() {

        StartCoroutine(PlayFunction());
    }

    public void QuitGame() {

        
        StartCoroutine(QuitFunction());
        
    }
    private IEnumerator PlayFunction()
    {
        button.Play();
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    private IEnumerator QuitFunction()
    {
        Debug.Log("THANK YOU FOR PLAYING, SEE YOU SOON!");
        button.Play();
        yield return new WaitForSeconds(0.5f);
        Application.Quit();
    }
    public void BackButton()
    {
        button.Play();

    }
}
