using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damagePlayer : MonoBehaviour {

    public int damage;
    protected float dist;
    protected GameObject player;

    protected virtual void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    protected virtual void Update()
    {
        dist = Vector3.Distance(gameObject.transform.position, player.transform.position);
    }

    protected virtual void DealDamage()
    {
        if (dist < 2.5f)
        {
            GameManager.instance.TakeDamage(damage);
        }
    }
}
