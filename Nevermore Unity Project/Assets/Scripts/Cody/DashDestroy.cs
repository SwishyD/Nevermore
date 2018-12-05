using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashDestroy : MonoBehaviour {

    public Animator dashAnim;


    // Use this for initialization
    void Start () {
        dashAnim = gameObject.GetComponent<Animator>();
        Invoke("Destroy", 0.1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Destroy()
    {
        Destroy(gameObject);
    }

   
}
