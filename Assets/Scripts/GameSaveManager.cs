using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSaveManager : MonoBehaviour
{
    public static GameSaveManager gameSave;
    public List<ScriptableObject> objects = new List<ScriptableObject>();
    public DeathCounter myDeaths;
    


    private void Awake()
    {

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Main_Menu"))
        {
            myDeaths.counter++;
        }
        if (gameSave == null)
        {
        
            gameSave = this;
            
            
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
