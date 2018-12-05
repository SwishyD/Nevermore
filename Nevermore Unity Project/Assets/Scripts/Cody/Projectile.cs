using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed;
    public float lifeTime;
    public float distance;
    public int damage = 5;
    public bool isMelee;
    public GameObject fbGreenHit;
    public GameObject damageText;
   


	void Awake ()
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
        if (col.transform.tag == "Enemy")
        {
            Instantiate(damageText, gameObject.transform.position, Quaternion.Euler(90,0,0));
            col.gameObject.GetComponentInParent<EnemyHealthSystem>().TakeDamage(damage);
            if (!isMelee)
            {
                Instantiate(fbGreenHit, col.gameObject.transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            if (!isMelee)
            {
                Instantiate(fbGreenHit, gameObject.transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
