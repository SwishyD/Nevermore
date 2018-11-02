using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicPathfinding : MonoBehaviour
{

    //Basic AI
    public GameObject player;
    float distFromTarget, range = 15, moveSpeed = 2;
    Vector2 SpawnPos;
    Vector2 VanishPos;
    bool sightBreak = false;

    //Lerping
    Transform playerPos;
    float smoothSpeed = 0.125f;
    Vector3 offset;


    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        SpawnPos = new Vector2(transform.position.x, transform.position.y);
        playerPos = player.transform;
    }

    // Update is called once per frame
    void Update()
    {


        Vector2 desiredPosition = playerPos.position + offset;
        Vector2 smoothedPosition = Vector2.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        print(VanishPos);

        //Setting up player and checking distance between player and AI
        if (player != null)
        {
            distFromTarget = Vector2.Distance(new Vector2(transform.position.x, transform.position.y), new Vector2(player.transform.position.x, player.transform.position.y));
        }

        //if the player is within range, begin tracking
        if (distFromTarget < range)
        {
            Invoke("TrackPlayer", 0.5f);
        }
        else if (distFromTarget > range)
        {
            sightBreak = true;
            Home();
        }

        if (sightBreak == true)
        {
            sightBreak = false;
            VanishPos = new Vector2(player.transform.position.x, player.transform.position.y);
        }


    }





    void TrackPlayer()
    {
        Vector2 tracking = new Vector2((transform.position.x - VanishPos.x) * moveSpeed, (transform.position.y - VanishPos.y) * moveSpeed);
        GetComponent<Rigidbody2D>().velocity = -tracking;

    }

    void Home()
    {
        Vector2 searching = new Vector2((transform.position.x - VanishPos.x) * moveSpeed, (transform.position.y - VanishPos.y) * moveSpeed);
        GetComponent<Rigidbody2D>().velocity = -searching;

        Vector2 returning = new Vector2((transform.position.x - SpawnPos.x) * moveSpeed, (transform.position.y - SpawnPos.y) * moveSpeed);
        GetComponent<Rigidbody2D>().velocity = -returning;

        //Vector2.Lerp(transform.position, playerPos, );
    }
}

