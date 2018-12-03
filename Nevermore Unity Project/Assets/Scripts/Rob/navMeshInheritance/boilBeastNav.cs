using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class boilBeastNav : NavMesh
{

    Animator bb;
    public GameObject thisbb;
    float speed = 4.6f;
    public int damage;
    public float minX, maxX, minZ, maxZ;
    protected override void Start()
    {
        base.Start();
        bb = thisbb.GetComponent<Animator>();
        GetComponent<NavMeshAgent>().speed = speed;
        minNavX = minX;
        maxNavX = maxX;
        minNavZ = minZ;
        maxNavZ = maxZ;
        RandomSite();
    }




    protected override void Update()
    {
        print(patrolArea);
        base.Update();
        if (thisbb != null)
        {

            if (playerDist < 1)
            {
                bb.SetBool("isAttacking", true);
            }
            else
            {
                bb.SetBool("isAttacking", false);
            }

            if (waitTime > 0 && Vector3.Distance(transform.position, patrolArea) < 1f)
            {
                StartIdling();
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }





    protected override void Patrol()
    {
        base.Patrol();
        if (thisbb != null)
        {
            //flip sprite anim based on position from location
            if (transform.position.x <= patrolArea.x)
            {
                bb.SetBool("isMoving", true);
                thisbb.GetComponent<SpriteRenderer>().flipX = true;
            }
            else if (transform.position.x >= patrolArea.x)
            {
                bb.SetBool("isMoving", true);
                thisbb.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        else
        {
            Destroy(gameObject);
        }

    }


    protected override void SetDestination()
    {
        base.SetDestination();
        if (thisbb != null)
        {
            //flip sprite anim based on position from player
            if (transform.position.x <= targetVector.x)
            {
                bb.SetBool("isMoving", true);
                thisbb.GetComponent<SpriteRenderer>().flipX = true;
            }
            else if (transform.position.x >= targetVector.x)
            {
                bb.SetBool("isMoving", true);
                thisbb.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
    }

    protected override void StartIdling()
    {
        if (thisbb != null)
        {
            bb.SetBool("isMoving", false);
            bb.SetBool("isAttacking", false);
        }
    }


    float attackWait, startAttackWait = 3;

    void attackTimer()
    {
        if (attackWait <= 0)
        {
            attackPlayer();

            attackWait = startAttackWait;
        }
        else
        {
            attackWait -= Time.deltaTime;
        }
    }

    void attackPlayer()
    {
        bb.SetBool("isAttacking", true);
    }
}

