using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartsManager : MonoBehaviour
{
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite halfFullHeart;
    public Sprite emptyHeart;
    public FloatValue heartContainers;
    public FloatValue playerCurrentHealth;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {


        //InitHearts();
        UpdateHearts();
        
        
        
    }

    public void InitHearts()
    {
        //float tempHealth = playerCurrentHealth.RuntimeValue / 2;

        //if (target.position.x < 12.5 && target.position.y < -4.5){

            for (int i = 0; i < heartContainers.initialValue; i++)
            {
                hearts[i].gameObject.SetActive(true);
                //hearts[i].sprite = fullHeart;
            }
        //}
        //else
        //{
        //    for (int i = 0; i < heartContainers.initialValue; i++)
        //    {
        //        hearts[i].gameObject.SetActive(true);

        //        if (i <= tempHealth - 1)//<= tempHealth)
        //        {
        //            //Full Heart
        //            hearts[i].sprite = fullHeart;
        //        }
        //        else if (i >= tempHealth)
        //        {
        //            // Empty Heart
        //            hearts[i].sprite = emptyHeart;
        //        }
        //        else if (i > tempHealth - 1 && i < tempHealth)
        //        {
        //            // Half full heart
        //            hearts[i].sprite = halfFullHeart;
        //        }
        //    }
        //}
    }
    public void UpdateHearts()
    {

        //for (int i = 0; i < heartContainers.initialValue; i++)
        //{
        //    hearts[i].gameObject.SetActive(true);

        //}

        float tempHealth = playerCurrentHealth.RuntimeValue / 2;
        for (int i = 0; i < heartContainers.initialValue; i++)
        {
            hearts[i].gameObject.SetActive(true);
            if (i <= tempHealth - 1)//<= tempHealth)
            {
                //Full Heart
                hearts[i].sprite = fullHeart;
            }
            else if (i >= tempHealth)
            {
                // Empty Heart
                hearts[i].sprite = emptyHeart;
            }
            else if (i > tempHealth - 1 && i < tempHealth)
            {
                // Half full heart
                hearts[i].sprite = halfFullHeart;
            }

        }
    }
        
}
