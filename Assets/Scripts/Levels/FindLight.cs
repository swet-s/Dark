using UnityEngine;
using UnityEngine.Events;

public class FindLight : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject lightSource;
    public GameObject equipedLight;
    public Vector2 Speed;
    void Start()
    {
        lightSource.SetActive(true);
        equipedLight.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnTrigger.Invoke();
        FindObjectOfType<AudioCreater>().PlayEquip();
        Rigidbody2D player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        player.velocity = Speed;
    }

    [Header("Events")]

    public UnityEvent OnTrigger;
    public class BoolEvent : UnityEvent<bool> { }
}
