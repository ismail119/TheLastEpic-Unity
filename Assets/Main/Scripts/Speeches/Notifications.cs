using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Notifications : MonoBehaviour
{
    public Queue<string> messages;
    public Queue<string> people;
    [SerializeField] private TextMeshProUGUI SignalNotification;
    [SerializeField] private GameObject signalButton;

    private void Awake()
    {
        FindObjectOfType<Assignment>().KillNumberAssignmentControl();
        SignalNotification = GameObject.FindGameObjectWithTag("NotificationText").GetComponent<TextMeshProUGUI>();
        NotificationsNumberTextUpdate();
    }
    
    public void NotificationsNumberTextUpdate()
    {
        if (FindObjectOfType<PlayerPrefsOperations>().GetData().isReadAll)
        {
            SignalNotification.text = "0";
            signalButton.GetComponent<Button>().interactable = false;
        }
        else
        {
            SignalNotification.text = "!";
            signalButton.GetComponent<Button>().interactable = true;
        }
    }
    
}
