using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAttacks : MonoBehaviour
{

    private EnemyAnimation _enemyAnimation;
    [SerializeField] private GameObject projectile;
    [SerializeField] public GameObject spawnPoint;
    public int enemyHealth;
    private int enemyFullHealth;
    [SerializeField] private string typeOfMonster;
    private int decreasingAmountOfPlayerHealth;
    private ProgressBarPro enemyHealthBar;
    public int GainingCoin;
    [SerializeField]private GameObject soulParticle;


    private void Awake()
    {
        enemyFullHealth = enemyHealth;
        _enemyAnimation = GetComponent<EnemyAnimation>();
        print(_enemyAnimation);
        if (SceneManager.GetActiveScene().buildIndex==6)
        {
            switch (typeOfMonster)
            {
                case "Dragon":
                    decreasingAmountOfPlayerHealth = 2;
                    break;
                case "Devil" :
                    decreasingAmountOfPlayerHealth = 4;
                    break;
                case "Spider" :
                    decreasingAmountOfPlayerHealth = 6;
                    break;
            }
        }
        else
        {
            switch (typeOfMonster)
            {
                case "Dragon":
                    switch (PlayerPrefsOperations.Instance.GetData().selectedCharacterIndex)
                    {
                        case 0 :
                            decreasingAmountOfPlayerHealth = 16;
                            break;
                        case 1:
                            decreasingAmountOfPlayerHealth = 14;
                            break;
                        case 2:
                            decreasingAmountOfPlayerHealth = 11;
                            break;
                        case 3:
                            decreasingAmountOfPlayerHealth = 9;
                            break;
                    }
                    
                    break;
                case "Devil" :
                    switch (PlayerPrefsOperations.Instance.GetData().selectedCharacterIndex)
                    {
                        case 0 :
                            decreasingAmountOfPlayerHealth = 18;
                            break;
                        case 1:
                            decreasingAmountOfPlayerHealth = 15;
                            break;
                        case 2:
                            decreasingAmountOfPlayerHealth = 13;
                            break;
                        case 3:
                            decreasingAmountOfPlayerHealth = 11;
                            break;
                    }
                    break;
                case "Spider" :
                    switch (PlayerPrefsOperations.Instance.GetData().selectedCharacterIndex)
                    {
                        case 0 :
                            decreasingAmountOfPlayerHealth = 12;
                            break;
                        case 1:
                            decreasingAmountOfPlayerHealth = 10;
                            break;
                        case 2:
                            decreasingAmountOfPlayerHealth = 9;
                            break;
                        case 3:
                            decreasingAmountOfPlayerHealth = 7;
                            break;
                    }
                    break;
            }
        }
    }

    public void IntroTheEnemyBar()
    {
        enemyHealthBar = GameObject.FindGameObjectWithTag("EnemyBar").GetComponent<ProgressBarPro>();
        enemyHealthBar.SetValue(enemyHealth,enemyFullHealth);
    }

    public void EnemyAttack()
    {
        if (enemyHealth>0)
            StartCoroutine(EnemyAttackCoroutine());
        
    }
    
    private IEnumerator EnemyAttackCoroutine()
    {
        _enemyAnimation.EnemyAttack();
        yield return new WaitForSeconds(.5f);
        if (typeOfMonster.Equals("Dragon"))
        {
            Destroy(Instantiate(projectile, spawnPoint.transform.position, transform.rotation),1);
        }
        else
        {
            Destroy(Instantiate(projectile, spawnPoint.transform.position, transform.rotation),3);
        }
        PlayerTakeDamage();
    }

    
    private void PlayerTakeDamage()
    {
        if (FindObjectOfType<SwordAnimations>()==null)
        {
            FindObjectOfType<WizardAnimations>().WizardTakeDamage();
        }
        else
        {
            FindObjectOfType<SwordAnimations>().SwordTakeDamage();
        }
        
        FindObjectOfType<EnergyMechanics>().DecreaseHealth(decreasingAmountOfPlayerHealth);
        FindObjectOfType<GamePanel>().SetBarsAndDatabase();
    }

    public IEnumerator EnemyHealthDeacreasing(int amount)
    {
        enemyHealth -= amount;
        enemyHealthBar.SetValue(enemyHealth,enemyFullHealth);
        if (enemyHealthBar.Value <= 0)
        {
            yield return new WaitForSeconds(2);
            _enemyAnimation.EnemyDie();
            yield return new WaitForSeconds(1.5f);
            DatabaseSkeleton old = PlayerPrefsOperations.Instance.GetData();
            if (SceneManager.GetActiveScene().buildIndex!=6)
            {
                old.currentAssignmentKill += 1;
                old.level += 0.3f;
            }
            old.totalKillNumber += 1;
            PlayerPrefsOperations.Instance.SaveData(old);
            
            if (SceneManager.GetActiveScene().buildIndex==6)
            {
                FindObjectOfType<HealthSpawners>().CollectTheFoods();
            }
            else
            {
                FindObjectOfType<FirebaseOperations>().WriteNewLevel(PlayerPrefsOperations.Instance.GetData().username,PlayerPrefsOperations.Instance.GetData().level,PlayerPrefsOperations.Instance.GetData().totalKillNumber);
                FindObjectOfType<LevelCanvas>().WinPanel();
                Instantiate(soulParticle, transform.position, Quaternion.identity);
            }
        }
    }
}
