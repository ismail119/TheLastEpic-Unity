using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InternetController : MonoBehaviour
{
    [SerializeField] private GameObject connectionProblemPanel;
    
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex==2)
        {
            GameObject.Find("Canvas").transform.Find("Panel").GetChild(6).gameObject.SetActive(!PlayerPrefsOperations.Instance.GetData().isReadAll);
        }
        if(Application.internetReachability == NetworkReachability.NotReachable)
        {
            Time.timeScale = 0;
            connectionProblemPanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            connectionProblemPanel.SetActive(false);
        }
    }
}
