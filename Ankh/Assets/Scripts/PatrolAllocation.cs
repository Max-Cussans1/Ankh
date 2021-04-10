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
    int unassigned = 0;
    int areaOne = 0;
    int areaTwo = 0;
    int areaThree = 0;
    int areaFour = 0;
    int areaFive = 0;

    // Start is called before the first frame update
    void Start()
    {
        mapAndPatrolAllocation.gameObject.SetActive(false);
        CheckPatrolAllocation();
        resetPatrolNumbers();
    }

    private void resetPatrolNumbers()
    {
        int unassigned = 0;
        int areaOne = 0;
        int areaTwo = 0;
        int areaThree = 0;
        int areaFour = 0;
        int areaFive = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateAllNumber()
    {
        resetPatrolNumbers();
        CheckPatrolAllocation();
    }

    public void CheckPatrolAllocation()
    {
        officerManagementRef = GetComponent<OfficerManagement>();
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
            else if (currentAllocation == 1)
            {
                areaOne++;
            }
            else if (currentAllocation == 2)
            {
                areaTwo++;
            }
            else if (currentAllocation == 3)
            {
                areaThree++;
            }
            else if (currentAllocation == 4)
            {
                areaFour++;
            }
            else if (currentAllocation == 5)
            {
                areaFive++;
            }
            stringPatrolNumersToUI();
        }
    }

    private void stringPatrolNumersToUI()
    {
        int allPatrolingOfficerCount = officerManagement.officerPatrol.Count;
        allPatrolingOfficer.text = allPatrolingOfficer.ToString();
        unassignedText.text = unassigned + "/" + allPatrolingOfficer.ToString();
        areaOneText.text = areaOne + "/" + allPatrolingOfficer.ToString();
        areaTwoText.text = areaTwo + "/" + allPatrolingOfficer.ToString();
        areaThreeText.text = areaThree + "/" + allPatrolingOfficer.ToString();
        areaFourText.text = areaFour + "/" + allPatrolingOfficer.ToString();
        areaFiveText.text = areaFive + "/" + allPatrolingOfficer.ToString();
    }
}
