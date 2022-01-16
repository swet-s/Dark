using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionEvent : MonoBehaviour
{
    public bool destroy = false;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            FindObjectOfType<AudioCreater>().PlayEquip();
            OnTrigger.Invoke();
            Debug.Log("gg");
            if (destroy)
            {
                Destroy(gameObject);
            }
        }
    }
    [Header("Events")]

    public UnityEvent OnTrigger;
    public class BoolEvent : UnityEvent<bool> { }
}
