using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Officer : MonoBehaviour
{
    public string officerName;
    public string officerRace;
    public int officerLevel;
    public int patrolArea;

    public Officer(string newOfficerName, string newOfficerRace, int newOfficerLevel, int newPatrolArea)
    {
        officerName = newOfficerName;
        officerRace = newOfficerRace;
        officerLevel = newOfficerLevel;
        patrolArea = newPatrolArea;
    }
}
