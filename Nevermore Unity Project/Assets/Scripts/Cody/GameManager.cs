using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public int playerGold;
    public GameObject player;
    
    //Health
    public float health = 100;
    private float maxHealth = 100;
    public Color hurtColor;
    public Image healthBar;
    public Text hRatioText;
    public Color healthColor;

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
        hRatioText.text = (ratio * 100).ToString("0");
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
            Invoke("GameOver", 3);
        }

    }

    public void TakeDamage(int damage)
    {
        Debug.Log("PLAYER TAKES DAMAGE!!");
        health -= damage;
        StartCoroutine(hurtFlash());
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
