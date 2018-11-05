using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicPathfinding : MonoBehaviour
{

    //Basic AI
    GameObject player;
    float distFromTarget, range = 20;
    Vector2 patrolCheck;
    Vector2 VanishPos;
    public bool sightBreak, lost, tracking = false;
    float timer = 0;
    Transform playerPos;

    //floats relating to speed, acceleration of ai
    float speed = 0, moveSpeed = .5f, Acceleration, maxSpeed = 5, speedUp = .5f;
    

    public Vector2 wander;

    
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerPos = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
        Acceleration = speedUp * timer;
        speed = moveSpeed + Acceleration;
        if (speed >= maxSpeed)
        {
            speed = maxSpeed;
        }
        

        //Setting up player and checking distance between player and AI
        if (player != null)
        {
            distFromTarget = Vector2.Distance(new Vector2(transform.position.x, transform.position.y), new Vector2(player.transform.position.x, player.transform.position.y));
        }

        //wandering/patroling
        if (tracking == false)
        {
            Idlewander();
        }
        if (transform.position.x >= wander.x - 1 && transform.position.x <= wander.x + 1 && transform.position.y >= wander.y - 1 && transform.position.y <= wander.y + 1 && tracking == false)
        {
            wander = new Vector2(Random.Range(-30, 30), Random.Range(-30, 30));
            Invoke("Idlewander", 1);
        }


        //if the player is within range, begin tracking
        if (distFromTarget < range)
        {
            tracking = true;
            sightBreak = false;
            lost = false;
            TrackPlayer();
        }

        if (sightBreak == true)
        {
            tracking = false;
            Search();
        }

        if (lost == true)
        {
            Invoke("Idlewander", 3);
        }




        
        print(sightBreak);


    }




    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            timer = timer + (1 * Time.deltaTime);
            sightBreak = false;
        }
    }

    //begin timer for multiplying speed
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            timer = timer + (1 * Time.deltaTime);
            if (timer >= 10)
            {
                timer = 10;
            }
        }

    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            VanishPos = new Vector2(player.transform.position.x, player.transform.position.y);
            sightBreak = true;
            print(collision);
        }
    }




    //Movement States
    void Idlewander()
    {
        if (distFromTarget > range)
        {
            Vector2 wandering = new Vector2((transform.position.x - wander.x) * speed, (transform.position.y - wander.y) * speed);
            GetComponent<Rigidbody2D>().velocity = -wandering;
            timer = 0;
        }
    }

    void TrackPlayer()
    {
        Vector2 tracking = new Vector2((transform.position.x - playerPos.position.x) * speed,   (transform.position.y - playerPos.position.y) * speed);
        GetComponent<Rigidbody2D>().velocity = -tracking;

    }

    void Search()
    {
        Vector2 searching = new Vector2((transform.position.x - VanishPos.x) * speed, (transform.position.y - VanishPos.y) * speed);
        GetComponent<Rigidbody2D>().velocity = -searching;

        if(transform.position.x <= VanishPos.x + 1 && transform.position.x >= VanishPos.x - 1 && transform.position.y <= VanishPos.y + 1 && transform.position.y >= VanishPos.y - 1)
        {
            sightBreak = false;
            lost = true;
            tracking = false;
        }
        
    }


}

