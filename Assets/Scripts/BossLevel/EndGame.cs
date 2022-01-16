using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    TextMeshProUGUI timer;
    Button back;
    float time = 10f;
    bool timerHasStared = false;

    public GameObject[] toBeDisable;
    private void Awake()
    {
        SimpleAds.InitialiseAds();
    }
    public void GameOver()
    {
        StartCoroutine(GoodBye());
        StartCoroutine(NextLevel());
    }

    private void FixedUpdate()
    {
        if (timerHasStared)
        {
            timer.text = "Quiting Game in  " + (int) time + " sec...";
            time -= Time.fixedDeltaTime;
        }
    }

    IEnumerator GoodBye()
    {
        yield return new WaitForSeconds(2f);

        foreach (GameObject disable in toBeDisable)
            disable.SetActive(false);

        GameObject goodBye = Resources.Load<GameObject>("FinalCanvas");
        GameObject panel = Instantiate(goodBye);
        back = panel.GetComponentInChildren<Button>();
        back.onClick.AddListener(() => { Back(); });
        timer = panel.GetComponentInChildren<TextMeshProUGUI>();
        timerHasStared = true;
    }
    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(12f);
        Back();
    }

   public void Back()
    {
        FindObjectOfType<AudioCreater>().PlayClick();
        FindObjectOfType<AudioCreater>().ResumeTheme();
        if (PlayerPrefs.GetInt("levelReached") < SceneManager.GetActiveScene().buildIndex-1)
            PlayerPrefs.SetInt("levelReached", SceneManager.GetActiveScene().buildIndex-1);
        SimpleAds.RequestInterstitial();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 18);

    }
}
