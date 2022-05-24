using System;
using System.Collections;
using System.Collections.Generic;
using Firebase.Database;
using Firebase.Extensions;
using UnityEngine;


public class FirebaseOperations: MonoBehaviour
{
    private DatabaseReference Level_Ranks_Reference,KillNumber_Ranks_Reference;
    private Dictionary<string, float> first_ten_users_Level;
    private Dictionary<string, int> first_ten_users_killNumber;
    private bool completed = true;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        // Get the root reference location of the database.
        Level_Ranks_Reference = FirebaseDatabase.DefaultInstance.GetReference("LevelRanks");
        KillNumber_Ranks_Reference = FirebaseDatabase.DefaultInstance.GetReference("KillNumbersRanks");
        first_ten_users_Level = new Dictionary<string, float>();
        first_ten_users_killNumber = new Dictionary<string, int>();
    }

    public void AddToDatabase_NewUserRank(string name)
    {
        if (!completed)
        {
            StartCoroutine(Loading());
        }
        //Control Is there any one with this name.
        Level_Ranks_Reference.Child(name)
            .GetValueAsync().ContinueWithOnMainThread(task =>
            {
                if (task.IsFaulted)
                {
                    print("error.");
                    //Show pop up.
                    completed = true;
                }
                else if (task.IsCompleted)
                {
                    DataSnapshot snapshot = task.Result;
                    if (snapshot.Value == null && name!="") //If name is appropriate to use
                    {
                        FindObjectOfType<MainCanvas>().GiveResult(true,name);
                        Level_Ranks_Reference.Child(name).SetValueAsync(0);
                        KillNumber_Ranks_Reference.Child(name).SetValueAsync(0);
                    }
                    else
                    {
                        print("This name is used by other one.");
                        //Show pop up.
                        FindObjectOfType<MainCanvas>().GiveResult(false,name);
                    }
                    completed = true;
                }                     
            });
    }

    public void WriteNewLevel (string username, float level,int kill) {
        if (!completed)
        {
            StartCoroutine(Loading());
        }

        completed = false;
        Dictionary<string, object> childUpdatesLevel = new Dictionary<string, object>();
        Dictionary<string, object> childUpdatesKill = new Dictionary<string, object>();
        childUpdatesLevel[username]=level;
        childUpdatesKill[username]=kill;
        Level_Ranks_Reference.UpdateChildrenAsync(childUpdatesLevel);
        KillNumber_Ranks_Reference.UpdateChildrenAsync(childUpdatesKill);
        completed = true;
    }


    public void GetFromDatabase_FirstTenPeopleListAndThisPersonAsLevel()
    {
        if (!completed)
        {
            StartCoroutine(Loading());
        }
        Level_Ranks_Reference.OrderByValue().LimitToLast(10)
            .GetValueAsync().ContinueWithOnMainThread(task =>
            {
                if (task.IsFaulted)
                {
                    // Handle the error...
                }
                else if (task.IsCompleted)
                {
                    first_ten_users_Level.Clear();
                    DataSnapshot snapshot = task.Result;
                    foreach (var child in snapshot.Children)
                    {
                        first_ten_users_Level.Add(child.Key,float.Parse(child.Value.ToString()));
                    }
                    FindObjectOfType<RanksSystem>().ListFirstTenPeopleLevel(first_ten_users_Level);
                    completed = true;
                } 
            });
    }
    public void GetFromDatabase_FirstTenPeopleListAndThisPersonAsKillNumber()
    {
        if (!completed)
        {
            StartCoroutine(Loading());
        }
        KillNumber_Ranks_Reference.OrderByValue().LimitToLast(10)
            .GetValueAsync().ContinueWithOnMainThread(task =>
            {
                if (task.IsFaulted)
                {
                    // Handle the error...
                }
                else if (task.IsCompleted)
                {
                    first_ten_users_killNumber.Clear();
                    DataSnapshot snapshot = task.Result;
                    foreach (var child in snapshot.Children)
                    {
                        first_ten_users_killNumber.Add(child.Key,Int32.Parse(child.Value.ToString()));
                    }
                    FindObjectOfType<RanksSystem>().ListFirstTenPeopleKillNumber(first_ten_users_killNumber);
                    completed = true;
                } 
            });
    }

    private IEnumerator Loading()
    {
        while (!completed)
        {
            yield return new WaitForSeconds(.2f);
        }
    }
}
