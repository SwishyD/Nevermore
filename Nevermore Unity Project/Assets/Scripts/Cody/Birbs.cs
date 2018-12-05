using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birbs : MonoBehaviour {

    Animator anim;

	// Use this for initialization
	void Start () {
        anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            anim.SetBool("Pulse", true);
            Invoke("DestroyBirb", 2f);
        }
    }

    void DestoyBirb()
    {
        Destroy(gameObject);
    }
}
