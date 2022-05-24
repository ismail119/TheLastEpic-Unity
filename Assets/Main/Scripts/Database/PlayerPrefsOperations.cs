using System.Collections.Generic;
using UnityEngine;

public class DatabaseSkeleton
{
    public string username;
    public bool isFirst;
    public bool isReadAll;
    public string language;
    public int InterstitialCounter;
    public int warCounter;
    
    public float character1BasicAttackPower;
    public float character1MidAttackPower;
    public float character1UltiAttackPower;
    public float character1Health;
    public float character2BasicAttackPower;
    public float character2MidAttackPower;
    public float character2UltiAttackPower;
    public float character2Health;
    public float character3Health;
    public float character3BasicAttackPower;
    public float character3MidAttackPower;
    public float character3UltiAttackPower;
    public float character4Health;
    public float character4BasicAttackPower;
    public float character4MidAttackPower;
    public float character4UltiAttackPower;
    
    public float currentEnergy;
    public float currentHealth;
    
    public int section;
    public float level;
    public int totalCoin;
    public int totalKillNumber;
    public int loseNumber;

    public int foodCountInShop;
    public int foodCountTime;
    public int foodimproveMoney;

    public int currentAssignmentKill;
    public int targetKillAssignment;
    
    public List<int> boughtCharacterNumbers;
    public List<int> openedMaps;

    public string selectedWarTypeName;
    public int selectedCharacterIndex;
    public bool isWarriorDead;
}

public class PlayerPrefsOperations : MonoBehaviour
{
    
    private static PlayerPrefsOperations _instance;
    public static PlayerPrefsOperations Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<PlayerPrefsOperations>();
            }
            return _instance;
        }
    }
    private void Awake()
    {
        
        DontDestroyOnLoad(this.gameObject);
        
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return; //Avoid doing anything else
        }
        _instance = this;
        
        if (PlayerPrefs.HasKey("GameData")) return;
        
        DatabaseSkeleton databaseSkeleton = new DatabaseSkeleton
        {
            username= "",
            isFirst = true,
            isReadAll = false,
            level = 0,
            language = "Eng",
            
            currentEnergy = 100,
            currentHealth = 100,
            
            totalKillNumber=0,
            loseNumber=0,
            InterstitialCounter=0,
            warCounter=2,
            isWarriorDead=false,

            character1Health = 100,
            character1BasicAttackPower = 20,
            character1MidAttackPower = 25,
            character1UltiAttackPower = 30,
            
            character2Health = 120,
            character2BasicAttackPower = 25,
            character2MidAttackPower = 30,
            character2UltiAttackPower = 35,
            
            foodCountInShop=0,
            foodCountTime=18,
            foodimproveMoney = 100, 
            
            character3Health = 150,
            character3BasicAttackPower = 30,
            character3MidAttackPower = 35,
            character3UltiAttackPower = 42,
            
            character4Health = 170,
            character4BasicAttackPower = 40,
            character4MidAttackPower = 45,
            character4UltiAttackPower = 50,
            
            section = 0,
            totalCoin = 20000,

            currentAssignmentKill = 0,
            targetKillAssignment=1,
            
            selectedCharacterIndex = 0,
            
            selectedWarTypeName ="Spider",  
            
            boughtCharacterNumbers = new List<int> {0},
            openedMaps = new List<int> {0,1}
        };
        SaveData(databaseSkeleton);
    }

    public DatabaseSkeleton GetData()
    {
        string JsonFormatOfGameDataObject = PlayerPrefs.GetString("GameData");
        return JsonUtility.FromJson<DatabaseSkeleton>(JsonFormatOfGameDataObject);
    }

    public void SaveData(DatabaseSkeleton newSkeleton)
    {
        string JsonFormatOfGameDataObject = JsonUtility.ToJson(newSkeleton);
        PlayerPrefs.SetString("GameData", JsonFormatOfGameDataObject);
    }
    
}
