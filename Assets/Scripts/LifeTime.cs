using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTime : MonoBehaviour
{
    public float lifeTime;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        //gameObject.transform.position = target.position; 
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
