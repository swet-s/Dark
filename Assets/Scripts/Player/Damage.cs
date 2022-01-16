using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public Animator damage;

    public void OnCollosionWithEnemy()
    {
       Invincible();
    }

    public void Invincible()
    {
        StartCoroutine("IdleAgain");
    }



    IEnumerator IdleAgain()
    {
        yield return new WaitForSeconds(0.1f);
        FindObjectOfType<AudioCreater>().PlayAhh();
        damage.SetBool("damaging", true);
        gameObject.layer = 13;
        yield return new WaitForSeconds(1);
        gameObject.layer = 9;
        damage.SetBool("damaging", false);
    }
}
