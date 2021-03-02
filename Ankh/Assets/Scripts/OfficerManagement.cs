using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OfficerManagement : MonoBehaviour
{

    //Lists
    List<Officer> officerIdle = new List<Officer>();
    List<Officer> officerPatrol = new List<Officer>();
    List<Officer> officerInvestigation = new List<Officer>();
    List<Officer> officerRecords = new List<Officer>();

    [SerializeField] Officer officerToInstantiate;
    [SerializeField] Transform PoliceStation;
    [SerializeField] int officerTotal = 0;

    [Header("To String Objects")]
    [SerializeField] TMP_Text patrollingOfficerTotal;
    [SerializeField] TMP_Text investigatingOfficerTotal;
    [SerializeField] TMP_Text recordsOfficerTotal;
    [SerializeField] TMP_Text idleOfficerTotal;
    [SerializeField] TMP_Text officerTotalText;

    [Header("Canvases")]
    [SerializeField] Canvas officerAssignment;

    void Start()
    {
        //Turns off the UI panel at run time (seems to be the best way to do it)
        officerAssignment.gameObject.SetActive(false);
        officerTotal = FindObjectsOfType(typeof(Officer)).Length;

        UpdateOfficerTotal();
        UpdatePatrollingTotal();
    }

    private void UpdateOfficerTotal()
    {
        officerTotal = FindObjectsOfType(typeof(Officer)).Length;
        officerTotalText.text = officerTotal.ToString();
        print("Officer Total = " + officerTotal);
    }

    private void UpdatePatrollingTotal()
    {
        patrollingOfficerTotal.text = officerPatrol.Count.ToString() + "/" + officerTotal.ToString();
    }

    public void HireNewOfficer()
    {
        Officer newOfficer = Instantiate(officerToInstantiate);
        officerIdle.Add(newOfficer);
        UpdateOfficerTotal();

    }

    public void FireOfficer()
    {
        
        if (officerIdle.Count <= 0)
        {
            //Todo - Pop up a UI saying - no idle officers.
            print("No Officer to fire");
            return;
        }
        else
        {
            //Eventually this should remove the specific officer from the force for now we just remove one idle officer
            Officer firedOfficer = officerIdle[officerIdle.Count-1];
            Destroy(firedOfficer.gameObject);
            officerIdle.Remove(officerIdle[officerIdle.Count -1]);
            UpdateOfficerTotal();
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
            UpdatePatrollingTotal();
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
