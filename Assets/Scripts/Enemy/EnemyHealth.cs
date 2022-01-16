using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    public int health = 100;
    public GameObject deathEffect;
    public GameObject transformTo;
    public float effectTime = 0.4f;
    public GameObject newbie;

    public void takeDamageEnemy(int damage)
    {
        if (gameObject.tag == "Boss")
        {
            GetComponent<Boss>().OnDamage();
        }
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        OnDieEvent.Invoke();
        if (deathEffect && !transformTo)
        {
            GameObject deathEffectClone = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(deathEffectClone, effectTime);
        }
        if (transformTo)
        {
            bool flipped = gameObject.GetComponent<Pius1>().isFlipped;
            GameObject deathEffectClone = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(deathEffectClone, 0.1f);
            newbie = Instantiate(transformTo, transform.position, Quaternion.identity);
            newbie.transform.Rotate(0f, 180f, 0f);
        }
        Destroy(gameObject);
    }

    public void DieAfter(float sec)
    {
        StartCoroutine(DieSec(sec));
    }

    IEnumerator DieSec(float time)
    {
        yield return new WaitForSeconds(time);
        Die();
    }


    [Header("Events")]
   
    public UnityEvent OnDieEvent;
    public class BoolEvent : UnityEvent<bool> { }
}

