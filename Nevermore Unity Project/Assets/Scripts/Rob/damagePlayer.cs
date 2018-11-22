using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damagePlayer : MonoBehaviour {

    public int damage;

    public void DealDamage()
    {
        GameManager.instance.TakeDamage(damage);
    }
}
