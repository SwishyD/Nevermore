using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHit : MonoBehaviour {

  
    public float lifeTime;


    private void Awake()
    {
        Debug.Log("AWAKE");
    }
    // Use this for initialization
    void Start ()
    {
        Invoke("DestroyProjectile", lifeTime);
	}
	
	
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
