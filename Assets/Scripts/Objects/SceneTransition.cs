using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public Transform target;
    public Vector2 playerPosition;
    public VectorValue playerStorage;
    
    

    //public Collider2D other;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            //playerStorage.initialValue = playerPosition;
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("SampleScene"))
            {
                if (target.transform.position.x == 12.5f)//(other.transform.position.x > 10 && other.transform.position.x < 14)
                {
                    SceneManager.LoadScene("House");

                }
                else if (target.transform.position.x == -15.15f)//(other.transform.position.x > 16 && other.transform.position.x < -14)
                {
                    SceneManager.LoadScene("Dungeon1");
                }
                else if(target.transform.position.x == 6.74f)
                {
                    SceneManager.LoadScene("Dungeon2");
                }
                else if (target.transform.position.x == -44.14f)
                {
                    SceneManager.LoadScene("Dungeon3");
                }
                else if (target.transform.position.x == -60.79f || target.transform.position.x == -67.43f)
                {
                    SceneManager.LoadScene("Cueva");
                }
            }
            else
            {
                SceneManager.LoadScene("SampleScene");
            }
            playerStorage.initialValue = playerPosition;
        }

        
        //StartCoroutine(WaitTime()); 
    }
    private IEnumerator WaitTime()
    {          

         yield return new WaitForSeconds(2);        

    }

    


}
