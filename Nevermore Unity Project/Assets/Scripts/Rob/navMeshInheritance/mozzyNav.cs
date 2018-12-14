using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class mozzyNav : NavMesh {

    Animator mozzy;
    public GameObject thisMozzy;
    float speed = 6;
    public int damage = 10;
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;

    AudioSource mySound;
    public AudioClip deathSound;

    private void Awake()
    {
        mySound = gameObject.GetComponent<AudioSource>();
    }

    protected override void Start()
    {
        base.Start();
        mozzy = thisMozzy.GetComponent<Animator>();
        minNavX = minX;
        maxNavX = maxX;
        minNavZ = minZ;
        maxNavZ = maxZ;
        RandomSite();
        GetComponent<NavMeshAgent>().speed = speed;
    }




    protected override void Update()
    {
        base.Update();
        if (thisMozzy != null)
        {


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

        curHealth = thisMozzy.GetComponent<EnemyHealthSystem>().health;
        if (curHealth <= 0)
        {
            mySound.PlayOneShot(deathSound);
            mozzy.SetBool("isDead", true);
            mozzy.SetBool("isMoving", false);
            mozzy.SetBool("isAttacking", false);
            thisMozzy.GetComponent<SpriteRenderer>().sortingOrder = 3;
            Destroy(thisMozzy.GetComponent<posLock>());
            Destroy(thisMozzy.GetComponentInChildren<BoxCollider>());
            Destroy(gameObject);
        }
    }


    protected override void RandomSite()
    {
        base.RandomSite();
    }


    protected override void Patrol()
    {
        base.Patrol();
        if (thisMozzy != null)
        {
            //flip sprite anim based on position from location
            if (transform.position.x <= patrolArea.x)
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

    }


    protected override void SetDestination()
    {
        base.SetDestination();
        if (thisMozzy != null)
        {
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
    }

    protected override void StartIdling()
    {
        base.StartIdling();
        if (thisMozzy != null)
        {
            mozzy.SetBool("isMoving", false);
            mozzy.SetBool("isAttacking", false);
        }
    }

    protected override void OnCollisionStay(Collision col)
    {
        base.OnCollisionStay(col);
    }


}
