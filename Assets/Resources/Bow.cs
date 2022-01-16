using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public Transform player;
    private Vector3 offset = new Vector3(-0.5f, 0.5f, 0f);
    public bool isFlipped = false;
    private GunManager gun;

    void Start()
    {
        gun = player.GetComponent<GunManager>();
    }
    void Update()
    {
        if (isFlipped)
        {
            Vector3 revOffset = new Vector3(-offset.x, offset.y, offset.z);
            transform.position = player.position + revOffset;
        }
        else
            transform.position = player.position + offset;
        if (gun)
        {
            if (gun.gunMovement > 0.1 && isFlipped)
            {
                transform.Rotate(0f, 180f, 0f);
                isFlipped = false;
            }
            else if (gun.gunMovement < -0.1 && !isFlipped)
            {
                transform.Rotate(0f, 180f, 0f);
                isFlipped = true;
            }
        }
    }
}



