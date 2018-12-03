using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brazier : MonoBehaviour {


    public bool isUpgraded;
    public Transform checkpoint;

	// Use this for initialization
	void Awake () {
      

    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            GameManager.instance.respawnPoint = checkpoint;
            if (Input.GetKeyDown(KeyCode.E) && GameManager.instance.playerGold >= 100f && isUpgraded == false)
            {
                isUpgraded = true;
                GameManager.instance.UpGrade();
            }
        }
    }
}
