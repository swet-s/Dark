using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingStar : MonoBehaviour
{
    Rigidbody2D rb;
    public float maxSpeed;
    public float freq;
    Vector2 temp_vel;
    bool completed = true;
    void Start()
    {
        rb =  GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        rb.velocity = temp_vel;
        if (completed)
        { 
            completed = false;
            StartCoroutine("Update_Vel");
        }
        
    }

    IEnumerator Update_Vel()
    {
        yield return new WaitForSeconds(freq);
        temp_vel = new Vector2(Random.Range(-maxSpeed, maxSpeed), Random.Range(-maxSpeed, maxSpeed));
        completed = true;
    }
}
