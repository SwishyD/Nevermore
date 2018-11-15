using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class hitboxCol : MonoBehaviour{

    public int damage = 10;
    public float damageTime = 5;
    public float timeToDamage;
    public float attackSpeed = 4.9f;

    public Animator enemy;

    private void Update()
    {
        if(timeToDamage > damageTime)
        {
            timeToDamage = damageTime;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        timeToDamage += Time.deltaTime;
        enemy.SetBool("isAttacking", true);
        if (collision.gameObject.tag == "Player" && timeToDamage > 2f)
        {


            collision.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
            timeToDamage = 0;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        enemy.SetBool("isAttacking", false);
    }

}
