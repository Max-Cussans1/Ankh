using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PatrolAllocation : MonoBehaviour
{
    [SerializeField] Canvas mapAndPatrolAllocation;
    [SerializeField] Canvas noFreeOfficersPopUp;
    [Header("Patrol group to string")]
    [SerializeField] TMP_Text allPatrolingOfficer;
    [SerializeField] TMP_Text unassignedText;
    [SerializeField] TMP_Text areaOneText;
    [SerializeField] TMP_Text areaTwoText;
    [SerializeField] TMP_Text areaThreeText;
    [SerializeField] TMP_Text areaFourText;
    [SerializeField] TMP_Text areaFiveText;

    OfficerManagement officerManagementRef;
    [SerializeField] OfficerManagement officerManagementSF;
    int selectedPatrolButton;

    [Header("Patrol totals")]
    public int unassigned = 0;
    public int areaOne = 0;
    public int areaTwo = 0;
    public int areaThree = 0;
    public int areaFour = 0;
    public int areaFive = 0;



    // Start is called before the first frame update
    void Start()
    {
        mapAndPatrolAllocation.gameObject.SetActive(false);
        UpdateAllNumber();
    }

    private void resetPatrolNumbers()
    {
        unassigned = 0;
        areaOne = 0;
        areaTwo = 0;
        areaThree = 0;
        areaFour = 0;
        areaFive = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateAllNumber()
    {
        resetPatrolNumbers();
        CheckPatrolAllocation();
        stringPatrolNumbersToUI();
    }

    public void CheckPatrolAllocation()
    {
        if (officerManagementSF.officerPatrol.Count == 0)
        {
            return;
        }
        else
        { 
            foreach (Officer patrolingOfficer in officerManagementSF.officerPatrol)
            {
                if (patrolingOfficer.patrolArea == 0)
                {
                    unassigned++;
                }
                if (patrolingOfficer.patrolArea == 1)
                {
                    areaOne++;
                }
                if (patrolingOfficer.patrolArea == 2)
                {
                    areaTwo++;
                }
                if (patrolingOfficer.patrolArea == 3)
                {
                    areaThree++;
                }
                if (patrolingOfficer.patrolArea == 4)
                {
                    areaFour++;
                }
                if (patrolingOfficer.patrolArea == 5)
                {
                    areaFive++;
                }
            }
        }
    }

    public void stringPatrolNumbersToUI()
    {
        print("stringing totals to UI");
        int allPatrolingOfficerCount = officerManagementSF.officerPatrol.Count;
        allPatrolingOfficer.text = allPatrolingOfficerCount.ToString();
        unassignedText.text = unassigned.ToString() + "/" + allPatrolingOfficerCount.ToString();
        areaOneText.text = areaOne.ToString() + "/" + allPatrolingOfficerCount.ToString();
        areaTwoText.text = areaTwo.ToString() + "/" + allPatrolingOfficerCount.ToString();
        areaThreeText.text = areaThree.ToString() + "/" + allPatrolingOfficerCount.ToString();
        areaFourText.text = areaFour.ToString() + "/" + allPatrolingOfficerCount.ToString();
        areaFiveText.text = areaFive.ToString() + "/" + allPatrolingOfficerCount.ToString();
    }
    public void AreaOnePressed() { selectedPatrolButton = 1; }
    public void AreaTwoPressed() { selectedPatrolButton = 2; }
    public void AddAreaThreePressed() { selectedPatrolButton = 3; }
    public void AddAreaFourPressed() { selectedPatrolButton = 4; }
    public void AddAreaFivePressed() { selectedPatrolButton = 5; }

    public void MoveUnassignedToActive()
    {
        if (unassigned == 0)
        {
            noFreeOfficersPopUp.gameObject.SetActive(true);
        }
        else
        {
            foreach (Officer officer in officerManagementSF.officerPatrol)
            {
                if (officer.patrolArea == 0)
                {
                    officer.patrolArea = selectedPatrolButton;
                    //return;
                }
            }
        }
        UpdateAllNumber();
    }

    public void moveActiveOfficerToUnassigned()
    {
        foreach (Officer officer in officerManagementSF.officerPatrol)
        {
            if (officer.patrolArea == selectedPatrolButton)
            {
                officer.patrolArea = 0;
                return;
            }
            else
            {
                noFreeOfficersPopUp.gameObject.SetActive(true);
            }
        }
        UpdateAllNumber();
    }
}
