using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ratNav : NavMesh
{

    Animator rat;
    public GameObject thisRat;
    public float speed = 4;
    public int damage;
    public float minX, maxX, minZ, maxZ;
    protected override void Start()
    {
        base.Start();
        rat = thisRat.GetComponent<Animator>();
        GetComponent<NavMeshAgent>().speed = speed;
        minNavX = minX;
        maxNavX = maxX;
        minNavZ = minZ;
        maxNavZ = maxZ;
        RandomSite();
    }




    protected override void Update()
    {
        base.Update();
        if (thisRat != null)
        {

            if (playerDist < 1)
            {
                rat.SetBool("isAttacking", true);
            }
            else
            {
                rat.SetBool("isAttacking", false);
            }

            if (waitTime > 0 && Vector3.Distance(transform.position, patrolArea) < 1f)
            {
                StartIdling();
            }

        }
    }





    protected override void Patrol()
    {
        base.Patrol();
        if (thisRat != null)
        {
            //flip sprite anim based on position from location
            if (transform.position.x <= patrolArea.x)
            {
                rat.SetBool("isMoving", true);
                thisRat.GetComponent<SpriteRenderer>().flipX = true;
            }
            else if (transform.position.x >= patrolArea.x)
            {
                rat.SetBool("isMoving", true);
                thisRat.GetComponent<SpriteRenderer>().flipX = false;
            }
        }

    }


    protected override void SetDestination()
    {
        base.SetDestination();
        if (thisRat != null)
        {
            //flip sprite anim based on position from player
            if (transform.position.x <= targetVector.x)
            {
                rat.SetBool("isMoving", true);
                thisRat.GetComponent<SpriteRenderer>().flipX = true;
            }
            else if (transform.position.x >= targetVector.x)
            {
                rat.SetBool("isMoving", true);
                thisRat.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
    }

    protected override void StartIdling()
    {
        if (thisRat != null)
        {
            rat.SetBool("isMoving", false);
            rat.SetBool("isAttacking", false);
        }
    }


}
