using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficerManagement : MonoBehaviour
{
    [SerializeField] Officer officerToInstantiate;
    [SerializeField] Transform PoliceStation;

    List<Officer> officerIdle = new List<Officer>();
    List<Officer> officerPatrol = new List<Officer>();
    List<Officer> officerInvestigation = new List<Officer>();
    List<Officer> officerRecords = new List<Officer>();

    void Start()
    {
        
    }
    public void HireNewOfficer()
    {
        Officer newOfficer = Instantiate(officerToInstantiate);
        officerIdle.Add(newOfficer);
        print(officerIdle.Count + " Idle Officers");

    }

    public void FireOfficer()
    {
        
        if (officerIdle.Count <= 0)
        {
            //Pop up a UI saying - no idle officers.
            print("No Officer to fire");
            return;
        }
        else
        {
            //Eventually this should remove the specific officer from the force for now we just remove one idle officer
            //this just deletes the script
            Officer firedOfficer = officerIdle[officerIdle.Count-1];
            Destroy(firedOfficer.gameObject);
            officerIdle.Remove(officerIdle[officerIdle.Count -1]);
        }
    }
    public void MoveIdleOfficerToPatrolling()
    {
        if (officerIdle.Count <= 0)
        {
            //Pop up a UI saying - no idle officers.
            print("No Free Officers");
            return;
        }

    else
        {
            Officer idleToPatrol = officerIdle[officerIdle.Count - 1];
            officerIdle.Remove(idleToPatrol);
            officerPatrol.Add(idleToPatrol);
            print(officerIdle.Count + " Idle officers");
            print(officerPatrol.Count + " Patrolling officers");
        }

    }

    public void MoveIdleOfficerToInvestigation()
    {
        if (officerIdle.Count <= 0)
        {
            //Pop up a UI saying - no idle officers.
            print("No Free Officers");
            return;
        }

        else
        {
            Officer idleToInvestigation = officerIdle[officerIdle.Count - 1];
            officerIdle.Remove(idleToInvestigation);
            officerInvestigation.Add(idleToInvestigation);
            print(officerIdle.Count + " Idle officers");
            print(officerInvestigation.Count + " Investigating officers");
        }

    }
}
