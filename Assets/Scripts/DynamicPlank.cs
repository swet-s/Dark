using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicPlank : MonoBehaviour
{
    public float speed = 0f;
    public bool isVertical = false;
    public bool isFlipped = false;
    Rigidbody2D rb;
    bool flipAvail = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isVertical)
        rb.velocity = transform.up * -speed;
        else
        rb.velocity = transform.right * -speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8 || collision.gameObject.layer == 14 && flipAvail)
        {
            flipAvail = false;
            if (isVertical)
                transform.Rotate(180f, 0f, 0f);
            else
                transform.Rotate(0f, 180f, 0f);

            if (isFlipped)
                isFlipped = false;
            else if (!isFlipped)
                isFlipped = true;
            StartCoroutine("wait");
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1f);
        flipAvail = true;

    }
}
