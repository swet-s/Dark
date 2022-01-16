using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ScoreManager coincount = collision.GetComponent<ScoreManager>();
            Destroy(gameObject);
            FindObjectOfType<AudioCreater>().PlayCoin();
            coincount.UpdateCoin();
        }
        
    }
}
