using System;
using System.Collections;
using UnityEngine;
using GoogleMobileAds.Api;

public static class SimpleAds
{
    //App_ID = "ca-app-pub-4260167359174091~3318427782";

    public static bool AdOpened = false;
    public static bool AdClosed = true;


    static bool TestMode = false;
    static string InterstialAd_ID;


    static private InterstitialAd interstitial;

    static public bool testmode = false;


    public static void InitialiseAds()
    {
        if (TestMode)
            InterstialAd_ID = "ca-app-pub-3940256099942544/1033173712";
        else
            InterstialAd_ID = "ca-app-pub-4260167359174091/6962993476";

        interstitial = new InterstitialAd(InterstialAd_ID);

        interstitial.OnAdLoaded += HandleOnAdLoaded;
        interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        interstitial.OnAdOpening += HandleOnAdOpened;
        interstitial.OnAdClosed += HandleOnAdClosed;
        interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;
        
        AdRequest request = new AdRequest.Builder().Build();
        interstitial.LoadAd(request);

    }

    //if (Application.internetReachability != NetworkReachability.NotReachable && UnityEngine.Random.Range(0, 6) == 0)
    public static void RequestInterstitial()
    {
        if (interstitial.IsLoaded())
        {
           interstitial.Show();
        }
    }


    static public void HandleOnAdLoaded(object sender, EventArgs args)
    {
    }

    static public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        interstitial.Destroy();
    }

    static public void HandleOnAdOpened(object sender, EventArgs args)
    {
        AdClosed = false;
        AdOpened = true;
    }

    static public void HandleOnAdClosed(object sender, EventArgs args)
    {
        AdClosed = true;
        AdOpened = false;
        interstitial.Destroy();
    }

    static public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        interstitial.Destroy();
    }

}
