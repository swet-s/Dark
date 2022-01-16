using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Falling : MonoBehaviour
{
    public Transform player;
    public Transform CameraFlow = null;
    public Vector3 position;
    public Vector3 resetPos;
    public float delay = 2f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
           StartCoroutine(port());
           OnFalling.Invoke();
        }
    }

    IEnumerator port()
    {
        yield return new WaitForSeconds(delay);
        player.position = position;
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        if(CameraFlow)
        {
            CameraFlow.position = resetPos;
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }

    [Header("Events")]

    public UnityEvent OnFalling;
    public class BoolEvent : UnityEvent<bool> { }
}    
