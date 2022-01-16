using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureDeath : MonoBehaviour
{
    public float speed;
    float pos;
    public GameObject child;

    private void Start()
    {
        gameObject.GetComponent<Animator>().enabled = false;
    }

    void FixedUpdate()
    {
        pos = transform.position.x;
        pos += speed;
        transform.position = new Vector3(pos, transform.position.y, transform.position.z);


        if (Random.Range(0, 100) == 0)
            gameObject.GetComponent<Animator>().enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Plank")
        {
            Destroy(child);
            gameObject.GetComponent<EnemyHealth>().Die();
        }
    }
}
