using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoEHit : MonoBehaviour {

    //float lerpTime, frameCount = 0;
    //float startTime, endTime;
    //bool beginExpand;
    public int damage;

    private void Start()
    {
        resetSize();
        //endTime = 48f;
        //startTime = 0;
    }


    void enableHitBox()
    {
        GetComponent<CapsuleCollider>().enabled = true;
        //beginExpand = true;
    }

    void resetSize()
    {
        GetComponent<CapsuleCollider>().height = 1.68f;
        GetComponent<CapsuleCollider>().radius = 0.84f;
        GetComponent<CapsuleCollider>().direction = 0;
    }


    void disableHitBox()
    {
        //beginExpand = false;
        resetSize();
        GetComponent<CapsuleCollider>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            takeDamage(damage);

        }
        GetComponent<CapsuleCollider>().enabled = false;
    }

    void takeDamage(int damage)
    {
        GameManager.instance.TakeDamage(damage);
        GetComponent<CapsuleCollider>().enabled = false;
    }



    //void Update()
    //{
    //    print(endHeight);
    //    print(startHeight);
    //    //print(lerpTime);
    //    if (beginExpand == true)
    //    {
    //        if (frameCount < endTime)
    //        {
    //            frameCount++;
    //            expand();
    //        }
    //        else if (frameCount >= endTime)
    //        {
    //            frameCount = startTime;
    //        }

    //        lerpTime = Mathf.InverseLerp(startTime, endTime, frameCount);
    //        print(lerpTime);
    //    }
    //}


    //void expand()
    //{
    //    Mathf.Lerp(startHeight, endHeight, lerpTime);
    //    Mathf.Lerp(startRad, endRad, lerpTime);
    //    print("hit");

    //}
}
