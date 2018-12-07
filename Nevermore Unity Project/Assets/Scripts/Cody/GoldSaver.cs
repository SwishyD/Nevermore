using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldSaver : MonoBehaviour {

    public int goldCount;

    public static GoldSaver instance = null;
    private static bool created = false;



   

    

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

    public void Update()
    {

        GameManager.instance.playerGold = goldCount;
    }

    public void GoldManage(int goldvalue)
    {
        goldCount = goldvalue;
    }
}
