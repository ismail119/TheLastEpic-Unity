using UnityEngine;

public class EnergyMechanics : MonoBehaviour
{
      private PlayerPrefsOperations _playerPrefsOperations;

      private void Awake()
      {
            _playerPrefsOperations = FindObjectOfType<PlayerPrefsOperations>();
      }
      
      //--------- Energy ---------//
      public void IncreaseEnergy(float amount)
      {
            print(amount);
            DatabaseSkeleton old = _playerPrefsOperations.GetData();
            print(old.currentEnergy);
            if (old.currentEnergy + amount > 100)
                  old.currentEnergy = 100;
            else
                  old.currentEnergy += amount;
            
            _playerPrefsOperations.SaveData(old);
      }

      public void DecreaseEnergy(float amount)
      {
            
            DatabaseSkeleton old = _playerPrefsOperations.GetData();

            if (old.currentEnergy - amount <= 0)
            {
                  print("hi");
                  old.currentEnergy = 0;
                  old.loseNumber++;

                  if (_playerPrefsOperations.GetData().selectedCharacterIndex==0||_playerPrefsOperations.GetData().selectedCharacterIndex==1)
                  {
                        FindObjectOfType<SwordAnimations>().SwordDie();
                  }
                  else
                  { 
                        FindObjectOfType<WizardAnimations>().WizardDie();
                  }
                  FindObjectOfType<LevelCanvas>().Losepanel();

            }
            else
                  old.currentEnergy -= amount;
            
            _playerPrefsOperations.SaveData(old);
            
      }
      //--------- Health ---------//
      public void IncreaseHealth(float amount)
      {
            DatabaseSkeleton old = _playerPrefsOperations.GetData();
            
            if (old.currentHealth + amount > 100)
                  old.currentHealth = 100;
            else
                  old.currentHealth += amount;

            _playerPrefsOperations.SaveData(old);
      }

      public void DecreaseHealth(float amount)
      {
            DatabaseSkeleton old = _playerPrefsOperations.GetData();

            if (old.currentHealth - amount <= 0)
            {
                  old.currentHealth = 0;
                  old.loseNumber++;
                  if (_playerPrefsOperations.GetData().selectedCharacterIndex==0||_playerPrefsOperations.GetData().selectedCharacterIndex==1)
                  {
                        FindObjectOfType<SwordAnimations>().SwordDie();
                  }
                  else
                  {
                        FindObjectOfType<WizardAnimations>().WizardDie();
                  }
                  
                  FindObjectOfType<LevelCanvas>().Losepanel();
            }
                  
            else
                  old.currentHealth -= amount;
            
            
            _playerPrefsOperations.SaveData(old);
      }
      
      
      //---------- Coin ----------//
      public void IncreaseCoin(int amount)
      {
            DatabaseSkeleton old = _playerPrefsOperations.GetData();
            old.totalCoin += amount;
            _playerPrefsOperations.SaveData(old);
      }

      public void DecreaseCoin(int amount)
      {
            DatabaseSkeleton old = _playerPrefsOperations.GetData();
            if (old.totalCoin-amount<0)
                  old.totalCoin = 50;
            else
                  old.totalCoin -= amount;
            
            
            _playerPrefsOperations.SaveData(old);
      }
      
      
}
