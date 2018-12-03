using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public bool upGrade = false;

    public int playerGold;
    public Text goldCount;
    public GameObject player;
    public Transform respawnPoint;
    public RuntimeAnimatorController redAnims;
    public Animator first;
    public Animator second;
    public bool isDying;

    //Health
    public int lives = 3;
    public float health = 100;
    private float maxHealth = 100;
    public Color hurtColor;
    public Image healthBar;
    public Color healthColor;
    public Text healthText;
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

        if(upGrade == true)
        {
            UpGrade();
        }
        HandleLives();
        HandleHealth();
        goldCount.text = playerGold.ToString();
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
        healthText.text = ratio*100 + "/" + maxHealth;
        healthBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
        if (health <= 25f)
        {
            StartCoroutine(lowHealthFlash());
        }
        if (health > maxHealth)
        {
            health = maxHealth;
        }
       
        

    }

    
    public void TakeDamage(int damage)
    {
        if (player.GetComponent<PlayerController>().isDashing == false && isDying == false)
        {
            health -= damage;
            StartCoroutine(hurtFlash());
            if (health <= 0)
            {
                isDying = true;
                player.GetComponent<Animator>().SetBool("isDead", true);
                player.GetComponent<PlayerController>().enabled = false;
                player.GetComponent<BoxCollider>().enabled = false;
                player.GetComponentInChildren<Weapon>().enabled = false;

                LoseLife();
            }
            
        }
    }

    private void LoseLife()
    {
        if(lives < 0)
        {
            Invoke("GameOver", 3);
        }

        isDying = true;
        lives --;
        health = maxHealth;
       
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
   

    public void UpGrade()
    {
        Debug.Log("UPGRADED");
        player.GetComponent<Animator>().runtimeAnimatorController = redAnims;
        player.GetComponentInChildren<Weapon>().isUpgraded = true;


    }
    public void Respawn()
    {
        player.GetComponent<Animator>().SetBool("isDead", false);
        player.transform.position = respawnPoint.position;
        player.GetComponent<PlayerController>().enabled = true;
        player.GetComponent<BoxCollider>().enabled = true;
        player.GetComponentInChildren<Weapon>().enabled = true;
        isDying = false;
        health = maxHealth;
    }
   

}
