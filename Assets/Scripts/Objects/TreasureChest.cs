using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : Interactable
{
    // Start is called before the first frame update
    public void OnDisable()
    {
        
    }
    public void OnEnable()
    {
        isOpen = false;
    }
    private void Start()
    {
        isOpen = IntToBool(PlayerPrefs.GetInt("open"));
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
