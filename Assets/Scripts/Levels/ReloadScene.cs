using System.Collections;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    public Transform player;
    public float delay = 2f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(reload());
            OnFalling.Invoke();
        }
    }

    IEnumerator reload()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    [Header("Events")]

    public UnityEvent OnFalling;
    public class BoolEvent : UnityEvent<bool> { }
}
