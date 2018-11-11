using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public int playerHealth;
    public int playerGold;
    public GameObject player;
    public Color hurtColor;

    private static bool created = false;
    public static GameManager instance = null;

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

    // Update is called once per frame
    void Update () {
		
	}

    public void AddGold(int goldValue)
    {
        playerGold += goldValue;
    }

    public void RemoveGold(int goldValue)
    {
        playerGold -= goldValue;
    }

    public void TakeDamage(int damage)
    {
        playerHealth -= damage;
        StartCoroutine(Flash());
    }

    IEnumerator Flash()
    {
        player.GetComponent<SpriteRenderer>().color = hurtColor;
        yield return new WaitForSeconds(0.1f);
        player.GetComponent<SpriteRenderer>().color = Color.white;        
    }

}
