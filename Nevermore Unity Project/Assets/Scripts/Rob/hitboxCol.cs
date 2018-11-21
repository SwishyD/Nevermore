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

    private void OnTriggerStay(Collider collision)
    {
        timeToDamage += Time.deltaTime;
        enemy.SetBool("isAttacking", true);
        if (collision.gameObject.tag == "Player" && timeToDamage > 2f)
        {


            GameManager.instance.TakeDamage(damage);
            timeToDamage = 0;

        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Player")
        enemy.SetBool("isAttacking", false);
    }

}
