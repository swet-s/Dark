using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlank : MonoBehaviour
{

    public float wait = 1f;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine("Wait");
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(wait);
        rb.gravityScale = 1;

    }
}
