using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharactersMarketSystem : MonoBehaviour
{
        
        
        //Data
        [SerializeField] private Image[] stars=new Image[4];
        [SerializeField] private string[] introductions=new string[4];
        [SerializeField] private GameObject[] characters = new GameObject[4];
        [SerializeField] private string[] names = new string[4];

        [SerializeField] private string[] characterType = new string[4];
        //Places
        [SerializeField] private TextMeshProUGUI  introText;
        [SerializeField] private TextMeshProUGUI  characterNameText;
        [SerializeField] private TextMeshProUGUI  characterTypeText;
        [SerializeField] private Slider healthSlider;
        [SerializeField] private Slider basicAttackSlider;
        [SerializeField] private Slider midAttackSlider;
        [SerializeField] private Slider ultiAttackSlider;
        [SerializeField] private TextMeshProUGUI totalCoin;
        [SerializeField] private GameObject SelectButton;
        [SerializeField] private GameObject BuyButton;
        [SerializeField] private GameObject SelectedButton;
        [SerializeField] private TextMeshProUGUI price;
        [SerializeField] private TextMeshProUGUI totalMoneyTicket;

        private int index;

        
        public void ShowTheCharacter(int Index)
        {
                index = Index;
                
                //Stars Setting
                for (int i = 0; i < stars.Length; i++)
                {
                        if (i<=Index)
                        {
                                stars[i].gameObject.SetActive(true);
                        }
                        else
                        {
                                stars[i].gameObject.SetActive(false);
                        }
                }
                //Intro Setting
                introText.text = introductions[Index];
                
                //Character Icon Setting
                for (int i = 0; i < characters.Length; i++)
                {
                        if (Index==i)
                        {
                                characters[i].SetActive(true);
                        }
                        else
                        {
                                characters[i].SetActive(false);
                        }
                }
                
                //Character Name Setting
                characterNameText.text = names[Index];
                characterTypeText.text = characterType[Index];

                //Character Health Setting
                DatabaseSkeleton databaseSkeleton = PlayerPrefsOperations.Instance.GetData();
                totalMoneyTicket.text = databaseSkeleton.totalCoin.ToString();
                
                //Price setting
                switch (index)
                {
                        case 1:
                                price.text = "4500";
                                break;
                        case 2:
                                price.text = "8000";
                                break;
                        case 3:
                                price.text = "15000";
                                break;
                }
                
                //SelectButton Setting
                if (databaseSkeleton.boughtCharacterNumbers.Contains(Index))
                {
                        
                        if (Index==databaseSkeleton.selectedCharacterIndex)
                        {
                                SelectButton.SetActive(false);
                                BuyButton.SetActive(false);
                                SelectedButton.SetActive(true);
                        }
                        else
                        {
                                SelectButton.SetActive(true);
                                BuyButton.SetActive(false);
                                SelectedButton.SetActive(false);
                        }
                }
                else
                {
                        SelectedButton.SetActive(false);
                        SelectButton.SetActive(false);
                        BuyButton.SetActive(true);
                }
                //Character Attack and Health Setting 
                switch (Index)
                {
                        case 0:
                                healthSlider.value = databaseSkeleton.character1Health/200;
                                basicAttackSlider.value = databaseSkeleton.character1BasicAttackPower/100;
                                midAttackSlider.value = databaseSkeleton.character1MidAttackPower/100;
                                ultiAttackSlider.value = databaseSkeleton.character1UltiAttackPower/100;
                                break;
                        case 1:
                                healthSlider.value = databaseSkeleton.character2Health/200;
                                basicAttackSlider.value = databaseSkeleton.character2BasicAttackPower/100;
                                midAttackSlider.value = databaseSkeleton.character2MidAttackPower/100;
                                ultiAttackSlider.value = databaseSkeleton.character2UltiAttackPower/100;
                                break;
                        case 2:
                                healthSlider.value = databaseSkeleton.character3Health/200;
                                basicAttackSlider.value = databaseSkeleton.character3BasicAttackPower/100;
                                midAttackSlider.value = databaseSkeleton.character3MidAttackPower/100;
                                ultiAttackSlider.value = databaseSkeleton.character3UltiAttackPower/100;
                                break;
                        case 3:
                                healthSlider.value = databaseSkeleton.character4Health/200;
                                basicAttackSlider.value = databaseSkeleton.character4BasicAttackPower/100;
                                midAttackSlider.value = databaseSkeleton.character4MidAttackPower/100;
                                ultiAttackSlider.value = databaseSkeleton.character4UltiAttackPower/100;
                                break;
                }
                //Coin Text Setting 
                totalCoin.text = databaseSkeleton.totalCoin.ToString();
        }

        public void SelectTheCharacter()
        {
                DatabaseSkeleton old = PlayerPrefsOperations.Instance.GetData();
                old.selectedCharacterIndex = index;
                PlayerPrefsOperations.Instance.SaveData(old);
                ShowTheCharacter(index);
        }

        public void NextCharacter()
        {
                if (index!=characters.Length-1)
                {
                        index++;
                        ShowTheCharacter(index);
                }
        }
        public void PreCharacter()
        {
                if (index!=0)
                {
                        index--;
                        ShowTheCharacter(index);
                }
        }
        
        public void BuyCharacter(TextMeshProUGUI buttonText)
        {
                DatabaseSkeleton old = PlayerPrefsOperations.Instance.GetData();
                int price = int.Parse(buttonText.text);
                if (price<=old.totalCoin)
                {
                        old.totalCoin -= price;
                        old.boughtCharacterNumbers.Add(index);
                        PlayerPrefsOperations.Instance.SaveData(old);
                        ShowTheCharacter(index);
                }
        }
        
        
}


