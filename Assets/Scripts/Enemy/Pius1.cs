using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pius1 : MonoBehaviour
{
    public float speed = 0f;
    public float range = 0f;
    public bool isSmart = false;
    public int power = 10;
    public Vector2 impulse;

    [HideInInspector]
    public bool isFlipped = false;
    Rigidbody2D rb;
    Transform player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    void Update()
    {
        if (isSmart)
            MoveTowardPlayer();
        else
            MoveSimple();
    }

    public void MoveSimple()
    {
        rb.velocity = new Vector2(transform.right.x * -speed, rb.velocity.y);
    }


    public void MoveTowardPlayer()
    {
        LookAtPlayer();
        rb.velocity = new Vector2(transform.right.x * -speed, rb.velocity.y);
    }

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if( transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
            impulse *= -1;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
            impulse *= -1;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Health giveDamage = collision.gameObject.GetComponent<Health>();
            Damage getDamage = collision.gameObject.GetComponent<Damage>();
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            giveDamage.takeDamage(power);
            getDamage.OnCollosionWithEnemy();
            rb.AddForce(impulse);
            Flip();
        }

        if (collision.gameObject.tag == "Enemy" || collision.gameObject.layer == 14 || collision.gameObject.layer == 11)
        {
            Flip();
        }

    }

    public void Flip()
    {
        if (isFlipped)
        {
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (!isFlipped)
        {
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }

    }
}

/*
if (Vector2.Distance(rb.position, player.position) < range)
        {
            Vector2 target = new Vector2(player.position.x, rb.position.y);
Vector2 newpos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
rb.MovePosition(newpos);
        }*/