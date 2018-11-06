using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenus : MonoBehaviour {

    public bool gamePause = false;
    public GameObject Menu, QuitConfirmation;
    public bool pauseWorldState;

    // Use this for initialization
    void Start () {
        Menu = GameObject.FindWithTag("Menu");
        QuitConfirmation = GameObject.FindWithTag("ConfQuit");
        QuitConfirmation.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gamePause = !gamePause;
        }

        if (gamePause == true)
        {
            enterPause();
            
        }
        else if (gamePause == false)
        {
            exitPause();
        }

        //print(gamePause);

	}

    void enterPause()
    {
        Menu.SetActive(true);
    }

    void exitPause()
    {
        Menu.SetActive(false);
    }



    public void Resume()
    {
        gamePause = false;
    }

    public void launchGame()
    {
        SceneManager.LoadScene("doorGame");
    }

    public void Quit()
    {
        QuitConfirmation.SetActive(true);
        gamePause = false;
    }

    public void CancQuit()
    {
        QuitConfirmation.SetActive(false);
        gamePause = true;
    }

    public void ConfQuit()
    {
        Application.Quit();
    }

}



//pauseWorldState = true;
//pauseWorldState = false;