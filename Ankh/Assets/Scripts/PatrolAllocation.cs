using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAllocation : MonoBehaviour
{
    [SerializeField] Canvas mapAndPatrolAllocation;
    [SerializeField] OfficerManagement officerManagement;

    // Start is called before the first frame update
    void Start()
    {
        mapAndPatrolAllocation.gameObject.SetActive(false);
        CheckPatrolAllocation();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CheckPatrolAllocation(Officer)
    {
        foreach (Officer officer in officerManagement.officerPatrol)
        {
            GetComponent<Officer>().patrolArea.GetType();
            if(Officer. = 0)
            {

            }
        }
    }
}
