using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public float xMin;
    public float yMin;
    public float xMax;
    public float yMax;

    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    public void LateUpdate()
    {
    //    if (transform.position.z <= xMax && transform.position.z >= xMin && transform.position.y <= yMax && transform.position.z >= yMin)
        //{
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            gameObject.transform.position = smoothedPosition;
        //}
        //else
        //{
        //    float x = Mathf.Clamp(target.transform.position.z, xMin, xMax);
        //    float y = Mathf.Clamp(target.transform.position.y, yMin, yMax);
        //}
    }





    // Use this for initialization
    void Start () {

		
	}
	
	// Update is called once per frame
}
