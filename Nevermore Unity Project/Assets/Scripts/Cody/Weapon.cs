using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Weapon : MonoBehaviour {

    public float offset = 90f;

    public GameObject projectile;
    public Transform shotPoint;

    private float timeBtwShots;
    public float startTimeBtwShots;

   
    public Animator anim;

    // Use this for initialization
    void Start () {
        ;
	}
	
	// Update is called once per frame
	void Update ()
    {
        anim.SetBool("isAttacking", false);
       

        // Handles the Weapon Rotation
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        Debug.Log(rotZ);

        if (rotZ <= 89f && rotZ >= -89f)
        {
            anim.SetFloat("xMouse", 1);
        }
        else if (rotZ >= 90f || rotZ <= -90f  )
        {
            anim.SetFloat("xMouse", -1);
        }

        if (timeBtwShots <= 0)
        {

            if (Input.GetMouseButtonDown(0))
            {
               
                
                anim.SetBool("isAttacking", true);
                Instantiate(projectile, shotPoint.position, transform.rotation);
                timeBtwShots = startTimeBtwShots;
            }
            
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

       
    }
}
