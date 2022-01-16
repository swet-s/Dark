using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int power = 40;
    public float destroyAfter = 1f;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        Destroy(gameObject, destroyAfter);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHealth health =  collision.GetComponent<EnemyHealth>();
        if (health)
        {
            health.takeDamageEnemy(power);
        }
        Destroy(gameObject);
    }
}
