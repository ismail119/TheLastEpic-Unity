using System.Collections;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class Wars : MonoBehaviour
{
    private Vector3 cameraTargetPos;
    [SerializeField] private GameObject[] players = new GameObject[4];
    [SerializeField] private GameObject[] enemies = new GameObject[3];
    private PlayerPrefsOperations _playerPrefsOperations;
    private GameObject spawnPlayer,spawnEnemy;
    [SerializeField] private GameObject spawnParticle;
    [SerializeField] private GameObject GamePanel;

    private GameObject player,enemy;
    private void Awake()
    {
        
        cameraTargetPos = GameObject.FindGameObjectWithTag("CameraTarget").transform.position;
        _playerPrefsOperations = FindObjectOfType<PlayerPrefsOperations>();
        spawnPlayer = GameObject.FindGameObjectWithTag("SpawnPlayer");
        spawnEnemy = GameObject.FindGameObjectWithTag("SpawnEnemy");
        GamePanel.SetActive(false);
        var old = _playerPrefsOperations.GetData();
        player = Instantiate(players[old.selectedCharacterIndex], spawnPlayer.transform.position, Quaternion.Euler(0, 180, 0));
        switch (PlayerPrefsOperations.Instance.GetData().selectedWarTypeName)
        {
            case "Mix":
                enemy =  Instantiate(enemies[Random.Range(0, 4)], spawnEnemy.transform.position, Quaternion.Euler(Vector3.zero));
                break;
            case "Devil":
                enemy =  Instantiate(enemies[2], spawnEnemy.transform.position, Quaternion.Euler(Vector3.zero));
                break;
            case "Spider":
                enemy =  Instantiate(enemies[0], spawnEnemy.transform.position, Quaternion.Euler(Vector3.zero));
                break;
            case "Dragon" :
                enemy =  Instantiate(enemies[1], spawnEnemy.transform.position, Quaternion.Euler(Vector3.zero));
                break;
        }
    }

    public void StartTheBattle(GameObject panel)
    {
        panel.SetActive(false);
        Camera.main.transform.DOMove(cameraTargetPos, 4);
        StartCoroutine(StartTheWar());
    }

    private void Start()
    {
        if (PlayerPrefsOperations.Instance.GetData().warCounter%3==0)
        {
            FindObjectOfType<Interstitial_Ads>().ShowAd();
        }

        DatabaseSkeleton old = _playerPrefsOperations.GetData();
        old.warCounter += 1;
        _playerPrefsOperations.SaveData(old);
    }

    private IEnumerator StartTheWar()
    {
        yield return new WaitForSeconds(4);
        GamePanel.SetActive(true);
        player.SetActive(true);
        enemy.SetActive(true);
        Destroy(Instantiate(spawnParticle, spawnEnemy.transform.position, Quaternion.Euler(Vector3.zero)),4f);
        Destroy(Instantiate(spawnParticle, spawnPlayer.transform.position, Quaternion.Euler(Vector3.zero)),4f);
        enemy.GetComponent<EnemyAttacks>().IntroTheEnemyBar();
    }
}
