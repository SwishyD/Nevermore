using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallColTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnCollisionStay2D (Collision2D col)
    {
        //print(col.gameObject.name);
		if (col.gameObject.tag == "Wall")
        {
            GetComponentInParent<PathfinderReduxRat>().colliding = true;
            //print("doing thing");
        }
	}
}
