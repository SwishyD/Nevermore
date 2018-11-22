using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour {


    public int health = 10;

    public GameObject Enemy;
    public Color hurtColor;
    public SpriteRenderer[] bodyParts;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0)
        {
            Destroy(Enemy);
        }        
	}


    public void TakeDamage(int damage)
    {
        print("hit");
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
            bodyParts[i].color = Color.white;
        }
    }


}
