using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfinderReduxMozzy : MonoBehaviour {

    Animator MozzyAnim;


    float waitTime, startWaitTime = 1;
    int randomSpot;
    public float playerDist, trackRange = 10, attackRange = 1;
    float speed = 2.3f;


    Vector2 moveToSite, vanishPos;
    GameObject player;

    public bool sightBreak, lost = true;
    

    //patrol between specific locations added by dev
    public Transform[] moveSpots;
    public int damage;
    public bool isAttacking = false;

    //patrol zone based on min/max x,y locations
    //public Transform moveZone;




    void Start () {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
        player = GameObject.FindWithTag("Player");

        MozzyAnim = gameObject.GetComponent<Animator>();

        //patrol zone based on min/max x,y locations
        //moveZone.Position = new Vector2(Random.range(minX, maxX), Random.Range(minY, maxY));
    }


    void Update () {
        

        isAttacking = false;

        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
        
        transform.position = Vector2.MoveTowards(transform.position, moveToSite, speed * Time.deltaTime);
        MozzyAnim.SetBool("isMoving", true);
        
        //thisAnim.SetBool("isAttacking", false);

        //setting collider false
        //GetComponentInChildren<BoxCollider2D>().enabled = false;

        if (transform.position.x > moveToSite.x)
        {
            //thisAnim.Play("Blender");

            MozzyAnim.SetBool("isAttacking", false);
            MozzyAnim.SetFloat("blendTree", 3);
            GetComponent<SpriteRenderer>().flipX = false;

        }
        else if (transform.position.x < moveToSite.x)
        {
            MozzyAnim.SetBool("isAttacking", false);
            MozzyAnim.SetFloat("blendTree", 3);
            GetComponent<SpriteRenderer>().flipX = true;
        }


        if (playerDist <= attackRange)
        {
            MozzyAnim.SetBool("isMoving", false);
            Invoke("Attacking", 01f);
        }
        



        playerDist = Vector2.Distance(transform.position, player.transform.position);

        //if enemy is within .5 units of distance from the randomly selected location, wait 1 second, then move to the next randomly selected location
        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.5f)
        {
            waitTimer();
        }


        //Track the player if the player is in range of the enemy
        if (playerDist <= trackRange)
        {
            sightBreak = false;
            lost = false;
            moveToSite = player.transform.position;
            
        }

        //On exit of trigger zone, enemy moves to the last known location of the player
        else if (playerDist > trackRange && sightBreak == true)
        {
            moveToSite = vanishPos;
            if (Vector2.Distance(transform.position, vanishPos) < 0.5f)
            {
                waitTimer();
                if (waitTime <= 0)
                {
                    sightBreak = false;
                    lost = true;
                    waitTime = startWaitTime;
                }
            }
        }
        
        //Return to patrol if player is not in range of the enemy
        else if (playerDist > trackRange && lost == true)
        {
            moveToSite = moveSpots[randomSpot].position;
        }
        else if (playerDist <= attackRange)
        {

        }

	}


    //if the player exits the range of the enemy, set the VanishPos to 
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            vanishPos = player.transform.position;
            sightBreak = true;
        }
    }


    void waitTimer()
    {
        if (waitTime <= 0)
        {
            //patrol zone based on min/max x,y locations
            //moveZone.Position = new Vector2(Random.range(minX, maxX), Random.Range(minY, maxY));

            //patrol between specific locations added by dev
            randomSpot = Random.Range(0, moveSpots.Length);

            waitTime = startWaitTime;
        }
        else
        {

            MozzyAnim.SetBool("isMoving", false);
            waitTime -= Time.deltaTime;
        }
    }

    public void Attacking()
    {
        MozzyAnim.SetBool("isAttacking", true);
        isAttacking = true;
        Debug.Log("attacking");
    }
}
