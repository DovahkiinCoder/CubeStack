using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    float deltaZ;

    void Start()
    {
        deltaZ = transform.position.z - target.position.z;
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, target.position.z + deltaZ);
    }
}
