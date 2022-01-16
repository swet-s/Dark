using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AllLevels : MonoBehaviour
{
    public GameObject LevelMenu;
    public GameObject ShopMenu;
    public GameObject AmmoMenu;
    public TextMeshProUGUI noMoreCoin;
    public Text money;
    public Text lives;
    public Text livesTimer;
    public Button[] levelButtons;
    private int ammoCount;

    void Start ()
    {
        FindObjectOfType<AudioCreater>().PauseTheme(true);
        money.text = "<color=#3A6C41>M</color>  " + PlayerPrefs.GetInt("TotalCoin", 0);
        lives.text = PlayerPrefs.GetString("Lives", "OOOOO");
        ammoCount = PlayerPrefs.GetInt("TotalAmmo", 30);
        int levelReached = PlayerPrefs.GetInt("levelReached", 1); 

        if (lives.text == "")
        {
            LevelMenu.gameObject.SetActive(false);
            livesTimer.gameObject.SetActive(true);
            ShopMenu.gameObject.SetActive(true);
        }
        else if (ammoCount <= 0)
        {
            LevelMenu.gameObject.SetActive(false);
            AmmoMenu.gameObject.SetActive(true);
        }

        for (int i = 0; i < levelButtons.Length; i++)
        {
           
            ColorBlock colors = levelButtons[i].colors;
            colors.normalColor = new Color32(255, 255, 255, 0);
            colors.disabledColor = new Color32(255, 255, 255, 128);
            levelButtons[i].colors = colors;
            if (i + 1 > levelReached)
            {
                levelButtons[i].interactable = false;
                TextMeshProUGUI levelText = levelButtons[i].GetComponentInChildren<TextMeshProUGUI>();
                levelText.gameObject.SetActive(false);
            }
            if (i < levelReached - 1)
            {
                GameObject done = Resources.Load<GameObject>("image");
                GameObject done1 = Instantiate(done);
                done1.transform.SetParent(levelButtons[i].transform);
                done1.GetComponent<RectTransform>().localPosition = new Vector3(20, -12, 0);
                done1.GetComponent<RectTransform>().localScale = new Vector3(1, 1);
            }
        }
        
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("LivesSorted", 1) == 0)
        {
            PlayerPrefs.SetString("Lives", "OOOOO");
            PlayerPrefs.SetInt("Health", 100);
            lives.text = PlayerPrefs.GetString("Lives");
            FindObjectOfType<FadeTrigger>().Fade();
            if (ammoCount == 0)
            {
                AmmoMenu.gameObject.SetActive(true);
                ShopMenu.gameObject.SetActive(false);
            }
            else
            {
                LevelMenu.gameObject.SetActive(true);
                ShopMenu.gameObject.SetActive(false);
            }

            livesTimer.gameObject.SetActive(false);
            PlayerPrefs.SetInt("LivesSorted", 1);
        }
    }


    public void BuyLives()
    {
        int coin = PlayerPrefs.GetInt("TotalCoin", 0);
        if (coin >= 100)
        {
            FindObjectOfType<FadeTrigger>().Fade();
            if (ammoCount == 0)
            {
                AmmoMenu.gameObject.SetActive(true);
                ShopMenu.gameObject.SetActive(false);
            }
            else
            {
                LevelMenu.gameObject.SetActive(true);
                ShopMenu.gameObject.SetActive(false);
            }


            coin -= 100;
            PlayerPrefs.SetInt("TotalCoin", coin);
            PlayerPrefs.SetString("Lives", "OOOOO");
            PlayerPrefs.SetInt("Health", 100);
            money.text = "<color=#3A6C41>M</color>  " + PlayerPrefs.GetInt("TotalCoin", 0);
            lives.text = PlayerPrefs.GetString("Lives", "OOOOO");
        }
        else
        {
            TextMeshProUGUI warningClone = Instantiate(noMoreCoin);
            UIMethods.PositionUI(warningClone.GetComponent<RectTransform>(), noMoreCoin.GetComponent<RectTransform>(), ShopMenu);
            warningClone.gameObject.SetActive(true);
            Destroy(warningClone.gameObject, 2.5f);
        }
    }
    public void BuyAmmo()
    {
        int coin = PlayerPrefs.GetInt("TotalCoin", 0);
        if (coin >= 30)
        {
            FindObjectOfType<FadeTrigger>().Fade();
            LevelMenu.gameObject.SetActive(true);
            AmmoMenu.gameObject.SetActive(false);
            coin -= 30;
            PlayerPrefs.SetInt("TotalCoin", coin);
            PlayerPrefs.SetInt("TotalAmmo", 30);
            money.text = "<color=#3A6C41>M</color>  " + PlayerPrefs.GetInt("TotalCoin", 0);
        }
        else
        {
            TextMeshProUGUI warningClone = Instantiate(noMoreCoin);
            UIMethods.PositionUI(warningClone.GetComponent<RectTransform>(), noMoreCoin.GetComponent<RectTransform>(), AmmoMenu);
            warningClone.gameObject.SetActive(true);
            Destroy(warningClone.gameObject, 2.5f);
        }
    }
    public void WatchVideoForAmmo()
    {
        LevelMenu.gameObject.SetActive(true);
        AmmoMenu.gameObject.SetActive(false);
        PlayerPrefs.SetInt("TotalAmmo", 30);
        Debug.Log("Video Watched");

    }
    public void WatchVideo()
    {
        if (ammoCount == 0)
        {
            AmmoMenu.gameObject.SetActive(true);
            ShopMenu.gameObject.SetActive(false);
        }
        else
        {
            LevelMenu.gameObject.SetActive(true);
            ShopMenu.gameObject.SetActive(false);
        }
        Debug.Log("Video Watched");
        PlayerPrefs.SetString("Lives", "OOOOO");
        PlayerPrefs.SetInt("Health", 100);
        lives.text = PlayerPrefs.GetString("Lives", "OOOOO");
        
    }

        public void BacktoMenu()
    {
        SceneManager.LoadScene(1);
    }
    public void Quitgame()
    {
        Application.Quit();
    }
    public void Level(int levelindex)
    {
        SceneManager.LoadScene(levelindex + 2);
        AudioCreater theme2 = FindObjectOfType<AudioCreater>();
        if (theme2)
        {
            theme2.PlayTheme2();
        }
    }
}
