using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrolTest : MonoBehaviour
{
    public Transform[] waypoints = new Transform[4];
    private int curPosition = 0;

    //int[] patrolPoint = new int[3];
    //public Transform[] waypoint = new Transform[4];

    void Start()
    {
        StartCoroutine("Patrol");
        //waypoint[1].position;
    }

    void Update()
    {
        //for (int i = 0; i < patrolPoint.Length; i++)
        //{
            //if (waypoint[i] == 1)
            //{
            //    GetComponent<Rigidbody2D>().velocity += new Vector2(2, 0);
            //}
            //else if (patrolPoint[i] == 1)
            //{
            //    GetComponent<Rigidbody2D>().velocity += new Vector2(0, 2);
            //}
            //else if (patrolPoint[i] == 2)
            //{
            //    GetComponent<Rigidbody2D>().velocity += new Vector2(-2, 0);
            //}
            //else if (patrolPoint[i] == 3)
            //{
            //    GetComponent<Rigidbody2D>().velocity += new Vector2(0, -2);
            //}
        //}
    }


    IEnumerator Patrol()
    {
        while (true) // Make an eternal loop in coroutine
        {
            
            if (curPosition >= waypoints.Length)
            {
                Move();
            }

        }

    }



    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "patrol")
        {
            curPosition++;
        }
    }

    void Move()
    {
        if (curPosition == 1 )
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(2, 0);
        }
        else if (curPosition == 2)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 2);
        }
        else if (curPosition == 3)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-2, 0);
        }
        else if (curPosition == 4)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -2);
        }
    }
}