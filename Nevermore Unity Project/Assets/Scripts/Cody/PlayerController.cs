using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    


    //these are for the dash
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;
    


    void Start()
    {
        
    }


    void Update()
    {
    //these are for base movement
        float speed = 5f;
        float moveX = 0f;
        float moveY = 0f;
        //Movement code
        if (Input.GetKey(KeyCode.W))
        {
            moveY = 1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveY = -1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveX = 1f;
        }

        Vector3 moveDir = new Vector3(moveX, moveY).normalized;

        transform.position += moveDir * speed * Time.deltaTime;

        //Dash code

    }

}
