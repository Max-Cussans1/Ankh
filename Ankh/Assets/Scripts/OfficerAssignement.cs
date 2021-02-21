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
        officerAssignment.gameObject.SetActive(false);
        //Cannot work out how to find all of the officers in scene
        //officerTotal = FindObjectsOfType(GameObject(Officer)).Legnth;
        UpdateOfficerTotal();
    }

    private void UpdateOfficerTotal()
    {
        officerTotalText.text = officerTotal.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        print("Total officers = " + officerTotal);
    }

    public void IncreaseOfficers()
    {
        officerTotal++;
        UpdateOfficerTotal();
    }

    public void DecreaseOfficers()
    {
        officerTotal--;
        UpdateOfficerTotal();
    }
}
