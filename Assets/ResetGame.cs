using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : GameSaveManager
{
    public List<ScriptableObject> initialObjects = new List<ScriptableObject>();
    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Main_Menu"))
        {
            objects = initialObjects;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
