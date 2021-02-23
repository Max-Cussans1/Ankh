using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OfficerAssignement : MonoBehaviour
{
    
    [SerializeField] Canvas officerAssignment;
    [SerializeField] int officerTotal = 0;
    [SerializeField] TMP_Text officerTotalText;

    
    // Start is called before the first frame update
    void Start()
    {
        //Turns off the UI panel at run time (seems to be the best way to do it)
        officerAssignment.gameObject.SetActive(false);
        
        //Give us the total number of officers at start of run time.
        officerTotal = FindObjectsOfType(typeof(Officer)).Length;

        UpdateOfficerTotal();
    }

    private void UpdateOfficerTotal()
    {
        officerTotal = FindObjectsOfType(typeof(Officer)).Length;
        officerTotalText.text = officerTotal.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Accessed via a button in the unity UI system
    public void IncreaseOfficers()
    {
        UpdateOfficerTotal();
    }

    public void DecreaseOfficers()
    {

        UpdateOfficerTotal();
    }
}
