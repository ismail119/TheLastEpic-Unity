using System;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class InputSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI name; 
    [SerializeField] private TextMeshProUGUI kill,lose; 
    [SerializeField] private Text _text;
    private string message;
    [SerializeField] private GameObject speechPanel,warningPopUp;
    [SerializeField] private Sprite witch,priest,bestFriend,warrior,homeless;
    [SerializeField] private Image character;
    [SerializeField] private GameObject skip, close;
    [SerializeField] private GameObject goSmallWar;
    private bool musicDifferent;
    private void Awake()
    {
        message = PlayerPrefsOperations.Instance.GetData().language switch
        {
            "Eng" =>
                "Hi lady. There is no any messages for you now,If I take a message I will warn you at messages section.",
            "Tr" =>
                "Merhaba Leydim. Simdilik elimde sizin icin herhangi bir mesaj yok. Eger herhangi bir mesaj gelirse haber kutusunda belirtecegim.",
            "German" =>
                "Hallo, meine Dame. Im Moment habe ich keine Nachrichten für dich. Wenn eine Nachricht kommt, werde ich sie in der Nachrichtenbox veröffentlichen.",
            _ => message
        };
    }

    private void Update()
    {
        if (speechPanel.activeSelf||warningPopUp.activeSelf) return;

        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (!Physics.Raycast(ray, out hit)) return;
            
            switch (hit.collider.tag)
            {
                case "FoodShop":
                    FindObjectOfType<FoodShopCanvas>().OpenedTheShop();
                    break;
                case "Witch":
                    musicDifferent = true;
                    OpenWitch();
                    break;
                case "Priest":
                    musicDifferent = true;
                    OpenPriest();
                    break;
                case "BestFriend":
                    OpenBestFriend();
                    break;
                case "Warrior":
                    if (!PlayerPrefsOperations.Instance.GetData().isWarriorDead)
                        OpenWarrior();
                    break;
                case "Homeless":
                    OpenHomeless();
                    break;
                case "Wiseman":
                    OpenWiseman();
                    break;
            }
        }
    }

    public void OpenWiseman()
    {
        _text.text = PlayerPrefsOperations.Instance.GetData().language switch
        {
            "Tr" =>
                "Hosgeldin leydim.Sabir her seyin ilacidir ve tarih yazmak korkaklarin isi degildir unutma.Sen bunu basardin, gelecek destani yazmak icin tanrilarin sana verecegi gorev icin beklemen, sabretmen gerekiyor. (Yeni versiyon icin bekle hazir olacak! Oldurme sayina gore yeni versiyonda toprak sahibi olacaksin.)",
            "Gr" =>
                "Willkommen, Mylady. Geduld heilt alles und Geschichte zu schreiben ist nichts für Feiglinge. Sie haben es geschafft, Sie müssen auf die Aufgabe warten, die die Götter Ihnen geben werden, um das nächste Epos zu schreiben. Warten Sie auf die neue Version, sie wird fertig sein! Basierend auf Ihrer Kill-Zählung werden Sie in der neuen Version Landbesitzer.",
            "Eng" =>
                "Welcome my lady. Patience is the best medicine for everything, and making history is not for cowards.You have succeeded, you have to wait for the task that the gods will give you to write the next epic. (Wait for new version it will be ready! If you kill more man you will have more lands in the new version.)",
            _ => _text.text
        };
    }

    private void OpenWitch() {
        FindObjectOfType<MusicManager>().PlayWitchMusic();
        goSmallWar.SetActive(true);
        name.text = "Malicifant";
        character.sprite = witch;
        skip.SetActive(false);
        close.SetActive(true);
        switch (PlayerPrefsOperations.Instance.GetData().language)
        {
            case "Tr":
                _text.text =
                    "Merhabalar leydim. Hosgeldiniz eger ruhlar alemine gidip ordan yiyecek calmak ve hem enerjinizi hem de caninizi arttirmak isterseniz iksirimden icin ve ruhlar alemine gidin.Orada enerjiniz gitmeyecek ancak caniniz biraz gidebilir. Dikkatli olun!";
                break;
            case "Gr":
                _text.text =
                    "Hallo, meine Dame. Willkommen, wenn Sie in das Geisterreich gehen und von dort Nahrung stehlen und sowohl Ihre Energie als auch Ihre Gesundheit steigern möchten, gehen Sie in das Geisterreich für das Elixier. Ihre Energie wird nicht dorthin gehen, aber Ihre Seele kann ein wenig gehen. Vorsichtig sein";
                break;
            case "Eng":
                _text.text =
                    "Hello lady, welcome. If you want to go to spirit realm and steal food ,increase your health and energy, you can drink this elixir. In there you will not lose the energy but your health may decrease little bit. Be careful!";
                break;
        }
        speechPanel.SetActive(true);
    }

    private void OpenPriest() {   
        FindObjectOfType<MusicManager>().PlayPriestMusic();
        skip.SetActive(false);
        close.SetActive(true);
        kill.text = PlayerPrefsOperations.Instance.GetData().totalKillNumber.ToString();
        lose.text = PlayerPrefsOperations.Instance.GetData().loseNumber.ToString();
        kill.transform.parent.gameObject.SetActive(true);
        lose.transform.parent.gameObject.SetActive(true);
        character.sprite = priest;
        name.text = "Bernard";
        _text.text = message;
        speechPanel.SetActive(true);
    }
    private void OpenHomeless() {
        skip.SetActive(false);
        close.SetActive(true);
        character.sprite = homeless;
        name.text = "Peter";
        _text.text = message;
        speechPanel.SetActive(true);
    }
    private void OpenBestFriend() {   
        skip.SetActive(false);
        close.SetActive(true);
        character.sprite = bestFriend;
        name.text = "Angela";
        _text.text = message;
        speechPanel.SetActive(true);
    }

    private void OpenWarrior() {
        skip.SetActive(false);
        close.SetActive(true);
        character.sprite = warrior;
        name.text = "Jack";
        _text.text = message;
        speechPanel.SetActive(true);
    }

    public void GoToSmallWar()
    {
        FindObjectOfType<MusicManager>().PlayBattleMusic();
        DatabaseSkeleton old = PlayerPrefsOperations.Instance.GetData();
        old.totalCoin -= 200;
        PlayerPrefsOperations.Instance.SaveData(old);
        FindObjectOfType<LevelLoader>().LoadLevel(6);
    }

    public void CloseThePanel() {

        if (SceneManager.GetActiveScene().buildIndex==3)
        {
            goSmallWar.SetActive(false);
            kill.transform.parent.gameObject.SetActive(false);
            lose.transform.parent.gameObject.SetActive(false);
        }
        close.SetActive(false);
        speechPanel.SetActive(false);
        skip.SetActive(true);
        if (musicDifferent)
        {
            FindObjectOfType<MusicManager>().PlayMap1Music();
            musicDifferent = false;
        }
    }
}
