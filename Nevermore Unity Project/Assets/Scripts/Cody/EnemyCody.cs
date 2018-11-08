using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCody : MonoBehaviour {
    public int health;
    public float speed;

    public SpriteRenderer[] bodyParts;
    public Color hurtColor;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0)
        {
            Destroy(gameObject);
        }

	}

    public void TakeDamage(int damage)
    {
        StartCoroutine(Flash());
        health -= damage;
        Debug.Log("damage TAKEN !");
    }

    IEnumerator Flash()
    {
        for (int i = 0; i < bodyParts.Length; i++)
        {
            bodyParts[i].color = hurtColor;
        }
        yield return new WaitForSeconds(0.1f);
        for (int i = 0; i < bodyParts.Length; i++)
        {
            bodyParts[i].color = Color.yellow;
        }
    }
}
