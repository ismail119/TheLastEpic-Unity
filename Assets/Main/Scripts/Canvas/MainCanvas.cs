using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainCanvas : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField]private GameObject ranksPanel;
    [SerializeField]private GameObject loadingPanel;
    [SerializeField]private GameObject charactersPanel;
    [SerializeField]private GameObject shopPanel;
    [SerializeField]private GameObject signPanel;
    [SerializeField]private GameObject settingsPanel;
    [SerializeField]private GameObject ratePanel;
    [SerializeField]private GameObject mainPanel;
    [SerializeField]private GameObject soundPanel;
    [SerializeField]private GameObject assignmentsPanel;
    [SerializeField]private GameObject[] languages_checks;
    
    //Connections
    private CharactersMarketSystem _charactersMarketSystem;
    
    [SerializeField]private GameObject killRankButton, levelRankButton;
    [SerializeField] private TextMeshProUGUI SignUpPanelMessage;
    private FirebaseOperations _firebaseOperations;
    
    //Preparing MainCanvas
    [Header("Main Canvas Elements")]
    [SerializeField] private TextMeshProUGUI coin;
    [SerializeField] private TextMeshProUGUI health;
    [SerializeField] private TextMeshProUGUI userName;
    [SerializeField] private TextMeshProUGUI characterWarEnergy;
    [SerializeField] private TextMeshProUGUI levelInt;
    [SerializeField] private Slider levelSlider;

    [SerializeField] private TextMeshProUGUI CompletedNumber, TargetEnemyTotal;
    [SerializeField] private ProgressBarPro completedBar;
    
    
    //Panels For Functions
    private List<GameObject> panels;

    private void Awake()
    {
        panels = new List<GameObject>();
        _charactersMarketSystem = GetComponent<CharactersMarketSystem>();
        _firebaseOperations = FindObjectOfType<FirebaseOperations>();
            
        //For openaynpanel function
        panels.Clear();
        panels.Add(ranksPanel);
        panels.Add(loadingPanel);
        panels.Add(assignmentsPanel);
        panels.Add(charactersPanel);
        panels.Add(shopPanel);
        panels.Add(settingsPanel);
        panels.Add(signPanel);
        panels.Add(ratePanel);
        panels.Add(mainPanel);
        panels.Add(soundPanel);
        
        SetCheckersLanguage();
    }

    public void SelectLanguage(Button button)
    {
        DatabaseSkeleton old = PlayerPrefsOperations.Instance.GetData();
            switch (button.name)
            {
                case "Tr":
                    old.language = "Tr";
                    break;
                case "Gr":
                    old.language = "Gr";
                    break;
                case "Eng":
                    old.language = "Eng";
                    break;
            }
            PlayerPrefsOperations.Instance.SaveData(old);
            SetCheckersLanguage();
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void SetCheckersLanguage()
    {
        foreach (var checker in languages_checks)
        {
            if (checker.transform.parent.name == PlayerPrefsOperations.Instance.GetData().language)
                checker.SetActive(true);
            else
                checker.SetActive(false);
        }
    }
    public void OpenAssignmentPanel()
    {
        OpenAnyPanel("assignmentsPanel");
        int current= PlayerPrefsOperations.Instance.GetData().currentAssignmentKill;
        int target = PlayerPrefsOperations.Instance.GetData().targetKillAssignment;
        CompletedNumber.text = current.ToString();
        TargetEnemyTotal.text = target.ToString();
        completedBar.SetValue(current, target);
    }
    
    
    public void GoToCharactersPanel()
    {
        _charactersMarketSystem.ShowTheCharacter(0);
        OpenAnyPanel("charactersPanel");
    }
    
    public void GoToMainMenu()
    {
        if (SceneManager.GetActiveScene().buildIndex!=1)
        {
            FindObjectOfType<MusicManager>().PlayMenuMusic();
        }
        DatabaseSkeleton old = PlayerPrefsOperations.Instance.GetData();
        userName.text = old.username;
        
        characterWarEnergy.text = old.currentEnergy.ToString();
        levelInt.text = ((int)old.level).ToString();
        levelSlider.value = (old.level % 1);
        coin.text = old.totalCoin.ToString();
        health.text = old.currentHealth.ToString();
        OpenAnyPanel("mainPanel");
    }

    public void OpenRanksPanel()
    {
        
        _firebaseOperations.GetFromDatabase_FirstTenPeopleListAndThisPersonAsLevel();
    }

    public void CloseMusicPanel(GameObject panel)
    {
        GoToMainMenu();
        OpenAnyPanel("mainPanel");
    }

    public void OpenSite()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.ismailgokbas.holylandepic");
    }

    public void OpenSettingsPanel()
    {
        OpenAnyPanel("settingsPanel");
    }

    public void OpenLevelRanks()
    {
        levelRankButton.SetActive(true);
        killRankButton.SetActive(false);
        _firebaseOperations.GetFromDatabase_FirstTenPeopleListAndThisPersonAsLevel();
    }

    public void PlayButton()
    {
        FindObjectOfType<MusicManager>().PlayMap1Music();
        FindObjectOfType<LevelLoader>().LoadLevel(2);
    }

    public void OpenKillRanks()
    {
        levelRankButton.SetActive(false);
        killRankButton.SetActive(true);
        _firebaseOperations.GetFromDatabase_FirstTenPeopleListAndThisPersonAsKillNumber();
    }

    public void ShopPanel()
    {
        OpenAnyPanel("shopPanel");
    }

    public void SignTheUser(TextMeshProUGUI name)
    {
        _firebaseOperations.AddToDatabase_NewUserRank(name.text);
    }

    public void OpenSoundPanel()
    {
        soundPanel.SetActive(true);
    }

    public void GiveResult(bool result,string name)
    {
        if (result)
        {
            DatabaseSkeleton old = PlayerPrefsOperations.Instance.GetData();
            old.username = name;
            old.isFirst = false;
            PlayerPrefsOperations.Instance.SaveData(old);
            signPanel.SetActive(false);
            OpenSoundPanel();
        }
        else
        {
            SignUpPanelMessage.text = "This name is not unique !";
            SignUpPanelMessage.color = Color.red;
        }
    }

    public void MusicSettings(Slider soundSlider)
    {
        foreach (var audio in FindObjectsOfType<AudioSource>())
        {
            audio.volume = soundSlider.value;
        }
    }
    

    public void OpenAnyPanel(string panelName)
    {
        foreach (var panel in panels)
        {
            if (panel.name.Equals(panelName))
            {
                panel.SetActive(true);
            }
            else
            {
                panel.SetActive(false);
            }
        }
    }
}
