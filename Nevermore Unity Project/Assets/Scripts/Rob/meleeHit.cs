using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeHit : damagePlayer {

    AudioSource mySound;
    public AudioClip attackSound;

    void Awake()
    {
        mySound = gameObject.GetComponent<AudioSource>();
    }

    protected override void DealDamage()
    {
        mySound.PlayOneShot(attackSound);
        base.DealDamage();

    }

}
