using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portal : MonoBehaviour
{
    public Transform player;
    public Vector3 position;
    public float timeDelay = 0f;
    public bool LevelEnd = false;

    private void Start()
    {
        SimpleAds.InitialiseAds();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (LevelEnd)
            {
                FindObjectOfType<AudioCreater>().PlayEnlighten();
                StartCoroutine(NextLevel());
            }
            else
                StartCoroutine(port());
        }
    }

    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(timeDelay);
       if (PlayerPrefs.GetInt("levelReached") < SceneManager.GetActiveScene().buildIndex-1)
            PlayerPrefs.SetInt("levelReached", SceneManager.GetActiveScene().buildIndex-1);

        if (Random.Range(0, 2) == 0)
            SimpleAds.RequestInterstitial();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    IEnumerator port()
    {
        yield return new WaitForSeconds(timeDelay);
        player.position = position;
    }
}
