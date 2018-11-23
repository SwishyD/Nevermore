using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashDestroy : MonoBehaviour {



	// Use this for initialization
	void Start () {
        Invoke("Destroy", 0.4f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
