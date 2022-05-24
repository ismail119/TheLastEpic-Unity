using System.Collections;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
        private void Start() => StartCoroutine(FoodTimer());

        private IEnumerator FoodTimer()
        {
                yield return new WaitForSeconds(FindObjectOfType<PlayerPrefsOperations>().GetData().foodCountTime);
                SpawnFood();
                StartCoroutine(FoodTimer());
        }

        
        public void SpawnFood()
        {
                DatabaseSkeleton old = FindObjectOfType<PlayerPrefsOperations>().GetData();
                if (old.foodCountInShop<15)
                {
                        old.foodCountInShop++;
                        FindObjectOfType<PlayerPrefsOperations>().SaveData(old);
                        if (FindObjectOfType<FoodShopCanvas>()!=null)
                        {
                                FindObjectOfType<FoodShopCanvas>().ShowTheCountOnCanvas();
                        }
                }
        }

        
        
}
