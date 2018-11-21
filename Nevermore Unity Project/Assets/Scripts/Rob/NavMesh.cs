using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMesh : MonoBehaviour {

    [SerializeField]

    NavMeshAgent aiChar;


    public float minX, maxX, minZ, maxZ;
    float playerDist, maxRange = 6f;
    GameObject player;

    float waitTime, startWaitTime = 1;

    Vector3 patrolArea;

	// Use this for initialization
	void Start ()
    {
        aiChar = this.GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        RandomSite();
    }

    void Update()
    {
        //runs if player passes null. assigns player on respawn
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }

        playerDist = Vector3.Distance(gameObject.transform.position, player.transform.position);


        if (playerDist >= maxRange)
        {
            Patrol();

            if (Vector3.Distance(gameObject.transform.position, patrolArea) <= 1f)
            {
                StartWaitTimer();
            }
        }
        else
        {
            SetDestination();
        }


    }

    //patrol location based on values specified by dev
    void Patrol()
    {

        aiChar.SetDestination(patrolArea);
        
    }

    //tracks the player
    void SetDestination()
    {
        Vector3 targetVector = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        aiChar.SetDestination(targetVector);


    }

    //counts to 0, performs action and resets timer to 1
    void StartWaitTimer()
    {
        if (waitTime <= 0)
        {
            RandomSite();

            waitTime = startWaitTime;
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }

    void RandomSite()
    {
        print("hit");
        patrolArea = new Vector3(Random.Range(minX, maxX), transform.position.y, Random.Range(minZ, maxZ));
    }

}
