using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class hitboxCol : MonoBehaviour{

    public int damage = 10;
    public float damageTime = 5;
    public float timeToDamage;

    private void Update()
    {
        timeToDamage += Time.deltaTime;
        if(timeToDamage > damageTime)
        {
            timeToDamage = damageTime;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player" && timeToDamage > 4.9f)
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
            timeToDamage = 0;
        }
    }

}
