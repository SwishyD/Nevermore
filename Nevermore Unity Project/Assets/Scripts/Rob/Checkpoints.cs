using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour {

    bool activated = false;
    public GameObject[] CPList;
    Animator CPAnim;
    public Vector3 curCP;
    //GameObject Player;

	// Use this for initialization
	void Start () {
        CPList = GameObject.FindGameObjectsWithTag("Checkpoint");
        CPAnim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if(CPList != null)
        {
            print(gameObject.transform.position);
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ActivateCheckpoint();
                curCP = col.transform.position;
                //Player.GetComponent<PlayerController>().currentCP = curCP;
           }
        }
    }

    void ActivateCheckpoint()
    {
        foreach (GameObject cp in CPList)
        {
            cp.GetComponent<Checkpoints>().activated = false;
            CPAnim.SetBool("Active", false);
        }
        activated = true;
        CPAnim.SetBool("Active", true);
    }
    

}