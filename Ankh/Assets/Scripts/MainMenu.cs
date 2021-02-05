using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Canvas loadMenuCanvas;
    [SerializeField] Canvas optionsMenuCanvas; 

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

    public void QuitGame()
    {
        Application.Quit();
    }
}
