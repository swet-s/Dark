using UnityEngine;

public class Dive : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(-0.12f, 0.15f, 0f);
    public bool isFlipped = false;
    private GunManager gun;

    void Start()
    {
        gun = player.GetComponent<GunManager>();
    }
    void Update()
    {
        //transform.rotation = player.rotation;
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



