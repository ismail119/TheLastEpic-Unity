using System;
using UnityEngine;
using GoogleMobileAds.Api;


public class GameManager : MonoBehaviour
{
    private PlayerPrefsOperations _playerPrefsOperations;
    [SerializeField] GameObject SignPanel;


    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    private void Start()
    {
        
        _playerPrefsOperations = FindObjectOfType<PlayerPrefsOperations>();
        FindObjectOfType<MusicManager>().PlayMenuMusic();

        if (_playerPrefsOperations.GetData().isFirst)
            Invoke(nameof(SignPanelUp), .25f);
        else
        {
            FindObjectOfType<MainCanvas>().GoToMainMenu();
            FindObjectOfType<MainCanvas>().OpenSoundPanel();
        }
    }
    
    void SignPanelUp()
    {
        SignPanel.SetActive(true);
    }
    
    
}
