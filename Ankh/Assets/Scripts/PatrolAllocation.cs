using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PatrolAllocation : MonoBehaviour
{
    [SerializeField] Canvas mapAndPatrolAllocation;
    [SerializeField] OfficerManagement officerManagement;

    [Header("Patrol group to string")]
    [SerializeField] TMP_Text allPatrolingOfficer;
    [SerializeField] TMP_Text unassignedText;
    [SerializeField] TMP_Text areaOneText;
    [SerializeField] TMP_Text areaTwoText;
    [SerializeField] TMP_Text areaThreeText;
    [SerializeField] TMP_Text areaFourText;
    [SerializeField] TMP_Text areaFiveText;

    OfficerManagement officerManagementRef;

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
        CheckPatrolAllocation();
        resetPatrolNumbers();
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
        officerManagementRef = GetComponent<OfficerManagement>();
        print("Checking Patrol Allocation");
        foreach (Officer officer in officerManagement.officerPatrol)
        {
            if (officer.patrolArea == 0)
            {
                unassigned++;
                print(unassigned);
            }
            if (officer.patrolArea == 1)
            {
                areaOne++;
            }
            if (officer.patrolArea == 2)
            {
                areaTwo++;
            }
            if (officer.patrolArea == 3)
            {
                areaThree++;
            }
            if (officer.patrolArea == 4)
            {
                areaFour++;
            }
            if (officer.patrolArea == 5)
            {
                areaFive++;
            }
            stringPatrolNumbersToUI();
        }
    }

    public void stringPatrolNumbersToUI()
    {
        print("stringing totals to UI");
        int allPatrolingOfficerCount = officerManagement.officerPatrol.Count;
        allPatrolingOfficer.text = allPatrolingOfficerCount.ToString();
        unassignedText.text = unassigned.ToString() + "/" + allPatrolingOfficerCount.ToString();
        areaOneText.text = areaOne.ToString() + "/" + allPatrolingOfficerCount.ToString();
        areaTwoText.text = areaTwo.ToString() + "/" + allPatrolingOfficerCount.ToString();
        areaThreeText.text = areaThree.ToString() + "/" + allPatrolingOfficerCount.ToString();
        areaFourText.text = areaFour.ToString() + "/" + allPatrolingOfficerCount.ToString();
        areaFiveText.text = areaFive.ToString() + "/" + allPatrolingOfficerCount.ToString();
    }

    public void MoveOfficerPatrolGroup()
    {
        //Define which way we want to move the officer (Idle/0 to active/1-5) or the opposite
        //Define which idle officer we are moving
        //Switch the officer to the new patrol group
        //If there are none free - give the player a pop up       
    }

}
