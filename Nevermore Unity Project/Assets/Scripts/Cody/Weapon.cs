using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Weapon : MonoBehaviour {

    public float offset = 90f;
    //Attack types
    public GameObject melee;
    public GameObject fireBoltGreen;

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


    public Animator anim;
       	
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
        

        if (rotZ <= 150f &&  rotZ >= 20f)
        {
            anim.SetFloat("yMouse", 1);
            anim.SetFloat("xMouse", 0);
        }
        if (rotZ <= -50f && rotZ >= -120f)
        {
            anim.SetFloat("yMouse", -1);
            anim.SetFloat("xMouse", 0);
        }
        if (rotZ <= 19f && rotZ >= -50f)
        {
            anim.SetFloat("xMouse", 1);
            anim.SetFloat("yMouse", 0);
        }
        if ((rotZ <= 151f && rotZ >= 180f) || (rotZ <= -151f && rotZ >= -180f))
        {
            anim.SetFloat("xMouse", -1);
            anim.SetFloat("yMouse", 0);
           
        }

        if (timeBtwHits <= 0.5f)
        {

            if (Input.GetMouseButtonDown(0))
            {                              
                anim.SetBool("isAttacking", true);
                Instantiate(melee, shotPoint.position, transform.rotation);
                timeBtwHits = startTimeBtwHits;
            }
                    
        }       
        else
        {
            timeBtwHits -= Time.deltaTime;
        }

        if (timeBtwShots <= 0f)
        {
            if (Input.GetMouseButtonDown(1) && mana >= 20)
            {
                mana -= 20;
                anim.SetBool("isFbG", true);
                Instantiate(fireBoltGreen, shotPoint.position, transform.rotation);
                timeBtwShots = startTimeBtwShots;
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
