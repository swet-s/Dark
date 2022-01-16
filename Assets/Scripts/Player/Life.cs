using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public int power = 20;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Health givelife = collision.gameObject.GetComponent<Health>();
            givelife.takelife(power);
            Destroy(gameObject);
        }
    }
}