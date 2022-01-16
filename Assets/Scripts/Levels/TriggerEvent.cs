using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{
    public bool destroy = false;
    public bool audible = true;

    public void PlayEquip()
    {
        if (audible)
        FindObjectOfType<AudioCreater>().PlayEquip();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayEquip();
            OnTrigger.Invoke();
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
