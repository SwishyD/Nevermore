using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour {

    public bool activated = false;
    public static GameObject[] CPList;
    Animator CPAnim;
    public Vector3 curCP;
    public int index;
    //GameObject Player;

	// Use this for initialization
	void Start () {
        CPList = GameObject.FindGameObjectsWithTag("Checkpoint");
        CPAnim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
    }

    //checkpoint.getConponent.Turnoffthings(index)

    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E) && activated == false)
            {
                //ActivateCheckpoint();
                curCP = col.transform.position;
                //Player.GetComponent<PlayerController>().currentCP = curCP;
           }
        }
    }

    public void ActivateCheckpoint(int index)
    {
        foreach (GameObject cp in CPList)
        {
            cp.GetComponent<Checkpoints>().activated = false;
            CPAnim.GetComponent<Animator>().SetBool("Active", false);
        }
        CPList[index].SetActive(true);
        activated = true;
        CPAnim.GetComponent<Animator>().SetBool("Active", true);
    }


    public static Vector3 GetActiveCheckPointPosition()
    {
        // If player die without activate any checkpoint, we will return a default position
        Vector3 result = new Vector3(0, 0, 0);

        if (CPList != null)
        {
            foreach (GameObject cp in CPList)
            {
                // We search the activated checkpoint to get its position
                if (cp.GetComponent<Checkpoints>().activated)
                {
                    result = cp.transform.position;
                    break;
                }
            }
        }

        return result;
    }

}