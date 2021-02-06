using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Canvas loadMenuCanvas;
    [SerializeField] Canvas optionsMenuCanvas;

    int level;


    // Start is called before the first frame update
    void Start()
    {
        loadMenuCanvas.gameObject.SetActive(false);
        optionsMenuCanvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ContinueButton()
    {
        DefineLevel();
        SceneManager.LoadScene(level);
    }

    private void DefineLevel()
    {
        //This needs to work out which savefile to load eventually.
        level = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
