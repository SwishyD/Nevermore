using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VillNav : NavMesh
{
    AudioSource mySound;
    public AudioClip deathSound;

    Animator vill;
    public GameObject thisVill;
    float speed = 7f;
    public int damage;
    public float minX, maxX, minZ, maxZ;
    float length;


    private void Awake()
    {
        mySound = gameObject.GetComponent<AudioSource>();
    }

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

        curHealth = thisVill.GetComponent<EnemyHealthSystem>().health;

        curHealth = thisVill.GetComponent<EnemyHealthSystem>().health;
        if (curHealth <= 0)
        {
            mySound.PlayOneShot(deathSound);
            vill.SetBool("isDead", true);
            vill.SetBool("isMoving", false);
            vill.SetBool("isAttacking", false);
            thisVill.GetComponent<SpriteRenderer>().sortingOrder = 3;
            Destroy(thisVill.GetComponent<posLock>());
            Destroy(thisVill.GetComponentInChildren<BoxCollider>());
            Destroy(gameObject);
        }
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
        base.StartIdling();
        if (thisVill != null)
        {
            vill.SetBool("isMoving", false);
            vill.SetBool("isAttacking", false);
        }
    }

    protected override void OnCollisionStay(Collision col)
    {
        base.OnCollisionStay(col);
    }

}
