using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RanksSystem : MonoBehaviour
{
        [SerializeField] private TextMeshProUGUI[] names = new TextMeshProUGUI[10];//Level ranks
        [SerializeField] private TextMeshProUGUI[] levels = new TextMeshProUGUI[10];//Level ranks

        //Flags will be added later on.
        
        public void ListFirstTenPeopleLevel(Dictionary<string, float> firstTenUsers)
        {
                int count = 9;
                foreach (var user in firstTenUsers)
                {
                        names[count].text = user.Key;
                        levels[count].text = user.Value.ToString();
                        count--;
                }
                //Our rank index will be here.Firebase code script will have this function.
                FindObjectOfType<MainCanvas>().OpenAnyPanel("ranksPanel");
        }
        public void ListFirstTenPeopleKillNumber(Dictionary<string, int> firstTenUsers)
        {
                int count = 9;
                foreach (var user in firstTenUsers)
                {
                        names[count].text = user.Key;
                        levels[count].text = user.Value.ToString();
                        count--;
                }
                //Our rank index will be here.Firebase code script will have this function.
                FindObjectOfType<MainCanvas>().OpenAnyPanel("ranksPanel");
        }
        
}
