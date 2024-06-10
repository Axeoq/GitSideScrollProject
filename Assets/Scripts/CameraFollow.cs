using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothspeed = 0.125f;

    public Vector3 offset; 

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset; 

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothspeed);

        transform.position = new Vector3(smoothedPosition.x, transform.position.y, transform.position.z);
    }
}
