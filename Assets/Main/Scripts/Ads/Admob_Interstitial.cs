using System;
using GoogleMobileAds.Api;
using UnityEngine;

public class Admob_Interstitial : MonoBehaviour
{
    private InterstitialAd interstitial;

    private void Start()
    {
        RequestInterstitial();
    }

    private void RequestInterstitial()
        {
            #if UNITY_ANDROID
                string adUnitId = "ca-app-pub-9020299910602817/1880569053";
            #elif UNITY_IPHONE
                    string adUnitId = "ca-app-pub-3940256099942544/4411468910";
            #else
                    string adUnitId = "unexpected_platform";
            #endif

            // Initialize an InterstitialAd.
            this.interstitial = new InterstitialAd(adUnitId);
            // Create an empty ad request.
            AdRequest request = new AdRequest.Builder().Build();
            // Load the interstitial with the request.
            this.interstitial.LoadAd(request);
        }

    public void ShowInterstitial()
    {
        if (interstitial.IsLoaded()) {
            interstitial.Show();
        }
        else
        {
            RequestInterstitial();
            FindObjectOfType<Interstitial_Ads>().ShowAd();
        }
    }
    
}
