using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageText : MonoBehaviour {

    public int damage;

	// Use this for initialization
	void Awake () {

        gameObject.GetComponentInChildren<TextMesh>().text = "" + damage;
        Invoke("DestroyText", 0.5f);
	}
	
	void DestroyText()
    {
        Destroy(gameObject);
    }
}
