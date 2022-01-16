using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Events;

public class Boss : MonoBehaviour
{
    public Collider2D myCollider;
    public Vector3[] SpawnPos;

    public float IdleTime;
    public Material fade;
    Material bossMat;

    public float speed;
    public int power;
    public Vector2 impulse;
    public float attackRange;

    public Animator animator;

    [HideInInspector]
    public bool isFlipped = false;
    Rigidbody2D rb;
    Transform player;
    bool UpdateNow = true;

    public int lastPos = 0;
    public int currentPos = 0;
    public int pain = 0;


    public Transform[] spitPoint;
    public GameObject pius;
    public GameObject piusPro;
    public bool isEnraged;
    public bool isSuperEnraged;

    public EnemyHealth health;
    public GameObject hold;
    public Vector2 enrageHealth;

    void Start()
    {
        bossMat = GetComponent<SpriteRenderer>().material;
        GetComponent<SpriteRenderer>().material = fade;
        OnStartEvent.Invoke();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void OnDamage()
    {
        OnDamageEvent.Invoke();
        animator.SetTrigger("Damaging");
        rb.AddForce(impulse*-50);
        FindObjectOfType<AudioCreater>().PlayPain();
        pain++;
        
    }

    void Spit()
    {
        if (isEnraged)
        {
            foreach (Transform spit in spitPoint)
            {
                GameObject kid;
                kid = Instantiate(pius, spit.position, spit.rotation);
                kid.transform.SetParent(hold.transform);
            }
        }
        else if (isSuperEnraged)
        {
            foreach (Transform spit in spitPoint)
            {
                GameObject kid;
                kid = Instantiate(piusPro, spit.position, spit.rotation);
                kid.transform.SetParent(hold.transform);
            }
        }
    }

    void Update()
    {
        Pius1 pius= FindObjectOfType<Pius1>();
        if (pius)
        {
            pius.transform.SetParent(hold.transform);
        }
        float dist = Vector3.Distance(transform.position, player.position);
        if (dist < attackRange)
        {
            animator.SetTrigger("Attacking");
            Debug.Log("Acc");
        }
        else
        {
            MoveTowardPlayer();
        }

        if (health.health < enrageHealth.x && health.health > enrageHealth.y)
        {
            isEnraged = true;
        }
        else if (health.health <= enrageHealth.y)
        {
            isEnraged = false;
            isSuperEnraged = true;
        }

        // Fade Logics
        if (UpdateNow)
        {
            StartCoroutine("Fade");
        }
    }

    Vector3 Reappear()
    {
        lastPos = currentPos;
        return SpawnPos[currentPos];
    }

    #region Fade
    IEnumerator Fade()
    {
        UpdateNow = false;

        // Part of Logic

        StartCoroutine(SlideFadeIntro());
        FindObjectOfType<AudioCreater>().PlayFadeIn();
        yield return new WaitForSeconds(1f);
        Spit();
        myCollider.enabled = true;
        rb.gravityScale = 1;
        GetComponent<SpriteRenderer>().material = bossMat;
        yield return new WaitForSeconds(IdleTime);

        while (currentPos == lastPos)
        {
            yield return new WaitForSeconds(0.1f);
            if (pain >= 2)
            {
                pain = 0;
                int random = UnityEngine.Random.Range(0, 5);
                while (currentPos == random)
                    random = UnityEngine.Random.Range(0, 5);
                currentPos = random;
                break;
            }
        }
        myCollider.enabled = false;
        rb.gravityScale = 0;
        FindObjectOfType<AudioCreater>().PlayFadeOut();
        GetComponent<SpriteRenderer>().material = fade;
        StartCoroutine(SlideFade());

        foreach (Transform kid in hold.transform)
        {
            try
            {
                kid.GetComponent<SpriteRenderer>().material = fade;
            }
            catch (Exception) { }
            Destroy(kid.gameObject, 1f);
        }

        yield return new WaitForSeconds(1f);
        transform.position = Reappear();


        UpdateNow = true;
    }

    IEnumerator SlideFade()
    {
        float intensity = 0.5f;
        for (int i = 0; i <= 50; i++)
        {
            intensity -= Time.fixedDeltaTime / 2;
            yield return new WaitForFixedUpdate();
            fade.SetFloat("_Intensity", intensity);
        }
    }
    IEnumerator SlideFadeIntro()
    {
        float intensity = 0f;
        for (int i = 0; i <= 50; i++)
        {
            intensity += Time.fixedDeltaTime / 2;
            yield return new WaitForFixedUpdate();
            fade.SetFloat("_Intensity", intensity);
        }
    }

    #endregion

    #region Events
    [Header("Events")]

    public UnityEvent OnStartEvent;
    public class BoolEvent : UnityEvent<bool> { }

    public UnityEvent OnDamageEvent;
    public class BoolEvent1 : UnityEvent<bool> { }
    #endregion

    #region Follow Player
    public void MoveTowardPlayer()
    {
        if (transform.position.x > player.position.x && isFlipped || transform.position.x < player.position.x && !isFlipped)
        {
            Flip();
        }
        rb.velocity = new Vector2(transform.right.x * -speed, rb.velocity.y);
    }
    #endregion

    #region Damage & Flip
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Health giveDamage = collision.gameObject.GetComponent<Health>();
            Damage getDamage = collision.gameObject.GetComponent<Damage>();
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            giveDamage.takeDamage(power);
            getDamage.OnCollosionWithEnemy();
            rb.AddForce(impulse);
            Flip();
        }

        if (collision.gameObject.layer == 14 || collision.gameObject.layer == 11)
        {
            Flip();
        }

    }

    public void Flip()
    {
        if (isFlipped)
        {
            speed *= -1;
            impulse *= -1;
            isFlipped = false;
        }
        else if (!isFlipped)
        {
            speed *= -1;
            isFlipped = true;
            impulse *= -1;
        }

    }
    #endregion

}
