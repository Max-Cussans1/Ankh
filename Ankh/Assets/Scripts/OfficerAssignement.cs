using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OfficerAssignement : MonoBehaviour
{
    
    [SerializeField] Canvas officerAssignment;
    [SerializeField] int officerTotal = 30;
    [SerializeField] Text officerTotalText;
    // Start is called before the first frame update
    void Start()
    {
        officerAssignment.gameObject.SetActive(false);
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
    }

    public void DecreaseOfficers()
    {
        officerTotal--;
    }
}
