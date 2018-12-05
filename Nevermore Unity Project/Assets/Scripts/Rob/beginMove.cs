using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beginMove : MonoBehaviour {

    public bool attacking = false;
    

    void attackSwitch()
    {
        attacking = false;
    }

    void KillNav()
    {
        Destroy(GetComponent<Animator>());
        Destroy(GetComponent<EnemyHealthSystem>());
        Destroy(GetComponent<meleeHit>());
        Destroy(GetComponent<beginMove>());
    }
    
}
