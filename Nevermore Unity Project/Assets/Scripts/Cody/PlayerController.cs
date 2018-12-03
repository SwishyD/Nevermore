using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class PlayerController : MonoBehaviour
{
    public Vector3 currentCP;

    //Movement
    private Vector3 lastMoveDir;

    //Dash
    public bool isDashing = false;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;
    public float dashDistance;
    [SerializeField] private Transform dashEffect;
    public float animNum;
   
    //Stamina
    private float stamina = 100f;
    private float maxStamina = 100f;
    public Image staminaBar;
    public Color stamColor;

    //Animation
    public Animator anim;

    void Update()
    {

        HandleStamina();
        HandleDash();
        HandleMovement();              
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
            animNum = 1;
            moveY = 1f;
                     
        }
        if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("isMoving", true);
            anim.SetFloat("yInput", -1f);
            animNum = 2;
            moveY = -1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("isMoving", true);
            anim.SetFloat("xInput", -1f);
            animNum = 3;
            moveX = -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isMoving", true);
            anim.SetFloat("xInput", 1f);
            animNum = 4;
            moveX = 1f;
        }

        Vector3 moveDir = new Vector3(moveX, 0, moveY).normalized;
        
        transform.position += moveDir * speed * Time.deltaTime;

        //can be improved
        if (moveX != 0 || moveY != 0)
        {
            lastMoveDir = moveDir;
        }
        
    }

    void HandleDash()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {           
                if (stamina >= 25f)
                {
                StartCoroutine(dashIFrames());
                Vector3 beforeDashPos = transform.position;
                Transform dashEffectTransform = Instantiate(dashEffect, beforeDashPos, Quaternion.identity);
                dashEffect.GetComponent<DashDestroy>().HandleAnim(animNum);
                dashEffectTransform.eulerAngles = new Vector3(90, 0, UtilsClass.GetAngleFromVectorFloat(lastMoveDir));
                transform.position += lastMoveDir * dashDistance;
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
        staminaBar.fillAmount = ratio;
        

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

    IEnumerator dashIFrames()
    {
        isDashing = true;
        yield return new WaitForSeconds(1.5f);
        isDashing = false;

    }
   
    //these control the flashing of sprites

    IEnumerator stamFlash()
    {
        staminaBar.GetComponent<Image>().color = stamColor;
        yield return new WaitForSeconds(0.1f);
        staminaBar.GetComponent<Image>().color = Color.white;
    }

 
}
