using UnityEngine;

public interface SectionsFunctions
{
    void KillNumberAssignmentControl();
}

public class Assignment : MonoBehaviour, SectionsFunctions
{

    //---------------- Control Part Of Sections Assignments ---------------

    public void KillNumberAssignmentControl()
    {
        
        if (PlayerPrefsOperations.Instance.GetData().currentAssignmentKill >= PlayerPrefsOperations.Instance.GetData().targetKillAssignment)
        {
            DatabaseSkeleton old = PlayerPrefsOperations.Instance.GetData();
            old.isReadAll = false;
            old.section++;
            switch (old.section)
            {
                case 1:
                    old.selectedWarTypeName = "Spider";
                    old.targetKillAssignment = 5;
                    break;
                case 2:
                    old.selectedWarTypeName = "Dragon";
                    old.targetKillAssignment = 4;
                    break;
                case 3:
                    old.selectedWarTypeName = "Devil";
                    old.targetKillAssignment = 1;
                    break; 
                case 4:
                    old.targetKillAssignment = 5;
                    FindObjectOfType<MapCanvas>().RemoveWarrior();
                    old.isWarriorDead = true;
                    break;
                case 5:
                    old.selectedWarTypeName = "Mix";
                    old.targetKillAssignment = 8;
                    break;
                case 6:
                    old.openedMaps.Add(2);
                    old.targetKillAssignment = 150;
                    break;
            }
            
            PlayerPrefsOperations.Instance.SaveData(old);
        }
    }
}





