using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GamePanel : MonoBehaviour
{
    public float currentHealth;
    public float currentEnergy;
    public ProgressBarPro healthBar;
    public ProgressBarPro energyBar;
    

    private PlayerPrefsOperations _playerPrefsOperations;
    private EnergyMechanics _energyMechanics;

    private int characterIndex;
    private GameObject player; // To access attack script

    public GameObject attackButtons;//To set interactable feature

    private void Awake()
    {
        _energyMechanics = FindObjectOfType<EnergyMechanics>();
        _playerPrefsOperations = FindObjectOfType<PlayerPrefsOperations>();
    }

    private void Start()
    {
        SetBarsAndDatabase();
        characterIndex = _playerPrefsOperations.GetData().selectedCharacterIndex;
    }

    public void SetBarsAndDatabase()
    {
        DatabaseSkeleton data = FindObjectOfType<PlayerPrefsOperations>().GetData();
        currentEnergy = data.currentEnergy;
        currentHealth = data.currentHealth;
        energyBar.SetValue(currentEnergy,100);
        healthBar.SetValue(currentHealth,100);
    }

    public void BasicAttack(Text energyAmount)
    {
        attackButtons.SetActive(false);
        if (characterIndex==0 || characterIndex==1)
        {
            StartCoroutine(FindObjectOfType<SwordAttacks>().SwordBasicAttack());
        }
        else
        {
            StartCoroutine(FindObjectOfType<WizardAttacks>().WizardBasicAttack());
        }
        
        if (SceneManager.GetActiveScene().buildIndex==5)
        {
            _energyMechanics.DecreaseEnergy(3);
        }
        
        SetBarsAndDatabase();
    }
    public void MidAttack(Text energyAmount)
    {
        attackButtons.SetActive(false);
        if (characterIndex==0 || characterIndex==1)
        {
            StartCoroutine(FindObjectOfType<SwordAttacks>().SwordMidAttack());
        }
        else
        {
            StartCoroutine(FindObjectOfType<WizardAttacks>().WizardMidAttack());
        }
        if (SceneManager.GetActiveScene().buildIndex==5)
        {
            _energyMechanics.DecreaseEnergy(5);
        }

        SetBarsAndDatabase();
    }
    
    public void UltiAttack(Text energyAmount)
    {
        attackButtons.SetActive(false);
        if (characterIndex==0 || characterIndex==1)
        {
            StartCoroutine(FindObjectOfType<SwordAttacks>().SwordUltiAttack());
        }
        else
        {
            StartCoroutine(FindObjectOfType<WizardAttacks>().WizardUltiAttack());
        }
        
        if (SceneManager.GetActiveScene().buildIndex==5)
        {
            _energyMechanics.DecreaseEnergy(7);
        }
        SetBarsAndDatabase();
    }

    public void Healing()
    {
        attackButtons.SetActive(false);
        if (characterIndex==0 || characterIndex==1)
        {
            StartCoroutine(FindObjectOfType<SwordAttacks>().EnemyAttackStarter());
        }
        else
        {
            StartCoroutine(FindObjectOfType<WizardAttacks>().EnemyAttackStarter());
        }
        _energyMechanics.DecreaseEnergy(10);
        _energyMechanics.IncreaseHealth(25);
        SetBarsAndDatabase();
    }
    
}