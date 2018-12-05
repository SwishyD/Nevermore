using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldSaver : MonoBehaviour {

    public int goldCount;

    public static GoldSaver instance = null;
    private static bool created = false;



    private void Update()
    {
       
        GameManager.instance.playerGold = goldCount;
    }

    

    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(gameObject);
            created = true;
            Debug.Log("Awake: " + gameObject);
        }
        Time.timeScale = 1;
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void GoldManage(int goldvalue)
    {
        goldCount = goldvalue;
    }
}
