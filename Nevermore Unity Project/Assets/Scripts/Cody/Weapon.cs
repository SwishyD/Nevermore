﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Weapon : MonoBehaviour {

    public float offset = 90f;
    //Attack types
    public bool isUpgraded = false;
    public GameObject meleeGreen;
    public GameObject meleeRed;
    public GameObject fireBoltGreen;
    public GameObject fireBoltRed;

    //Mana
    public float mana = 100;
    private float maxMana = 100;
    public Image manaBar;
    public Color manaColor;

    public Transform shotPoint;

    private float timeBtwShots;
    public float startTimeBtwShots;

    private float timeBtwHits;
    public float startTimeBtwHits;

    private AudioSource mySound;
    public AudioClip meleeSound;
    public AudioClip fbSound;


    public Animator anim;

    private void Awake()
    {
        mySound = gameObject.GetComponent<AudioSource>();

    }
    // Update is called once per frame
    void Update ()
    {
        mana += Time.deltaTime;
        HandleMana();

        anim.SetBool("isAttacking", false);
        anim.SetBool("isFbG", false);

        // Handles the Weapon Rotation
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.z, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(90f, 0f, rotZ + offset);
        

        if (rotZ <= 135f &&  rotZ >= 45f)
        {
            anim.SetFloat("yMouse", 1);
            anim.SetFloat("xMouse", 0);
        }
        if (rotZ <= -45f && rotZ >= -135f)
        {
            anim.SetFloat("yMouse", -1);
            anim.SetFloat("xMouse", 0);
        }
        if (rotZ <= 44f && rotZ >= -44f)
        {
            anim.SetFloat("xMouse", 1);
            anim.SetFloat("yMouse", 0);
        }
        if ((rotZ <= 136f && rotZ >= 180f) || (rotZ <= -136f && rotZ >= -180f))
        {
            anim.SetFloat("xMouse", -1);
            anim.SetFloat("yMouse", 0);
           
        }

        if (timeBtwHits <= 0.5f)
        {

            if (Input.GetMouseButtonDown(0))
            {                              
                anim.SetBool("isAttacking", true);
                if (!isUpgraded)
                {
                    Instantiate(meleeGreen, shotPoint.position, transform.rotation);
                }
                else if (isUpgraded)
                {
                    Instantiate(meleeRed, shotPoint.position, transform.rotation);
                }
                timeBtwHits = startTimeBtwHits;
                mySound.PlayOneShot(meleeSound);
            }
                    
        }       
        else
        {
            timeBtwHits -= Time.deltaTime;
        }

        if (timeBtwShots <= 0.5f)
        {
            if (Input.GetMouseButtonDown(1) && mana >= 20)
            {
                mana -= 20;
                anim.SetBool("isFbG", true);
                if (!isUpgraded)
                {
                    Instantiate(fireBoltGreen, shotPoint.position, transform.rotation);
                }
                else if (isUpgraded)
                {
                    Instantiate(fireBoltRed, shotPoint.position, transform.rotation);
                }
                timeBtwShots = startTimeBtwShots;
                mySound.PlayOneShot(fbSound);
            }

            else if (Input.GetMouseButtonDown(1) && mana < 20)
            {
                StartCoroutine(manaFlash());
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    void HandleMana()
    {
        //this is for the mana bar
        float ratio = mana / maxMana;
        manaBar.fillAmount = ratio;
       
        //mana management
        mana += 10f * Time.deltaTime;
        if (mana > maxMana)
        {
            mana = maxMana;
        }
        if (mana < 0f)
        {
            mana = 0f;
        }
    }

    IEnumerator manaFlash()
    {
        manaBar.GetComponent<Image>().color = manaColor;
        yield return new WaitForSeconds(0.1f);
        manaBar.GetComponent<Image>().color = Color.white;
    }
}
