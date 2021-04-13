﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class OfficerManagement : MonoBehaviour
{

    //Lists
    List<Officer> officerIdle = new List<Officer>();
    public List<Officer> officerPatrol = new List<Officer>();
    List<Officer> officerInvestigation = new List<Officer>();
    List<Officer> officerRecords = new List<Officer>();

    [SerializeField] Officer officerToInstantiate;
    [SerializeField] Transform PoliceStation;
    [SerializeField] int officerTotal = 0;

    [Header("Officer Assignment panel to string")]
    [SerializeField] TMP_Text patrollingOfficerTotal;
    [SerializeField] TMP_Text investigatingOfficerTotal;
    [SerializeField] TMP_Text recordsOfficerTotal;
    [SerializeField] TMP_Text idleOfficerTotal;
    [SerializeField] TMP_Text officerTotalText;

    [Header("Home Page officer overview")]

    [Header("Canvases")]
    [SerializeField] Canvas officerAssignment;
    [SerializeField] Canvas noFreeOfficersPopUp;
    [SerializeField] Canvas hireOfficerPopUp;

    [Header("Officer Race Buttons")]
    [SerializeField] Button humanButton;
    [SerializeField] Button DwarfButton;
    [SerializeField] Button TrollButton;
    [SerializeField] Button GoblinButton;

    PatrolAllocation patrolAllocationRef;
    string selectedOfficerRace;

    void Start()
    {
        //Turns off the UI panel at run time (seems to be the best way to do it)
        officerAssignment.gameObject.SetActive(false);
        noFreeOfficersPopUp.gameObject.SetActive(false);
        hireOfficerPopUp.gameObject.SetActive(false);
        officerTotal = FindObjectsOfType(typeof(Officer)).Length;

        StringTotalsToUI();
        SelectOfficerRace();
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
        Officer newOfficer = Instantiate(officerToInstantiate);
        officerIdle.Add(newOfficer);
        AssignOfficerStats(newOfficer);
        StringTotalsToUI();
    }

    private void AssignOfficerStats(Officer newOfficer)
    {
        newOfficer.officerName = "Name";
        newOfficer.officerRace = selectedOfficerRace;
        newOfficer.officerLevel = 1;
        newOfficer.patrolArea = 0;
        newOfficer.patroling = false;
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
            idleToPatrol.patroling = true;
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
            patrolToIdle.patroling = false;
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

    private void SelectOfficerRace()
    {
        humanButton.onClick.AddListener(HumanRaceSelected);
        DwarfButton.onClick.AddListener(DwarfRaceSelected);
        TrollButton.onClick.AddListener(TrollRaceSelected);
        GoblinButton.onClick.AddListener(GoblinRaceSelected);
}

    private void HumanRaceSelected()
    {
        selectedOfficerRace = "Human";
    }

    private void DwarfRaceSelected()
    {
        selectedOfficerRace = "Dwarf";
    }

    private void TrollRaceSelected()
    {
        selectedOfficerRace = "Troll";
    }

    private void GoblinRaceSelected()
    {
        selectedOfficerRace = "Goblin";
    }

    private void NoFreeOfficers()
    {
        noFreeOfficersPopUp.gameObject.SetActive(true);
    }
    public void CheckPatrolAllocation()
    {
        foreach (Officer officer in officerPatrol)
        {
            GameObject theofficer = GameObject.Find("Officer");
            Officer officerScript = theofficer.GetComponent<Officer>();
            int currentAllocation = officerScript.patrolArea;

            if (currentAllocation == 0)
            {
                patrolAllocationRef.unassigned++;
            }
            if (currentAllocation == 1)
            {
                patrolAllocationRef.areaOne++;
            }
            if (currentAllocation == 2)
            {
                patrolAllocationRef.areaTwo++;
            }
            if (currentAllocation == 3)
            {
                patrolAllocationRef.areaThree++;
            }
            if (currentAllocation == 4)
            {
                patrolAllocationRef.areaFour++;
            }
            if (currentAllocation == 5)
            {
                patrolAllocationRef.areaFive++;
            }
            patrolAllocationRef.stringPatrolNumbersToUI();
        }
    }
}
