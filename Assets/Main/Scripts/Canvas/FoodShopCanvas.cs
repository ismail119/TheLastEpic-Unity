using TMPro;
using UnityEngine;

public class FoodShopCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI foodCountText,foodShopEnergyShower,foodTotalCoinShower;
    [SerializeField] private TextMeshProUGUI improveButtonMoneyText;
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private ProgressBarPro speed;
    
    private PlayerPrefsOperations _playerPrefsOperations;

    private void Awake()
    {
        _playerPrefsOperations = FindObjectOfType<PlayerPrefsOperations>();
    }
    
    public void ShowTheCountOnCanvas()
    {
        DatabaseSkeleton data = _playerPrefsOperations.GetData();
        foodCountText.text = data.foodCountInShop.ToString();
        foodShopEnergyShower.text = data.currentEnergy.ToString();
        foodTotalCoinShower.text = data.totalCoin.ToString();
        speed.SetValue(31-data.foodCountTime,30);
        improveButtonMoneyText.text = data.foodimproveMoney.ToString();
    }
    
    public void EatFood()
    {
        DatabaseSkeleton old = _playerPrefsOperations.GetData();
        if (50<=old.totalCoin)
        {
            if (old.foodCountInShop>0)
            {
                old.foodCountInShop--;
                old.totalCoin -= 50;
                
                if (old.currentEnergy + 5 > 100)
                    old.currentEnergy = 100;
                else
                    old.currentEnergy += 5;
                
                _playerPrefsOperations.SaveData(old);
                ShowTheCountOnCanvas();
            }
        }
    }
    
    public void ImproveShop()
    {
        DatabaseSkeleton old = _playerPrefsOperations.GetData();
        
        if (old.foodimproveMoney > old.totalCoin) return;
        if (speed.Value >= 30) return;
            
        old.totalCoin -= old.foodimproveMoney;
        old.foodimproveMoney *=2;
        
        if (old.foodCountTime-2<1)
        {
            old.foodCountTime = 1;
        }
        else
        {
            old.foodCountTime -= 2;
        }
        _playerPrefsOperations.SaveData(old);
        ShowTheCountOnCanvas();
    }
    
    public void OpenedTheShop()
    {
        ShowTheCountOnCanvas();
        shopPanel.SetActive(true);
    }

    public void CloseTheShop()
    {
        FindObjectOfType<MapCanvas>().ReloadStatus();
        shopPanel.SetActive(false);
    }
}
