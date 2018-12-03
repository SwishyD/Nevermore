using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoEHit : MonoBehaviour {

    float frameCount = 0;
    float startPos = -1.03f, endPos = -1.35f;
    bool beginExpand;

    private void Start()
    {
        resetSize();
        GetComponent<CapsuleCollider>().enabled = false;
    }

    void Update()
    {
        print(frameCount);
        if (beginExpand == true)
        {
            if (frameCount < 48f)
            {
                frameCount += 0.01f;
            }
            else if(frameCount >= 48f)
            {
                frameCount = 0;
            }
        }
    }

	void enableHitBox()
    {
        GetComponent<CapsuleCollider>().enabled = true;
        beginExpand = true;
    }

    void resetSize()
    {
        GetComponent<CapsuleCollider>().height = 1.68f;
        GetComponent<CapsuleCollider>().radius = 0.84f;
        GetComponent<CapsuleCollider>().direction = 0;
        //GetComponent<CapsuleCollider>().transform.localPosition = new Vector3(0.33f, 0, -1.03f);
    }

    void expand()
    {

        /*  a = 
                GetComponent<CapsuleCollider>().height = 1.68f;
                GetComponent<CapsuleCollider>().radius = 0.84f;
                GetComponent<CapsuleCollider>().direction = 0;
                GetComponent<CapsuleCollider>().transform.localPosition = new Vector3(0.33f, 0, -1.03f);

         *  b = 
                GetComponent<CapsuleCollider>().height = 2.13f;
                GetComponent<CapsuleCollider>().radius = 12.17f;
                GetComponent<CapsuleCollider>().direction = 0;
                GetComponent<CapsuleCollider>().transform.localPosition = new Vector3(0.33f, 0, -1.35f);

         *  t = 48 frames
         */

        Mathf.Lerp(GetComponent<CapsuleCollider>().height = 1.68f, GetComponent<CapsuleCollider>().height = 12.3f, frameCount);
        Mathf.Lerp(GetComponent<CapsuleCollider>().radius = 0.84f, GetComponent<CapsuleCollider>().radius = 2.17f, frameCount);
        //GetComponent<CapsuleCollider>().transform.localPosition = new Vector3(0, 0, Mathf.Lerp(startPos, endPos, frameCount));


    }

    void disableHitBox()
    {
        beginExpand = false;
        resetSize();
        GetComponent<CapsuleCollider>().enabled = false;
    }

}
