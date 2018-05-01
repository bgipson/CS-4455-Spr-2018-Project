using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public Transform target;            // The position that that camera will be following.
    public float smoothing = 5f;        // The speed with which the camera will be following.
    public GameObject rotationPoint;
    Vector3 offset;                     // The initial offset from the target.

    protected Vector3 currentPositionCorrectionVelocity;
    protected Vector3 currentFacingCorrectionVelocity;

    public float smoothTime = 1f;       // a public variable to adjust smoothing of camera motion
    public float maxSpeed = 50f;        //max speed camera can move

    void Start()
    {
        // Calculate the initial offset.
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        // Create a postion the camera is aiming for based on the offset from the target.
        Vector3 targetCamPos = target.position + offset;

        if (rotationPoint)
        {
            //transform.position = Vector3.Lerp(transform.position, rotationPoint.transform.position, smoothing * Time.deltaTime);
            //transform.rotation = Quaternion.Slerp(transform.rotation, rotationPoint.transform.rotation, smoothing * Time.deltaTime);
            transform.position = Vector3.SmoothDamp(transform.position, rotationPoint.transform.position, ref currentPositionCorrectionVelocity, smoothTime, maxSpeed, Time.deltaTime);
            transform.forward = Vector3.SmoothDamp(transform.forward, rotationPoint.transform.forward, ref currentFacingCorrectionVelocity, smoothTime, maxSpeed, Time.deltaTime);
        }
        else
        {
            // Smoothly interpolate between the camera's current position and it's target position.
            transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
        }
    }
}