using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class CameraSettings : ScriptableObject
{
    // Camera Main Settings
    [Header("Main Settings")]
    public float movementSpeed = 10.0f;

    public float zoomStepSize = 0.5f;
    public float minCamSize = 2.5f;
    public float maxCamSize = 5.0f;
}
