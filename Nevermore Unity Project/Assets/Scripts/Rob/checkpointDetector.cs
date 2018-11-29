using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpointDetector : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E) && GetComponent<Checkpoints>().activated == false)
            {
                //GetComponent<Checkpoints>().ActivateCheckpoint(i);
            }
        }
    }
}
