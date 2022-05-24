using UnityEngine;
using UnityEngine.Advertisements;

public class Interstitial_Ads : MonoBehaviour, IUnityAdsLoadListener,IUnityAdsShowListener
{
[SerializeField] string _androidAdUnitId = "Interstitial_Android";
[SerializeField] string _iOsAdUnitId = "Interstitial_iOS";
string _adUnitId;


void Awake()
{
// Get the Ad Unit ID for the current platform:
_adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
? _iOsAdUnitId
: _androidAdUnitId;
}

private void Start()
{
    LoadAd();
}

// Load content to the Ad Unit:
public void LoadAd()
{
// IMPORTANT! Only load content AFTER initialization (in this example, initialization is handled in a different script).
Debug.Log("Loading Ad: " + _adUnitId);
Advertisement.Load(_adUnitId);
}

// Show the loaded content in the Ad Unit:
public void ShowAd()
{
// Note that if the ad content wasn't previously loaded, this method will fail
Debug.Log("Showing Ad: " + _adUnitId);
Advertisement.Show(_adUnitId);
LoadAd();
}

public void OnUnityAdsAdLoaded(string placementId)
{
    throw new System.NotImplementedException();
}

public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
{
    throw new System.NotImplementedException();
}

public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
{
    FindObjectOfType<Admob_Interstitial>().ShowInterstitial();
}

public void OnUnityAdsShowStart(string placementId)
{
    throw new System.NotImplementedException();
}

public void OnUnityAdsShowClick(string placementId)
{
    throw new System.NotImplementedException();
}

public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
{
    throw new System.NotImplementedException();
}

}