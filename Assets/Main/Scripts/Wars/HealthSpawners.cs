using TMPro;
using UnityEngine;

public class HealthSpawners : MonoBehaviour
{
    [SerializeField] private GameObject food;
    [SerializeField] private TextMeshProUGUI healthAddition;
    private int health;


    public void CollectTheFoods()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.AddComponent<Rigidbody>().useGravity=false;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        Destroy(GameObject.FindGameObjectWithTag("Enemy").GetComponent<BoxCollider>());
        
        FindObjectOfType<LevelCanvas>().MovePanel();
        player.AddComponent<PlayerMovement>();
        player.AddComponent<PlayerCollision>();
        foreach (Transform obj in transform)
        {
            Instantiate(food,obj.position,Quaternion.identity);
        }
    }

    public void SetTheHealtAdditionText()
    {
        health += 4;
        healthAddition.GetComponent<TextMeshProUGUI>().text = health.ToString();
        if (health==20)
        {
            DatabaseSkeleton old = PlayerPrefsOperations.Instance.GetData();
            old.currentHealth += 20;
            old.currentEnergy += 20;
            PlayerPrefsOperations.Instance.SaveData(old);
            FindObjectOfType<LevelCanvas>().WinPanel();
        }
    }
}
