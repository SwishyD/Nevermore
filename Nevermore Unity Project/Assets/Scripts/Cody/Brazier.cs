using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Brazier : MonoBehaviour {

    private Animator anim;
    public bool isUpgraded;
    public Transform checkpoint;
    private bool used = false;
    public GameObject checkpointText;
    public GameObject toolTip;
    public GameObject upgradeText;
    public GameObject thankyouText;

    //Audio Vars
    private AudioSource mySound;
    public AudioClip upGSound;
    public AudioClip igniteSound;
	
	void Awake () {
        anim = gameObject.GetComponent<Animator>();
        mySound = gameObject.GetComponent<AudioSource>();
    }

    void Update () {
		
	}

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            mySound.PlayOneShot(igniteSound);
            toolTip.SetActive(true);
            anim.SetBool("isActive" , true);
            if (used == false)
            {
                checkpointText.SetActive(true);

                GameManager.instance.respawnPoint = checkpoint;
                used = true;
                StartCoroutine(TextWaitTime());
            }


        }
    }

    private void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {

            if (Input.GetKeyDown(KeyCode.E) && GameManager.instance.playerGold >= 100f && isUpgraded == false)
            {
                mySound.PlayOneShot(upGSound);
                upgradeText.SetActive(false);
                thankyouText.SetActive(true);
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
            toolTip.SetActive(false);
            anim.SetBool("isActive", false);
        }

    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(0.4f);
        anim.SetBool("Pulse", false);

    }

    IEnumerator TextWaitTime()
    {
        Debug.Log("Waiting");
        yield return new WaitForSeconds(2f);
        checkpointText.SetActive(false);
    }
}
