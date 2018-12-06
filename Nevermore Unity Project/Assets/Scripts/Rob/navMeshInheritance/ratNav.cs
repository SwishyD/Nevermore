using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ratNav : NavMesh
{
    AudioSource mySound;
    public AudioClip deathSound;

    Animator rat;
    public GameObject thisRat;
    float speed = 4.6f;
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
            else if(thisRat.GetComponent<beginMove>().attacking == false)
            {
                rat.SetBool("isAttacking", false);
            }
            
            if (rat.GetBool("isAttacking") == true)
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

        curHealth = thisRat.GetComponent<EnemyHealthSystem>().health;
        if (curHealth <= 0)
        {
            mySound.PlayOneShot(deathSound);
            rat.SetBool("isDead", true);
            rat.SetBool("isMoving", false);
            rat.SetBool("isAttacking", false);
            thisRat.GetComponent<SpriteRenderer>().sortingOrder = 3;
            Destroy(thisRat.GetComponent<posLock>());
            Destroy(thisRat.GetComponentInChildren<BoxCollider>());
            Destroy(gameObject);
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
        base.StartIdling();
        if (thisRat != null)
        {
            rat.SetBool("isMoving", false);
            rat.SetBool("isAttacking", false);
        }
    }

    protected override void OnCollisionStay(Collision col)
    {
        base.OnCollisionStay(col);
    }



}
