using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour
{
    public void LoadMain()
    {
        SceneManager.LoadScene("Main_Menu");
    }
    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}
