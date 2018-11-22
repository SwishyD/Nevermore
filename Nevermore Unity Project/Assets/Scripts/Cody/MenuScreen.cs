using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScreen : MonoBehaviour {

    public GameObject menuScreenUI;
    public GameObject creditsUI;
    public GameObject controlScreenUI;
    public GameObject quitConfirmUI;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartGame()
    {
        SceneManager.LoadScene("lvl1Cody");
    }

    
    public void ControlsMenu()
    {
        menuScreenUI.SetActive(false);
        controlScreenUI.SetActive(true);
    }

    public void Credits()
    {
        menuScreenUI.SetActive(false);
        creditsUI.SetActive(true);
    }

    public void QuitGameConfirmation()
    {
        menuScreenUI.SetActive(false);
        quitConfirmUI.SetActive(true);
    }

    public void ReturnToPause()
    {
        menuScreenUI.SetActive(true);
        controlScreenUI.SetActive(false);
        quitConfirmUI.SetActive(false);
        creditsUI.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
