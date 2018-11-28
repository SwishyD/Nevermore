using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    public GameObject player;

    //for cursor
    public Texture2D pointer;
    public Texture2D crosshair;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;


    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject controlScreenUI;
    public GameObject quitConfirmUI;
    public GameObject menuConfirmUI;

    public static bool controlActive = false;
    public static bool quitActive = false;
    public static bool menuActive = false;

    // Use this for initialization
    void Start () {
        Cursor.SetCursor(crosshair, hotSpot, cursorMode);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                if (controlActive == true)
                {
                    ReturnToPause();
                    controlActive = false;

                }
                else if (menuActive == true)
                {
                    ReturnToPause();
                    menuActive = false;
                    
                }
                else if (quitActive == true)
                {
                    ReturnToPause();
                    quitActive = false;
                    
                }
              
                else
                {
                    Resume();
                }
            }
            else
            {
               
                Pause();
            }
        }
	}

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        menuConfirmUI.SetActive(false);
        quitConfirmUI.SetActive(false);
        controlScreenUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        player.GetComponent<Animator>().enabled = true;
        Cursor.SetCursor(crosshair, hotSpot, cursorMode);
    }

    public  void Pause()
    {        
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        player.GetComponent<Animator>().enabled = false;
        Cursor.SetCursor(pointer, hotSpot, cursorMode);
    }

    public void QuitGameConfrim()
    {
        quitActive = true;
        pauseMenuUI.SetActive(false);
        quitConfirmUI.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);        
    }

    public void ControlScreen()
    {
        controlActive = true;
        pauseMenuUI.SetActive(false);
        controlScreenUI.SetActive(true);
    }

    public void ReturnToPause()
    {
        pauseMenuUI.SetActive(true);
        controlScreenUI.SetActive(false);
        quitConfirmUI.SetActive(false);
        menuConfirmUI.SetActive(false);
    }

    public void MenuConfrim()
    {
        menuActive = true;
        pauseMenuUI.SetActive(false);
        menuConfirmUI.SetActive(true);
    }

}
