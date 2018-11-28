using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damagePlayer : MonoBehaviour {

    public int damage;
    float dist;
    GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        dist = Vector3.Distance(gameObject.transform.position, player.transform.position);
    }

    public void DealDamage()
    {
        if (dist < 1)
        {
            GameManager.instance.TakeDamage(damage);
        }
    }
}
