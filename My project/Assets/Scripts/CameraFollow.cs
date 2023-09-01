using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The player's transform to follow
    public Vector3 offset = new Vector3(7f, 1f, 0.75f); // Offset from the player

    public float smoothSpeed = 0.125f; // Smoothing factor for camera movement

    private Camera cam; // Reference to the camera component

    private void Awake()
    {
        cam = GetComponent<Camera>();
        if (cam == null)
        {
            Debug.LogWarning("Camera component not found. Make sure the script is attached to a GameObject with a Camera component.");
        }
    }


    private void LateUpdate()
    {
        // Calculate the desired camera position
        Vector3 desiredPosition = target.position + offset;

        // Smoothly interpolate the camera's current position toward the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Apply the smoothed position to the camera
        transform.position = smoothedPosition;

        // Optionally adjust the FOV for zooming effect
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 60f, smoothSpeed);
    }
}