using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    public Vector2 maxPosition;
    public Vector2 minPosition;

    //public AudioSource forest;
   
    public AudioSource forest;
    public AudioSource desert;
    public AudioSource cave;
    public AudioSource dungeon;
    public AudioSource house;
    public AudioSource tienda;    
    private AudioSource actualClip;
    public Inventory playerInventory;
    
    

    float volume = 1;
    // Start is called before the first frame update
    void Start()
    {
        if (playerInventory.numberOfStones >= 1)
        {
            forest.Play();
            actualClip = forest;
        }
        


            //audioSource = GetComponent<AudioSource>();
            //desert = GetComponent<AudioClip>();
            //transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
    }

    // Update is called once per frame
    private void Update()
    {
        if (playerInventory.numberOfStones >= 1)
        {
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("SampleScene") && target.position.x > -19.6F && target.position.y > 7.8F && target.position.y < 35.6F)
            {
                cave.Stop();
                dungeon.Stop();
                house.Stop();
                tienda.Stop();
                if (actualClip != desert)
                {
                    forest.Stop();
                    desert.Play();
                    actualClip = desert;
                }


            }
            else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("SampleScene"))
            {
                cave.Stop();
                dungeon.Stop();
                house.Stop();
                tienda.Stop();
                if (actualClip != forest)
                {
                    desert.Stop();
                    forest.Play();
                    actualClip = forest;
                }
            }
            else if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Dungeon1") || SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Dungeon2")|| SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Dungeon3"))
            {
                desert.Stop();
                forest.Stop();
                cave.Stop();
                house.Stop();
                tienda.Stop();
                if (actualClip != dungeon)
                {                    
                    dungeon.Play();
                    actualClip = dungeon;
                }
            }
            else if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Cueva"))
            {
                desert.Stop();
                forest.Stop();
                dungeon.Stop();
                house.Stop();
                tienda.Stop();
                if (actualClip != cave)
                {
                    cave.Play();
                    actualClip = cave;
                }

            }
            else if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("House"))
            {
                desert.Stop();
                forest.Stop();
                dungeon.Stop();
                cave.Stop();
                tienda.Stop();
                if (actualClip != house)
                {
                    house.Play();
                    actualClip = house;
                }
            }
            else if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Shop"))
            {
                desert.Stop();
                forest.Stop();
                dungeon.Stop();
                cave.Stop();
                house.Stop();
                if (actualClip != tienda)
                {
                    tienda.Play();
                    actualClip = tienda;
                }
            }
        }
        else
        {
            desert.Stop();
            forest.Stop();
            dungeon.Stop();
            cave.Stop();
            house.Stop();
            tienda.Stop();
        }
        
       
    }
    void LateUpdate()
    {
        if(transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
            
        }
    }
 }
