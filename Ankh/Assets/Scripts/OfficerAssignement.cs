using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficerAssignement : MonoBehaviour
{

    [SerializeField] Canvas officerAssignment;
    // Start is called before the first frame update
    void Start()
    {
        officerAssignment.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
