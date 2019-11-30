using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedAngleCamera : MonoBehaviour
{
    public Transform target;

    private Quaternion fixedRotation;
    private Vector3 positionOffset;

    void Start()
    {
        fixedRotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
        positionOffset = transform.position - target.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.rotation = fixedRotation;
        transform.position = target.position + positionOffset;
    }
}
