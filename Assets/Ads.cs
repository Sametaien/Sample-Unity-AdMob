using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using System;
using UnityEngine.UI;

public class Ads : MonoBehaviour
{
   
    private InterstitialAd interstitialAd;
    private RewardedAd rewardedAd;

    public Text rewardLog;

    private string interstialID = "ca-app-pub-3940256099942544/8691691433"; // These are Test Ad IDs
    private string rewardedID = "ca-app-pub-3940256099942544/5224354917";

    private void Start()
    {
        RequestInter();
        RequestRewarded();
    }


    void RequestRewarded()
    {
        rewardedAd = new RewardedAd(rewardedID);
        rewardedAd.OnAdFailedToLoad += failedToLoad;
        rewardedAd.OnAdFailedToShow += failedToShow;
        rewardedAd.OnUserEarnedReward += userEarnedReward;
        rewardedAd.LoadAd(requestingAds());
    }


    public void RewardedAdView()
    {
        if (rewardedAd.IsLoaded())
        {
            rewardedAd.Show();
        }
        else
        {
            RequestRewarded();
        }
    }


    void RequestInter()
    {
        interstitialAd = new InterstitialAd(interstialID);
        interstitialAd.OnAdFailedToLoad += failedToLoad;
        interstitialAd.OnAdLoaded += adLoaded;
        interstitialAd.OnAdClosed += adClosed;
        interstitialAd.LoadAd(requestingAds());
    }

    public void GameOver()
    {
        if (interstitialAd.IsLoaded())
        {
            interstitialAd.Show();
        }
        else
        {
            RequestInter();
        }
    }

    


    #region Events
    private void adLoaded(object sender, EventArgs e)
    {
        Debug.Log("The ad was successfully loaded.");
    }

    private void userEarnedReward(object sender, Reward args)
    {
        Debug.Log("The user won the award.");
        string type = args.Type;
        double amount = args.Amount;
        rewardLog.text = "Price type: " + type + "Price amount:" + amount + " \n";
    }

    private void failedToShow(object sender, AdErrorEventArgs e)
    {
        Debug.Log("There's a problem with advertising.");
    }
    private void adClosed(object sender, EventArgs e)
    {
        Debug.Log("The ad is closed.");
        RequestInter();
    }
    private void failedToLoad(object sender, AdFailedToLoadEventArgs e)
    {
        Debug.LogError("Reklam yüklenmesinde sorun oluþtu.");
        //RequestBannerBot();
        //RequestBannerTop();
        RequestInter(); // If we do not create a request again after the ad is closed, another ad will not occur, so we create a request again here.
    }

    #endregion

    AdRequest requestingAds()
    {
        return new AdRequest.Builder().Build();
    }


}
