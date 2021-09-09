using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using System;


public class BannerAds : MonoBehaviour
{
    private BannerView bannerViewBot;
    private BannerView bannerViewTop;

    private string bannerBotID = "ca-app-pub-3940256099942544/6300978111"; // These are Banner Test Ad IDs
    private string bannerTopID = "ca-app-pub-3940256099942544/6300978111"; // Please use them when testing, if you are not testing, you can use the ad IDs you received through AdMob.



    private void Start()
    {
        RequestBannerBot();
        RequestBannerTop();
    }



    void RequestBannerBot()
    {
        bannerViewBot = new BannerView(bannerBotID, AdSize.Banner, AdPosition.Bottom);

        bannerViewBot.OnAdFailedToLoad += failedToLoad;
        bannerViewBot.OnAdLoaded += adLoaded;
        bannerViewBot.OnAdClosed += adClosed;

        AdRequest requestBot = new AdRequest.Builder().Build();
        bannerViewBot.LoadAd(requestBot);
    }


    void RequestBannerTop()
    {
        bannerViewTop = new BannerView(bannerTopID, AdSize.Banner, AdPosition.Top);
        bannerViewTop.OnAdFailedToLoad += failedToLoad;
        bannerViewTop.OnAdLoaded += adLoaded;
        bannerViewTop.OnAdClosed += adClosed;
        AdRequest requestTop = new AdRequest.Builder().Build();
        bannerViewTop.LoadAd(requestTop);
    }



    AdRequest requestingAds()
    {
        return new AdRequest.Builder().Build();  // You can also use this section in the LoadAd process.
    }

    /*  An example
     
        AdRequest requestTop = new AdRequest.Builder().Build(); ----> if you are using the" requestingAds " section, you do not need this line.
        bannerViewTop.LoadAd(requestTop); ----> this line should be changed as follows; bannerViewTop.LoadAd(requestingAds());
     
     */

    #region Events
    private void adLoaded(object sender, EventArgs e)
    {
        Debug.Log("The ad was successfully loaded.");
    }
    private void adClosed(object sender, EventArgs e)
    {
        Debug.Log("The ad is closed.");
    }
    private void failedToLoad(object sender, AdFailedToLoadEventArgs e)
    {
        Debug.LogError("There was a problem loading ads.");
        
    }
    #endregion
}
