using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAllocation : MonoBehaviour
{
    [SerializeField] Canvas mapAndPatrolAllocation;

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

    private void CheckPatrolAllocation()
    {
        
    }
}
