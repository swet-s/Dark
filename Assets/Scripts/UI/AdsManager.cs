using System;
using System.Collections;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdsManager : MonoBehaviour
{

    //App_ID = "ca-app-pub-4260167359174091~3318427782";


    private RewardedAd rewardedAd;
    private string RewardedAd_ID;

    public AllLevels ads;
    string AdsForWhat;
    public DarkData testMode;

    public GameObject loadingAd;
    public GameObject loadFailed;

    void Start()
    {
        if (testMode.Enable)
            RewardedAd_ID = "ca-app-pub-3940256099942544/5224354917";
        else
            RewardedAd_ID = "ca-app-pub-4260167359174091/6700443051";

        rewardedAd = new RewardedAd(RewardedAd_ID);
        InitialiseAds();
    }

    void InitialiseAds()
    {

        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;
        this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;

        AdRequest request = new AdRequest.Builder().Build();
        rewardedAd.LoadAd(request);

    }

    public void ShowAd(string forWhat)
    {
        AdsForWhat = forWhat;
        loadingAd.SetActive(true);


        if (rewardedAd.IsLoaded())
        {
            rewardedAd.Show();
            loadingAd.SetActive(false);
        }

        else
        {
            Retry();
        }

    }

    public void Retry()
    {
        StartCoroutine("Loading");
    }

    IEnumerator Loading()
    {
        loadFailed.SetActive(false);
        loadingAd.SetActive(true);
        yield return new WaitForSeconds(3);
        if (rewardedAd.IsLoaded())
        {
            rewardedAd.Show();
        }
        else
        {
            loadingAd.SetActive(false);
            loadFailed.SetActive(true);
        }
    }


    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        FindObjectOfType<AudioCreater>().PauseTheme();
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        FindObjectOfType<AudioCreater>().PauseTheme(true);
        loadingAd.SetActive(false);
    }


    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        Debug.Log(type);
        Debug.Log(amount);

        if (AdsForWhat == "Lives")
        {
            ads.WatchVideo();
        }
        else if (AdsForWhat == "Ammo")
        {
            ads.WatchVideoForAmmo();
        }
        AdsForWhat = null;
    }
}
