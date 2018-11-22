using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class mozzyNav : NavMesh {

    Animator mozzy;
    public GameObject thisMozzy;
    public float speed = 3;
    public int damage;
    public new float minX, maxX, minZ, maxZ;
    protected override void Start()
    {
        base.Start();
        mozzy = thisMozzy.GetComponent<Animator>();
        minX = -6.35f;
        maxX = 25.1f;
        minZ = -20.4f;
        maxZ = -13.3f;
        RandomSite();
    }




    protected override void Update()
    {
        base.Update();

        //TEMP MOVE TO START WHEN SORTED
        GetComponent<NavMeshAgent>().speed = speed;


        if (playerDist < 1)
        {
            mozzy.SetBool("isAttacking", true);
        }
        else
        {
            mozzy.SetBool("isAttacking", false);
        }

        if (waitTime > 0 && Vector3.Distance(transform.position, patrolArea) < 1f)
        {
            StartIdling();
        }
        
    }





    protected override void Patrol()
    {
        base.Patrol();
        
        //flip sprite anim based on position from location
        if (transform.position.x <= patrolArea.x )
        {
            mozzy.SetBool("isMoving", true);
            thisMozzy.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (transform.position.x >= patrolArea.x)
        {
            mozzy.SetBool("isMoving", true);
            thisMozzy.GetComponent<SpriteRenderer>().flipX = false;
        }


    }


    protected override void SetDestination()
    {
        base.SetDestination();

        //flip sprite anim based on position from player
        if (transform.position.x <= targetVector.x)
        {
            mozzy.SetBool("isMoving", true);
            thisMozzy.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (transform.position.x >= targetVector.x)
        {
            mozzy.SetBool("isMoving", true);
            thisMozzy.GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    protected override void StartIdling()
    {
        mozzy.SetBool("isMoving", false);
        mozzy.SetBool("isAttacking", false);
    }


}
