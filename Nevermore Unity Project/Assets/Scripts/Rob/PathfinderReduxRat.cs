using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfinderReduxRat : MonoBehaviour {

    Animator ratAnim;


    public float waitTime, startWaitTime = 1;
    public int randomSpot;
    float playerDist, trackRange = 7.5f, attackRange = 1.5f;
    float speed = 2.5f;


    public Vector2 moveToSite, vanishPos, returnPos;
    GameObject player;

    public bool sightBreak, lost = true, colliding = false, canFollow = true;
    

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

        ratAnim = gameObject.GetComponent<Animator>();
        ratAnim.SetBool("isAttacking", false);
        //patrol zone based on min/max x,y locations
        //moveZone.Position = new Vector2(Random.range(minX, maxX), Random.Range(minY, maxY));
    }


    void Update () {
        

        isAttacking = false;
        

        if (player == null)
        {
            ratAnim.SetBool("isAttacking", false);
            player = GameObject.FindWithTag("Player");
        }

        print(waitTime);
        if (canFollow == false)
        {
            returnPos = moveSpots[randomSpot].position;
        }
        if (playerDist > attackRange && colliding == false && canFollow == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, moveToSite, speed * Time.deltaTime);
        }
        else if (colliding == true)
        {
            canFollow = false;
            transform.position = Vector2.MoveTowards(transform.position, returnPos, speed * Time.deltaTime);
            moveToSite = moveSpots[randomSpot].position;
            sightBreak = false;
            lost = true;
        }
        ratAnim.SetBool("isMoving", true);
        
        if (transform.position.x > moveToSite.x)
        {
            ratAnim.SetBool("isAttacking", false);
            ratAnim.SetBool("isMoving", true);
            GetComponent<SpriteRenderer>().flipX = false;

        }
        else if (transform.position.x < moveToSite.x)
        {
            ratAnim.SetBool("isAttacking", false);
            ratAnim.SetBool("isMoving", true);
            GetComponent<SpriteRenderer>().flipX = true;
        }
        

        if (playerDist <= attackRange)
        {
            ratAnim.SetBool("isMoving", false);
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
            colliding = false;
            canFollow = true;
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


    public void waitTimer()
    {
        print("hitting");
        if (waitTime <= 0)
        {
            //patrol zone based on min/max x,y locations
            //moveZone.Position = new Vector2(Random.range(minX, maxX), Random.Range(minY, maxY));

            //patrol between specific locations added by dev
            randomSpot = Random.Range(0, moveSpots.Length);
            waitTime = startWaitTime;
            canFollow = true;
            colliding = false;
        }
        else
        {
            ratAnim.SetBool("isMoving", false);
            waitTime -= Time.deltaTime;
        }
    }

    public void Attacking()
    {
        ratAnim.SetBool("isAttacking", true);
        isAttacking = true;
        //Debug.Log("attacking");
    }
}
