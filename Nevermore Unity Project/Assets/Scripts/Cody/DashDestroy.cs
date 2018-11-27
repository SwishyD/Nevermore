using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashDestroy : MonoBehaviour {

    public Animator dashAnim;


    // Use this for initialization
    void Start () {
        dashAnim = gameObject.GetComponent<Animator>();
        Invoke("Destroy", 0.4f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Destroy()
    {
        Destroy(gameObject);
    }

    public void HandleAnim(float animNum)
    {
        if(animNum == 1f)
        {
            dashAnim.SetFloat("yInput", 1f);
        }
        if (animNum == 2f)
        {
            dashAnim.SetFloat("yInput", -1f);
        }
        if (animNum == 3f)
        {
            dashAnim.SetFloat("xInput", -1f);
        }
        if (animNum == 4f)
        {
            dashAnim.SetFloat("xInput", 1f);
        }
    }
}
