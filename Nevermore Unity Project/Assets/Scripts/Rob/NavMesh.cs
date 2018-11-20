using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMesh : MonoBehaviour {

    [SerializeField]
    Transform destination;

    NavMeshAgent aiChar;


    public float minX, maxX, minZ, maxZ;
    float playerDist;
    GameObject player;

	// Use this for initialization
	void Start ()
    {
        aiChar = this.GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
	}

    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }

        if (aiChar != null)
        {
            SetDestination();
        }

        playerDist = Vector3.Distance(gameObject.transform.position, player.transform.position);
    }

    void SetDestination()
    {
        Vector3 patrolArea = new Vector3(Random.Range(minX, maxX), transform.position.y, Random.Range(minZ, maxZ));
    }

}
