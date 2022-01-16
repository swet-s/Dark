using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothPortal : MonoBehaviour
{
    public Transform player;
    public Transform reciever;
    public Boss boss;
    public int height;

    public bool playerIsOverlapping;

    void Update()
    {
        if (playerIsOverlapping)
        {
            Vector3 portalToPlayer = player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.right, portalToPlayer);

            if (dotProduct < 0f)
            {
                player.position = reciever.position + portalToPlayer;
                boss.currentPos = reciever.GetComponent<SmoothPortal>().height; ;
                playerIsOverlapping = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerIsOverlapping = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerIsOverlapping = false;
        }
    }
}
