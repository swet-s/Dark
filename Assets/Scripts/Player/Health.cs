using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int health = 100;
    ScoreManager player;

    void Start()
    {
        player = GetComponent<ScoreManager>();
        health = PlayerPrefs.GetInt("Health", health);
    }

    void Update()
    {
        if (health <= 0)
        {
            Broke();
        }

        player.UpdateHealth(health);
    }

    public void takeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            OnDie.Invoke();
            GameObject canvas = Resources.Load<GameObject>("DieMessage");
            DisableShoot();
            Instantiate(canvas);
            health = 0;
            Timer.RecordTime();
        }
    }

    public void DisableShoot()
    {
        GunManager shoot = GetComponent<GunManager>();

        if (shoot)
        {
            shoot.isShooting = false;
            shoot.shootCanvas.SetActive(false);
        }
    }

    public void takelife(int power)
    {
        health += power;
        if (health > 100)
            health = 100;
    }

    public void Broke()
    {
        StartCoroutine(Die());
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(2);
        FindObjectOfType<AudioCreater>().ResumeTheme();
        SceneManager.LoadScene(2);
    }


    [Header("Events")]

    public UnityEvent OnDie;
    public class BoolEvent : UnityEvent<bool> { }
}
