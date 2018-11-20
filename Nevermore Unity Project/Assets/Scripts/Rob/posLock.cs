using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posLock : MonoBehaviour {

    //navmesh agent to lock the position of the sprite to
    public GameObject target;
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position = target.transform.position;
	}
}
