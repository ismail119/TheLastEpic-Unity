using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCanvas : MonoBehaviour
{
    [SerializeField]private GameObject[] panels;
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private GameObject health;
    private int coin;
    


    public void WinPanel()
    {
        SetActivity("winPanel");
        coinText.text = FindObjectOfType<EnemyAttacks>().GainingCoin.ToString();
        coin = FindObjectOfType<EnemyAttacks>().GainingCoin;
        if (SceneManager.GetActiveScene().buildIndex==6)
        {
            health.SetActive(true);
        }
    }
    

    public void MovePanel()
    {
        SetActivity("movePanel");
    }
    
    public void GoToTown()
    {
        FindObjectOfType<MusicManager>().PlayMap1Music();
        DatabaseSkeleton old = FindObjectOfType<PlayerPrefsOperations>().GetData();
        old.totalCoin += coin;
        FindObjectOfType<PlayerPrefsOperations>().SaveData(old);
        FindObjectOfType<LevelLoader>().LoadLevel(2);
    }

    public void Losepanel()
    {
        SetActivity("losePanel");
        coin = 0;
    }
    
    private void SetActivity(string name)
    {
        foreach (var panel in panels)
        {
            if (panel.name.Equals(name))
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
