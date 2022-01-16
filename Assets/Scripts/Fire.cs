using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public int power = 20;
    [HideInInspector]
    public Vector2 vel;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = vel;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        if (collision.gameObject.tag == "Player")
        {
            Health giveDamage = collision.gameObject.GetComponent<Health>();
            Damage getDamage = collision.gameObject.GetComponent<Damage>();
            giveDamage.takeDamage(power);
            getDamage.OnCollosionWithEnemy();

        }
    }
}
