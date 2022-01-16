using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePoint : MonoBehaviour
{
    public GameObject fireBall;
    [Range(0.1f, 1)] public float density;
    bool loaded = true;
    public Vector2 shootVel;

    void Update()
    {
        if (loaded)
        {
            StartCoroutine("Now");
            loaded = false;
        }
    }

    IEnumerator Now()
    {
        yield return new WaitForSeconds(0.2f/density);
        GameObject fire = Instantiate(fireBall, transform.position, transform.rotation);
        fire.GetComponent<Fire>().vel = shootVel;
        loaded = true;
    }
}
