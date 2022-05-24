using System;
using GoogleMobileAds.Api;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Admob_Banner : MonoBehaviour {
    
    
    private BannerView bannerView;

    public void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex!=1||SceneManager.GetActiveScene().buildIndex != 5||SceneManager.GetActiveScene().buildIndex != 6)
        {
            RequestBanner();
            if (SceneManager.GetActiveScene().buildIndex==4)
            {
                bannerView.SetPosition(AdPosition.BottomRight);
            }
            else
            {
                bannerView.SetPosition(AdPosition.TopLeft);
            }
        }
    }

    public void RequestBanner()
    {

        #if UNITY_ANDROID
            string adUnitId = "ca-app-pub-9020299910602817/6534129931";
        #elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/2934735716";
        #else
            string adUnitId = "unexpected_platform";
        #endif

        this.bannerView = new BannerView(adUnitId, AdSize.Banner,AdPosition.TopLeft);

        // Called when an ad request has successfully loaded.
        this.bannerView.OnAdLoaded += this.HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.bannerView.OnAdFailedToLoad += this.HandleOnAdFailedToLoad;
        // Called when an ad is clicked.
        this.bannerView.OnAdOpening += this.HandleOnAdOpened;
        // Called when the user returned from the app after an ad click.
        this.bannerView.OnAdClosed += this.HandleOnAdClosed;


        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        bannerView.LoadAd(request);
    }

    

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        print("");
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        FindObjectOfType<Banner_Ads>().LoadBanner();
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }

    private void OnDestroy()
    {
        if (bannerView!=null)
        {
            bannerView.Hide();
        }
    }
}
