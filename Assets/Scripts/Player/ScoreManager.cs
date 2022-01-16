using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public Text coins;
    public Text ammo;
    public Text health;
    public TextMeshProUGUI level;
    public TextMeshProUGUI aim;
    public int CoinCount = 0;

    string[] aims =
    {
        "Getting Started...",
        "The Maze",
        "Jump.. Jump.. Jump.. ",
        "Find the Gun",
        "Pius hates You",
        "Subway",
        "Destroy",
        "Up and Up",
        "Find The Way out",
        "Dockyard", 
        "Firefly Forest",
        "So Hard",
        "Bucket",
        "Prepare For a Dive",
        "Collect Some Cockles",
        "Shapes",
        "Outskirts",
        "Crash"
    };

    void Start()
    {
        coins.text = "<color=#3A6C41>M</color>  " + PlayerPrefs.GetInt("TotalCoin", 0);
        level.text = "Level " + (SceneManager.GetActiveScene().buildIndex - 2);
        aim.text = aims[(SceneManager.GetActiveScene().buildIndex - 3)];
    }

    public void UpdateCoin()
    {
        CoinCount = PlayerPrefs.GetInt("TotalCoin", 0);
        CoinCount++;
        PlayerPrefs.SetInt("TotalCoin", CoinCount);
        coins.text = "<color=#3A6C41>M</color>  " + CoinCount;
    }
    public void UpdateAmmo(int ammoCount)
    {
        ammo.text = "<color=#A4A4A4>b</color>  " + ammoCount;
        PlayerPrefs.SetInt("TotalAmmo", ammoCount);
    }

    public void UpdateHealth(int currenthealth)
    {
        string lives;
        if (currenthealth > 80)
            lives = "OOOOO";
        else if (currenthealth > 60)
            lives = "OOOO";
        else if (currenthealth > 40)
            lives = "OOO";
        else if (currenthealth > 20)
            lives = "OO";
        else if (currenthealth > 0)
            lives = "O";
        else
            lives = "";
        health.text = lives;
        PlayerPrefs.SetString("Lives", lives);
        PlayerPrefs.SetInt("Health", currenthealth);
    }
}
