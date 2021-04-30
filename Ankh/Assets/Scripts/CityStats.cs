using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CityStats : MonoBehaviour
{
    [SerializeField] Image crimeRateImage;
    [SerializeField] Image publicOpinionImage;
    [SerializeField] Image prosperityImage;

    float crimeRate = 0.1f;
    float publicOpinion = 0.8f;
    float prosperity = 0.55f;

    void Update()
    {
        //DefineCrimeRateBarColour();
    }

    void Start()
    {
        UpdateCityStats();
        DefineCrimeRateBarColour(crimeRate, crimeRateImage, false);
        DefineCrimeRateBarColour(publicOpinion, publicOpinionImage, true);
        DefineCrimeRateBarColour(prosperity, prosperityImage, true);
    }

    private void UpdateCityStats()
    {
        crimeRateImage.fillAmount = crimeRate;
        publicOpinionImage.fillAmount = publicOpinion;
        prosperityImage.fillAmount = prosperity;
    }

    private void DefineCrimeRateBarColour(float barToCheck, Image imageToChange, bool reverse)
    {
        if (barToCheck <= 0.25f)
        {
            if (reverse){imageToChange.GetComponent<Image>().color = Color.red;}
            else{imageToChange.color = Color.green;}   
        }
        else if (barToCheck > 0.25f && barToCheck <= 0.5f)
        {
            if (reverse){ imageToChange.GetComponent<Image>().color = new Color32(225, 74, 0, 225); }
            else{imageToChange.color = Color.yellow;}
        }
        else if (barToCheck > 0.5 && barToCheck <= 0.75)
        {
            if (reverse) { imageToChange.GetComponent<Image>().color = Color.yellow; }
            else { imageToChange.color = new Color32(225, 74, 0, 225); }
        }
        else if (barToCheck > 0.75)
        {
            if (reverse) { imageToChange.GetComponent<Image>().color = Color.green; }
            else { imageToChange.color = Color.red; } 
        }
        else
        {
            imageToChange.GetComponent<Image>().color = Color.cyan;
        }
    }
}
