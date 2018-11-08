using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenus : MonoBehaviour {

    public bool gamePause = false;
    public GameObject Menu, quitConfirmation, menuConfirmation;
    public bool pauseWorldState;
    bool UIOpen = false;

    bool UIOn = false;

    // Use this for initialization
    void Start () {
        Menu = GameObject.FindWithTag("Menu");
        quitConfirmation = GameObject.FindWithTag("ConfQuit");
        menuConfirmation = GameObject.FindWithTag("ConfMenu");
        quitConfirmation.SetActive(false);
        menuConfirmation.SetActive(false);
        Menu.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {


        if (Input.GetKeyDown(KeyCode.Escape) && UIOn == false)
        {
            Menu.SetActive(true);
            UIOn = true;
            pauseWorldState = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && UIOn == true)
        {
            Menu.SetActive(false);
            UIOn = false;
            quitConfirmation.SetActive(false);
            menuConfirmation.SetActive(false);
            pauseWorldState = false;
        }
        
	}
    


    public void Resume()
    {
        Menu.SetActive(false);
        UIOn = false;
        pauseWorldState = false;
    }



    public void launchGame()
    {
        SceneManager.LoadScene("TEMPTEMPTEMP");
    }

    public void Restart()
    {
        SceneManager.LoadScene("TEMPTEMPTEMP");
    }



    //Application Quit and Checks
    public void Quit()
    {
        Menu.SetActive(false);
        quitConfirmation.SetActive(true);
    }

    public void CancQuit()
    {
        quitConfirmation.SetActive(false);
        menuConfirmation.SetActive(false);
        Menu.SetActive(true);
    }

    public void ConfQuit()
    {
        Application.Quit();
    }



    public void ReturnMenu()
    {
        Menu.SetActive(false);
        menuConfirmation.SetActive(true);
    }

    public void ConfMenu()
    {
        SceneManager.LoadScene("TEMPTEMPTEMP");
    }





}
