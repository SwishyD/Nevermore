﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed;
    public float lifeTime;
    public float distance;
    public LayerMask whatIsSolid;
    public int damage;


	// Use this for initialization
	void Start () {
        Invoke("DestroyProjectile", lifeTime);
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if(hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                Debug.Log("ENEMY MUST TAKE DAMAGE !");
                hitInfo.collider.GetComponent<EnemyCody>().TakeDamage(damage);
            }
            DestroyProjectile();
        }
        transform.Translate(Vector2.up * speed * Time.deltaTime);
	}

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
