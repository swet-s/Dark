using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammos : MonoBehaviour
{
    public int ammoCount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            FindObjectOfType<AudioCreater>().PlayReload();
            GunManager currentgun = collision.GetComponent<GunManager>();
            currentgun.GetAmmos(ammoCount);
            Destroy(gameObject);
        }
    }

}
