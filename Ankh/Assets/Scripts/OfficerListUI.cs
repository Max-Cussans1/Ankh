using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OfficerListUI : MonoBehaviour
{

    [SerializeField] OfficerManagement officerManagementRef;
    [SerializeField] GameObject contentListLocation;
    [SerializeField] GameObject officerListTemplate;
    [SerializeField] TMP_Text officerNameButtonText;
    [SerializeField] TMP_Text officerRaceButtonText;
    [SerializeField] TMP_Text officerLevelButtonText;
    [SerializeField] TMP_Text officerRoleButtonText;

    // Start is called before the first frame update
    void Start()
    {
        PopulateListOfOfficers();
    }

    public void PopulateListOfOfficers()
    {
        foreach (Officer officer in officerManagementRef.officerPatrol)
        {
            officerNameButtonText.text = officer.officerName.ToString();
            officerRaceButtonText.text = officer.officerRace.ToString();
            officerLevelButtonText.text = officer.officerLevel.ToString();

            var officerListEntry = Instantiate(officerListTemplate);
            officerListEntry.transform.parent = contentListLocation.transform;


        }
        //TODO
        //Find all officers in the scene/game
        //Create a UI list item for them
        //Display their data in that list
        //Bonus - Allow the player to modify the list.
    }


}
