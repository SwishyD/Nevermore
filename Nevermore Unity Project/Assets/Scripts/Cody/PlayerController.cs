﻿using System.Collections;
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

    //Stamina
    private float stamina = 100f;
    private float maxStamina = 100f;
    public Image staminaBar;
    public Text sRatioText;
    public Color hurtColor;

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
                    anim.SetBool("isDodging", true);
                    transform.position += lastMoveDir * dashDistance;
                    stamina -= 25f;
                }
                else
                {
                    StartCoroutine(Flash());
                    //flash stamina bar red here
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

    IEnumerator Flash()
    {
        staminaBar.GetComponent<Image>().color = hurtColor;
        yield return new WaitForSeconds(0.1f);
        staminaBar.GetComponent<Image>().color = Color.green;
    }

}
