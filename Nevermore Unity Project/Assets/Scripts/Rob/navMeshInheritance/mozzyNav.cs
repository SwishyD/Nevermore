﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class mozzyNav : NavMesh {

    Animator mozzy;
    public GameObject thisMozzy;
    public float speed = 3;
    public int damage;
    public float minX, maxX, minZ, maxZ;
    protected override void Start()
    {
        base.Start();
        mozzy = thisMozzy.GetComponent<Animator>();
        minNavX = minX;
        maxNavX = maxX;
        minNavZ = minZ;
        maxNavZ = maxZ;
        RandomSite();
    }




    protected override void Update()
    {
        base.Update();
        if (thisMozzy != null)
        {
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
        if (thisMozzy != null)
        {
            mozzy.SetBool("isMoving", false);
            mozzy.SetBool("isAttacking", false);
        }
    }


}
