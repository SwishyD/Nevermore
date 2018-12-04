using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VillNav : NavMesh
{

    Animator vill;
    public GameObject thisVill;
    float speed = 7f;
    public int damage;
    public float minX, maxX, minZ, maxZ;
    Vector3 curPos;
    float length;

    protected override void Start()
    {
        base.Start();
        vill = thisVill.GetComponent<Animator>();
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
        if (thisVill != null)
        {

            if (playerDist < 1)
            {
                vill.SetBool("isAttacking", true);
            }
            else if (thisVill.GetComponent<beginMove>().attacking == false)
            {
                vill.SetBool("isAttacking", false);
            }
            
            if (vill.GetBool("isAttacking") == true)
            {
                aiChar.SetDestination(curPos);
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

        curPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

    }





    protected override void Patrol()
    {
        base.Patrol();
        if (thisVill != null)
        {
            //flip sprite anim based on position from location
            if (transform.position.x <= patrolArea.x)
            {
                vill.SetBool("isMoving", true);
                thisVill.GetComponent<SpriteRenderer>().flipX = true;
            }
            else if (transform.position.x >= patrolArea.x)
            {
                vill.SetBool("isMoving", true);
                thisVill.GetComponent<SpriteRenderer>().flipX = false;
            }
        }

    }


    protected override void SetDestination()
    {
        base.SetDestination();
        if (thisVill != null)
        {
            //flip sprite anim based on position from player
            if (transform.position.x <= targetVector.x)
            {
                vill.SetBool("isMoving", true);
                thisVill.GetComponent<SpriteRenderer>().flipX = true;
            }
            else if (transform.position.x >= targetVector.x)
            {
                vill.SetBool("isMoving", true);
                thisVill.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
    }

    protected override void StartIdling()
    {
        if (thisVill != null)
        {
            vill.SetBool("isMoving", false);
            vill.SetBool("isAttacking", false);
        }
    }



}
