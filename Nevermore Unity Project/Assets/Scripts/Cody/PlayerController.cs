using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //Movement
    private Vector3 lastMoveDir;

    //Dash
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;
    public float dashDistance;
    


    void Start()
    {
        
    }

    void Update()
    {
        HandleDash();
        HandleMovement();
    }


    void HandleMovement()
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
        lastMoveDir = moveDir;
        transform.position += moveDir * speed * Time.deltaTime;
    }

    void HandleDash()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position += lastMoveDir * dashDistance;
        }
    }

}
