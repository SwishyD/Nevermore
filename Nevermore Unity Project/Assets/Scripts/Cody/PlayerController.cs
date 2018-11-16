using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //Movement
    private Vector3 lastMoveDir;

    //Dash
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;
    public float dashDistance;
    [SerializeField] private Transform portalIn;
    [SerializeField] private Transform portalOut;

    //Health
    public float health = 100;
    private float maxHealth = 100;
    public Color hurtColor;
    public Image healthBar;
    public Text hRatioText;
    public Color healthColor;

    //Stamina
    private float stamina = 100f;
    private float maxStamina = 100f;
    public Image staminaBar;
    public Text sRatioText;
    public Color stamColor;

    //Animation
    public Animator anim;

    void Start()
    {
        
    }

    void Update()
    {
        HandleStamina();
        HandleDash();
        HandleMovement();
        HandleHealth();        
    }


    void HandleMovement()
    {
        //these are for base movement
        float speed = 5f;
        float moveX = 0f;
        float moveY = 0f;

        //for animation
        anim.SetFloat("xInput", 0f);
        anim.SetFloat("yInput", 0f);
        anim.SetBool("isMoving", false);

        //Movement code
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("isMoving", true);
            anim.SetFloat("yInput", 1f);
            moveY = 1f;
                     
        }
        if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("isMoving", true);
            anim.SetFloat("yInput", -1f);
            moveY = -1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("isMoving", true);
            anim.SetFloat("xInput", -1f);
            moveX = -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isMoving", true);
            anim.SetFloat("xInput", 1f);
            moveX = 1f;
        }

        Vector3 moveDir = new Vector3(moveX, moveY).normalized;
        
        transform.position += moveDir * speed * Time.deltaTime;

        //can be improved
        if (moveX != 0 || moveY != 0)
        {
            lastMoveDir = moveDir;
        }
        
    }

    void HandleDash()
    {
        anim.SetBool("isDodging", false);

        if (Input.GetKeyDown(KeyCode.Space))
        {           
                if (stamina >= 25f)
                {
                    Vector3 beforeDashPos = transform.position;
                    anim.SetBool("isDodging", true);
                    Instantiate(portalIn, beforeDashPos, Quaternion.identity);
                    transform.position += lastMoveDir * dashDistance;
                    Instantiate(portalOut, transform.position , Quaternion.identity);
                    stamina -= 25f;
                }
                else
                {
                    StartCoroutine(stamFlash());
                }
        }
    }

    void HandleStamina()
    {
        //this is for the stamina bar
        float ratio = stamina / maxStamina;
        staminaBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
        sRatioText.text = (ratio * 100).ToString("0");

        //stamina management
        stamina += 10f * Time.deltaTime;
        if(stamina > maxStamina)
        {
            stamina = maxStamina;
        }
        if(stamina < 0f)
        {
            stamina = 0f;
        }
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
            Destroy(gameObject);
        }
        
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("PLAYER TAKES DAMAGE!!");
        health -= damage;
        StartCoroutine(hurtFlash());
    }

    //these control the flashing of sprites

    IEnumerator stamFlash()
    {
        staminaBar.GetComponent<Image>().color = stamColor;
        yield return new WaitForSeconds(0.1f);
        staminaBar.GetComponent<Image>().color = Color.green;
    }

    IEnumerator hurtFlash()
    {
        gameObject.GetComponent<SpriteRenderer>().color = hurtColor;
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
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
