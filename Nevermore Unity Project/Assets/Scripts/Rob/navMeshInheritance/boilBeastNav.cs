using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class boilBeastNav : NavMesh
{
    AudioSource mySound;
    public AudioClip deathSound;
   

    Animator bb;
    public GameObject thisbb;
    float speed = 1.5f;
    public int damage;
    public float minX, maxX, minZ, maxZ;

    private void Awake()
    {
        mySound = gameObject.GetComponent<AudioSource>();
    }

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

        base.Update();
        if (thisbb != null)
        {
            if (playerDist < 2.5f)
            {
                thisbb.GetComponent<beginMove>().attacking = true;
                bb.SetBool("isAttacking", true);
            }
            else if(thisbb.GetComponent<beginMove>().attacking == false)
            {
                bb.SetBool("isAttacking", false);
            }

            if (bb.GetBool("isAttacking") == true)
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

        curHealth = thisbb.GetComponent<EnemyHealthSystem>().health;
        curHealth = thisbb.GetComponent<EnemyHealthSystem>().health;
        if (curHealth <= 0)
        {
            mySound.PlayOneShot(deathSound);
            bb.SetBool("isDead", true);
            bb.SetBool("isMoving", false);
            bb.SetBool("isAttacking", false);
            thisbb.GetComponent<SpriteRenderer>().sortingOrder = 3;
            Destroy(thisbb.GetComponent<posLock>());
            Destroy(thisbb.GetComponentInChildren<BoxCollider>());
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
        base.StartIdling();
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

    protected override void OnCollisionStay(Collision col)
    {
        base.OnCollisionStay(col);
    }
}

