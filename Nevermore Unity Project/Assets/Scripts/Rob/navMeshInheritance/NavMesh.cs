using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMesh : MonoBehaviour {

    [SerializeField]

    protected NavMeshAgent aiChar;


    protected float minNavX, maxNavX, minNavZ, maxNavZ;
    protected float playerDist, maxRange = 6f;
    protected GameObject player;

    protected float waitTime, startWaitTime = 2;

    protected Vector3 patrolArea, targetVector;

    // Use this for initialization
    protected virtual void Start ()
    {
        aiChar = this.GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        waitTime = startWaitTime;
        Invoke("AssignRadius", 1);
    }

    protected virtual void Update()
    {
        
        //runs if player passes null. assigns player on respawn
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }

        playerDist = Vector3.Distance(gameObject.transform.position, player.transform.position);


        //if (playerDist >= maxRange)
        //{
        //    Patrol();

        //}
        //else
        //{
        //    SetDestination();
        //}


    }

    //patrol location based on values specified by dev
    protected virtual void Patrol()
    {

        aiChar.SetDestination(patrolArea);
        if (Vector3.Distance(gameObject.transform.position, patrolArea) <= 1f)
        {
            StartWaitTimer();
        }
    }

    //tracks the player
    protected virtual void SetDestination()
    {
        targetVector = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        aiChar.SetDestination(targetVector);


    }

    //counts to 0, performs action and resets timer to 1
    protected virtual void StartWaitTimer()
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

    protected virtual void RandomSite()
    {
        patrolArea = new Vector3(Random.Range(minNavX, maxNavX), 5.97f, Random.Range(minNavZ, maxNavZ));
    }
    
    protected virtual void StartIdling()
    {

    }

    protected virtual void AssignRadius()
    {
        GetComponent<NavMeshAgent>().radius = 0.21f;
    }

    protected virtual void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Obstacle" && Vector3.Distance(transform.position, patrolArea) <= 4)
        {
            waitTime = startWaitTime;
            StartWaitTimer();
        }
    }
}
