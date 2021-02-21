using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficerManagement : MonoBehaviour
{
    [SerializeField] Officer officerToInstantiate;
    [SerializeField] Transform PoliceStation;

    List<Officer> officerIdle = new List<Officer>();
    List<Officer> officerPatrol = new List<Officer>();
    List<Officer> officerInvestigation = new List<Officer>();
    List<Officer> officerRecords = new List<Officer>();

    void Start()
    {
        
    }

    public void HireNewOfficer()
    {
        //Spawns us an officer but does not add it to a list...yet
        Officer newOfficer = Instantiate(officerToInstantiate, PoliceStation.position, Quaternion.identity);
        officerIdle.Add(newOfficer);
    }
}
