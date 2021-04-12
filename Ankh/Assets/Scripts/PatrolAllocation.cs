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

    //TMP_Text totalPatrollingOfficers = officerManagement.officerPatrol.Count;
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
        officerManagementRef.CheckPatrolAllocation();
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
        officerManagementRef.CheckPatrolAllocation();
        stringPatrolNumbersToUI();
    }

    public void CheckPatrolAllocationOLD()
    {
        officerManagementRef = GetComponent<OfficerManagement>();
        print("Checking Patrol Allocation");
        foreach (Officer officer in officerManagement.officerPatrol)
        {
            GameObject theofficer = GameObject.Find("Officer");
            Officer officerScript = theofficer.GetComponent<Officer>();
            int currentAllocation = officerScript.patrolArea;

            if (currentAllocation == 0)
            {
                unassigned++;
                print(unassigned);
            }
            if (currentAllocation == 1)
            {
                areaOne++;
            }
            if (currentAllocation == 2)
            {
                areaTwo++;
            }
            if (currentAllocation == 3)
            {
                areaThree++;
            }
            if (currentAllocation == 4)
            {
                areaFour++;
            }
            if (currentAllocation == 5)
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
}
