using UnityEngine.Events;
using UnityEngine;

public class Equip : MonoBehaviour
{
	public Transform player;
	public Vector3 offset;
	private GunManager gun;
    [HideInInspector]
    public bool gunisFlipped = false;

    void Start()
    {
        OnEquip.Invoke();
		gun = player.GetComponent<GunManager>();
    }
    void Update()
	{
        if (gunisFlipped)
        {
            Vector3 revOffset = new Vector3(-offset.x, offset.y, offset.z);
            transform.position = player.position + revOffset;
        }
        else
            transform.position = player.position + offset; 
        
        if (gun.gunMovement > 0.1 && gunisFlipped)
        {
            transform.Rotate(0f, 180f, 0f);
            gunisFlipped = false;
        }
        else if (gun.gunMovement < -0.1 && !gunisFlipped)
        {
            transform.Rotate(0f, 180f, 0f);
            gunisFlipped = true;
        }

        gun.Getgun(gameObject);
    }


    [Header("Events")]

    public UnityEvent OnEquip;
    public class BoolEvent : UnityEvent<bool> { }
}


