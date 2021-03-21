using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

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
    [SerializeField] Canvas noFreeOfficersPopUp;

    void Start()
    {
        //Turns off the UI panel at run time (seems to be the best way to do it)
        officerAssignment.gameObject.SetActive(false);
        noFreeOfficersPopUp.gameObject.SetActive(false);
        officerTotal = FindObjectsOfType(typeof(Officer)).Length;

        StringTotalsToUI();
    }

    private void StringTotalsToUI()
    {
        UpdateOfficerTotal();
        UpdateOfficerJobs();
    }

    private void UpdateOfficerTotal()
    {
        officerTotal = officerIdle.Count + officerInvestigation.Count + officerRecords.Count + officerPatrol.Count;
        officerTotalText.text = officerTotal.ToString();
    }

    private void UpdateOfficerJobs()
    {
        patrollingOfficerTotal.text = officerPatrol.Count.ToString() + "/" + officerTotal.ToString();
        investigatingOfficerTotal.text = officerInvestigation.Count.ToString() + "/" + officerTotal.ToString();
        recordsOfficerTotal.text = officerRecords.Count.ToString() + "/" + officerTotal.ToString();
        idleOfficerTotal.text = officerIdle.Count.ToString() + "/" + officerTotal.ToString();

    }

    public void HireNewOfficer()
    {
        //So I do not need to actually add officers!?
        Officer newOfficer = Instantiate(officerToInstantiate);
        officerIdle.Add(newOfficer);
        AssignOfficerStats(newOfficer);
    }

    private static void AssignOfficerStats(Officer newOfficer)
    {
        newOfficer.officerName = "Name";
        newOfficer.officerRace = "Goblin";
        newOfficer.officerLevel = 1;
        newOfficer.patrolArea = 0;
    }

    public void FireOfficer()
    {
        
        if (officerIdle.Count <= 0)
        {
            //Todo - Pop up a UI saying - no idle officers.
            print("No Officer to fire");
        }
        else
        {
            //Eventually this should remove the specific officer from the force for now we just remove one idle officer
            Officer firedOfficer = officerIdle[officerIdle.Count-1];
            Destroy(firedOfficer.gameObject);
            officerIdle.Remove(officerIdle[officerIdle.Count -1]);
            StringTotalsToUI();
        }
    }
    public void MoveIdleOfficerToPatrolling()
    {
        if (officerIdle.Count <= 0)
        {
            NoFreeOfficers();
        }
    else
        {
            Officer idleToPatrol = officerIdle[officerIdle.Count - 1];
            officerIdle.Remove(idleToPatrol);
            officerPatrol.Add(idleToPatrol);
            StringTotalsToUI();
        }
    }

    public void MovePatrolingOfficerToIdle()
    {
        if (officerPatrol.Count <= 0)
        {
            NoFreeOfficers();
        }
        else
        {
            Officer patrolToIdle = officerPatrol[officerPatrol.Count - 1];
            officerPatrol.Remove(patrolToIdle);
            officerIdle.Add(patrolToIdle);
            StringTotalsToUI();
        }
    }

    public void MoveIdleOfficerToInvestigation()
    {
        if (officerIdle.Count <= 0)
        {
            NoFreeOfficers();
        }

        else
        {
            Officer idleToInvestigation = officerIdle[officerIdle.Count - 1];
            officerIdle.Remove(idleToInvestigation);
            officerInvestigation.Add(idleToInvestigation);
            StringTotalsToUI();
        }
    }

    public void MoveInvestigationOfficerToIdle()
    {
        if (officerInvestigation.Count <= 0)
        {
            NoFreeOfficers();
        }

        else
        {
            Officer investigationToIdle = officerInvestigation[officerInvestigation.Count - 1];
            officerInvestigation.Remove(investigationToIdle);
            officerIdle.Add(investigationToIdle);
            StringTotalsToUI();
        }
    }

    public void MoveIdleOfficerToRecords()
    {
        if (officerIdle.Count <= 0)
        {
            NoFreeOfficers();
        }

        else
        {
            Officer idleToRecords = officerIdle[officerIdle.Count - 1];
            officerIdle.Remove(idleToRecords);
            officerRecords.Add(idleToRecords);
            StringTotalsToUI();
        }
    }

    public void MoveRecordsOfficerToIdle()
    {
        if (officerRecords.Count <= 0)
        {
            NoFreeOfficers();
        }

        else
        {
            Officer recordsToIdle = officerRecords[officerRecords.Count - 1];
            officerRecords.Remove(recordsToIdle);
            officerIdle.Add(recordsToIdle);
            StringTotalsToUI();
        }
    }
    private void NoFreeOfficers()
    {
        noFreeOfficersPopUp.gameObject.SetActive(true);
    }
}
