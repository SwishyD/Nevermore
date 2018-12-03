using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessRespawn : MonoBehaviour {

    public void CallRespawn()
    {
        Debug.Log("RESPAWN");
        GameManager.instance.Respawn();
    }
}
