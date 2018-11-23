using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed;
    public float lifeTime;
    public float distance;
    public int damage = 5;
   

	// Use this for initialization
	void Start ()
    {
        Invoke("DestroyProjectile", lifeTime);
	}
	
	// Update is called once per frame
	void Update ()
    {
      transform.Translate(Vector2.up * speed * Time.deltaTime);
	}

    private void OnTriggerEnter(Collider col)
    {
        print("check");
        if (col.transform.tag == "Enemy")
        {           
            col.gameObject.GetComponentInParent<EnemyHealthSystem>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
