using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public int playerGold;
    public GameObject player;
    public Transform respawnPoint;

    //Health
    public int lives = 3;
    public float health = 100;
    private float maxHealth = 100;
    public Color hurtColor;
    public Image healthBar;
    public Color healthColor;
    public GameObject livesCount;
    public Sprite three;
    public Sprite two;
    public Sprite one;
    public Sprite zero;

    private static bool created = false;
    public static GameManager instance = null;

    void Awake()
    {
        if (!created)
        {
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
        HandleLives();
        HandleHealth();
        
		if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
	}

    public void AddGold(int goldValue)
    {
        playerGold += goldValue;
    }

    public void RemoveGold(int goldValue)
    {
        playerGold -= goldValue;
    }

    void HandleHealth()
    {
        //this is for the health bar
        float ratio = health / maxHealth;
        healthBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
        if (health <= 25f)
        {
            StartCoroutine(lowHealthFlash());
        }
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        if (health <= 0)
        {
            LoseLife();
        }
        

    }

    
    public void TakeDamage(int damage)
    {
        health -= damage;
        StartCoroutine(hurtFlash());
    }

    private void LoseLife()
    {
        if(lives < 0)
        {
            Invoke("GameOver", 3);
        }
        health = maxHealth;
        lives --;
        player.transform.position = respawnPoint.position;
    }
    void HandleLives()
    {

        var  counter = livesCount.GetComponent<Image>();
        if (lives == 3)
        {
            counter.sprite = three;
        }
        if (lives == 2)
        {
            counter.sprite = two;
        }
        if (lives == 1)
        {
           counter.sprite = one;
        }
        if (lives == 0)
        {
            counter.sprite = zero;
        }
    }

    private void GameOver()
    {
        SceneManager.LoadScene(0);
    }

    //these control the flashing of sprites

    IEnumerator hurtFlash()
    {
        player.GetComponent<SpriteRenderer>().color = hurtColor;
        yield return new WaitForSeconds(0.1f);
        player.GetComponent<SpriteRenderer>().color = Color.white;
    }

    IEnumerator lowHealthFlash()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.3f);
            healthBar.GetComponent<Image>().color = healthColor;
            yield return new WaitForSeconds(0.3f);
            healthBar.GetComponent<Image>().color = Color.red;
        }

    }

   

}
