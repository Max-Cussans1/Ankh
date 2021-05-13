using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficerListUI : MonoBehaviour
{

    [SerializeField] OfficerManagement officerManagementRef;
    [SerializeField] GameObject contentListLocation;
    [SerializeField] GameObject officerListTemplate;

    // Start is called before the first frame update
    void Start()
    {
        PopulateListOfOfficers();
    }

    public void PopulateListOfOfficers()
    {
        foreach (Officer officer in officerManagementRef.officerPatrol)
        {
            var officerListEntry = Instantiate(officerListTemplate);
            officerListEntry.transform.parent = contentListLocation.transform;

            print("Name =" + officer.officerName);
            print("Race = " + officer.officerRace);
            print("Level = " + officer.officerLevel);
            print("patrol Area =" + officer.patrolArea);
        }
        //TODO
        //Find all officers in the scene/game
        //Create a UI list item for them
        //Display their data in that list
        //Bonus - Allow the player to modify the list.
    }


}
