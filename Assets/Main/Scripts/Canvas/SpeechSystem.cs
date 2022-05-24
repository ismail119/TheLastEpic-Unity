using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SpeechSystem : MonoBehaviour
{
    //Memory
    [SerializeField] private Sprite[] Witch,Wiseman,Priest,BestFriend,Warrior,FoodShop,Homeless;
    

    //Canvas
    [SerializeField] private Image CharacterPhoto;
    [SerializeField] private TextMeshProUGUI nameOfMessager,taskOfMessanger;
    [SerializeField] private Text messageText;
    [SerializeField] private GameObject speechPanel;

    public Queue<String> people, messages;
    [SerializeField] private GameObject arrow;

  
    public void Slide(string who,string message)
    {
        SetTheName(who);
        taskOfMessanger.text = who; 
        SetTheImage(who);
            messageText.text = message;
    }

    private void SetTheName(string who)
    {
        switch (who)
        {
            case "Witch":
            case "Hexe":
            case "마녀":
            case "CADI":
                nameOfMessager.text = "Maleficent";
                break;
            case "Wiseman":
            case "현인":
            case "Weiser Mann":
            case "BILGE ADAM":
                nameOfMessager.text = "Caspar";
                break;
            case "RAHIP" :
            case "성직자" :
            case "Priest" :
            case "Priester" :
                nameOfMessager.text = "Bernand";
                break;
            case "BestFriend":
            case "우리의 친구":
            case "Enger Freund":
            case "DOSTUMUZ":
                nameOfMessager.text = "Angela";
                break;
            case "Warrior":
            case "SAVASCI":
            case "전투기":
            case "Kämpfer":
                nameOfMessager.text = "Jack";
                break;
            case "FoodShop":
            case "BAKKAL":
            case "일반 상점":
            case "Gemischtwarenladen":
                nameOfMessager.text = "Donald";
                break;
            case "Homeless":
            case "EVSIZ":
            case "노숙자":
            case "Obdachlos":
            case "CONTINUE":
                nameOfMessager.text = "Peter";
                break;
        }
    }

    public void StartTheSpeech()
    {
        List<Queue<string>> Queues = FindObjectOfType<SpeechConverter>().GetMessages();
        speechPanel.SetActive(true);
        people = Queues[0];
        messages = Queues[1];
        Slide(people.Dequeue(),messages.Dequeue());
    }

    public void Next()
    {
        messageText.gameObject.SetActive(false);
        if (people.Count!=0)
        {
            messageText.gameObject.SetActive(true);
            Slide(people.Dequeue(),messages.Dequeue());
        }
        else
        {
            DatabaseSkeleton old = PlayerPrefsOperations.Instance.GetData();
            old.currentAssignmentKill = 0;
            old.isReadAll = true;
            arrow.SetActive(false);
            PlayerPrefsOperations.Instance.SaveData(old);
            FindObjectOfType<Notifications>().NotificationsNumberTextUpdate();
            speechPanel.SetActive(false);
        }
    }
    
    
 
    public void SetTheImage(string who)
    {
        switch (who)
        {
            case "Witch":
            case "Hexe":
            case "마녀":
            case "CADI":
                CharacterPhoto.sprite = Witch[Random.Range(0, 2)];
                break;
            case "Wiseman":
            case "현인":
            case "Weiser Mann":
            case "BILGE ADAM":
                CharacterPhoto.sprite = Wiseman[Random.Range(0, 2)];
                break;
            case "RAHIP" :
            case "성직자" :
            case "Priest" :
            case "Priester" :
                CharacterPhoto.sprite = Priest[Random.Range(0, 2)];
                break;
            case "BestFriend":
            case "우리의 친구":
            case "Enger Freund":
            case "DOSTUMUZ":
                CharacterPhoto.sprite = BestFriend[Random.Range(0, 2)];
                break;
            case "Warrior":
            case "SAVASCI":
            case "전투기":
            case "Kämpfer":
                CharacterPhoto.sprite = Warrior[Random.Range(0, 2)];
                break;
            case "FoodShop":
            case "BAKKAL":
            case "일반 상점":
            case "Gemischtwarenladen":
                CharacterPhoto.sprite = FoodShop[Random.Range(0, 2)];
                break;
            case "Homeless":
            case "EVSIZ":
            case "노숙자":
            case "Obdachlos":
            case"CONTINUE":
                CharacterPhoto.sprite = Homeless[Random.Range(0, 2)];
                break;
        }
    }
    
}
