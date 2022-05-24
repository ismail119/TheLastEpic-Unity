using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SceneManagement.Scene;

public class MapCanvas : MonoBehaviour
{
    private Scene[] maps;
    private DatabaseSkeleton old;
    private int indexOfMap;
    [SerializeField] private TextMeshProUGUI health, energy, coin;

    [SerializeField] private GameObject nextMapButton,previosMapButton;

    [SerializeField] private GameObject WarningPopUp;
    [SerializeField] private GameObject warriorCross;
    [SerializeField] private GameObject Arrow;

    private void Awake()
    {
        maps = new[]
        {
            SceneManager.GetSceneByBuildIndex(2), SceneManager.GetSceneByBuildIndex(3),
            SceneManager.GetSceneByBuildIndex(4)
        };
        indexOfMap = Array.IndexOf(maps, SceneManager.GetActiveScene());
        old = FindObjectOfType<PlayerPrefsOperations>().GetData();
        MapArrowsControl();
        ReloadStatus();

        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (old.isWarriorDead)
            {
                RemoveWarrior();
            }
        }
    }

    
    public void RemoveWarrior()
    {
        warriorCross.SetActive(true);
    }

    public void ReloadStatus()
    {
        DatabaseSkeleton data;
        data = FindObjectOfType<PlayerPrefsOperations>().GetData();
        health.text = data.currentHealth.ToString();
        energy.text = data.currentEnergy.ToString();
        coin.text = data.totalCoin.ToString();
        
    }


    private void MapArrowsControl()
    {
        if (old.openedMaps.Contains(indexOfMap+1))
        {
            nextMapButton.SetActive(true);
        }
        else
        {
            nextMapButton.SetActive(false);
        }

        if (old.openedMaps.Contains(indexOfMap-1))
        {
            previosMapButton.SetActive(true);
        }
        else
        {
            previosMapButton.SetActive(false);
        }
    }
    
    
    
    public void HomeButton()
    {
        FindObjectOfType<LevelLoader>().LoadLevel(1);
    }

    public void GoToWar()
    {
        if (PlayerPrefsOperations.Instance.GetData().isReadAll)
        {
            FindObjectOfType<MusicManager>().PlayBattleMusic();
            FindObjectOfType<LevelLoader>().LoadLevel(5);
        }
        else
        {
            WarningPopUp.SetActive(true);
        }
    }
    
    
    public void CloseWarningPanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    public void NextMap()
    {
        FindObjectOfType<LevelLoader>().LoadLevel(SceneManager.GetActiveScene().buildIndex+1);
        if (PlayerPrefsOperations.Instance.GetData().InterstitialCounter%4==0)
        {
            FindObjectOfType<Interstitial_Ads>().ShowAd();
        }
        DatabaseSkeleton old = PlayerPrefsOperations.Instance.GetData();
        old.InterstitialCounter += 1;
        PlayerPrefsOperations.Instance.SaveData(old);
    }
    
    public void PreviousMap()
    {
        FindObjectOfType<LevelLoader>().LoadLevel(SceneManager.GetActiveScene().buildIndex-1);
        if (PlayerPrefsOperations.Instance.GetData().InterstitialCounter%4==0)
        {
            FindObjectOfType<Interstitial_Ads>().ShowAd();
        }
        DatabaseSkeleton old = PlayerPrefsOperations.Instance.GetData();
        old.InterstitialCounter += 1;
        PlayerPrefsOperations.Instance.SaveData(old);
    }
}
