using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicScale : MonoBehaviour
{
    float baseScale = 0.1f;
    public float freq = 0f;
    public float amp = 0f;
    float bias = 0f;
    Rigidbody2D rb;

    void Start()
    {
        bias = Random.Range(0f, 10f);
        rb = GetComponent<Rigidbody2D>();
    }

        void Update()
    {
        float anim = baseScale + Mathf.Sin(Time.time * freq + bias) * baseScale * amp ;
        transform.localScale = new Vector3(2 * anim, baseScale, baseScale);


    }

}
