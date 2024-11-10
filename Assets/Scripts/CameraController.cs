using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector2 locationOffset;
    public Vector2 rotationOffset;

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + new Vector3(locationOffset.x, locationOffset.y, -10);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        Quaternion desiredRotation = Quaternion.Euler(rotationOffset.x, rotationOffset.y, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, smoothSpeed);
    }
}
