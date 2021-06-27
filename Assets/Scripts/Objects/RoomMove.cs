﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMove : MonoBehaviour
{
    //public Vector2 cameraChange;
    public Vector2 newMinMap;
    public Vector2 newMaxMap;
    public Vector3 playerChange;
    private CameraMovement cam;
    

    public float volume = 1;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cam.minPosition = newMinMap;
            cam.maxPosition = newMaxMap;

            other.transform.position += playerChange;

        }
    }
}
