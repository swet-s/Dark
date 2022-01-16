using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public Button pauseButton;


    private void OnEnable()
    {
        FindObjectOfType<AudioCreater>().PlayClick();
    }
    private void Start()
    {
        foreach (Transform menu in transform)
        {
            foreach(Transform butt in menu)
            {
                butt.GetComponent<Button>().onClick.AddListener(() => { ClickSound(); });
            }
        }
    }
    public void PauseGame()
    {
        if (GameIsPaused == false)
        {
            pauseButton.interactable = false;
            FindObjectOfType<AudioCreater>().PauseTheme2();
            Time.timeScale = 0f;
            GameIsPaused = true;
        }
    }
    
    public void ClickSound()
    {
        FindObjectOfType<AudioCreater>().PlayClick();
    }

    public void Resume()
    {
        if (GameIsPaused)
        {
            pauseButton.interactable = true;
            FindObjectOfType<AudioCreater>().ResumeTheme2();
            Time.timeScale = 1f;
            GameIsPaused = false;
        }
        
    }

    public void BackToMenu()
    {
        FindObjectOfType<AudioCreater>().PlayClick();
        Resume();
        FindObjectOfType<AudioCreater>().ResumeTheme();
        SceneManager.LoadScene(1);
    }
    public void BackToAllLevels()
    {
        FindObjectOfType<AudioCreater>().PlayClick();
        Resume();
        FindObjectOfType<AudioCreater>().ResumeTheme();
        SceneManager.LoadScene(2);
    }

}
