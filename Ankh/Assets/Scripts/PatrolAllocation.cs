using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAllocation : MonoBehaviour
{
    [SerializeField] Canvas mapAndPatrolAllocation;
    [SerializeField] OfficerManagement officerManagement;

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

    private void CheckPatrolAllocation()
    {
        foreach (Officer officer in officerManagement.officerPatrol)
        {
            GameObject theofficer = GameObject.Find("Officer");
            Officer officerScript = theofficer.GetComponent<Officer>();
            int currentAllocation = officerScript.patrolArea;

            if (currentAllocation == 0)
            {
                unassigned++;
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
            //String Values to Text
        }
    }
}
