using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public int playerHealth;
    public int playerGold;
    public GameObject player;
    public Color hurtColor;

    


	// Use this for initialization
	void Start () {
		
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
