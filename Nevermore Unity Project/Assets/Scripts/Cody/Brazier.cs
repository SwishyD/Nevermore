using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brazier : MonoBehaviour {

    private Animator anim;
    public bool isUpgraded;
    public Transform checkpoint;
  

	// Use this for initialization
	void Awake () {
        anim = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            anim.SetBool("isActive" , true);
        }
    }

    private void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            GameManager.instance.respawnPoint = checkpoint;
            if (Input.GetKeyDown(KeyCode.E) && GameManager.instance.playerGold >= 100f && isUpgraded == false)
            {
                anim.SetBool("Pulse", true);
                isUpgraded = true;
                GameManager.instance.UpGrade();
                StartCoroutine(WaitTime());
            }
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            anim.SetBool("isActive", false);
        }

    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(0.4f);
        anim.SetBool("Pulse", false);

    }
}
