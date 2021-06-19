using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreText.coinAmount += 1;
        Destroy(gameObject);
    }
}
