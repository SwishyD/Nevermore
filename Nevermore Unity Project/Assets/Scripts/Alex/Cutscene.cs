using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour {

    private void Awake()
    {
        Cursor.visible = false;
    }

    // Use this for initialization
    public void Load()
    {
        Cursor.visible = true;
        SceneManager.LoadScene(2);
        
    }
}
