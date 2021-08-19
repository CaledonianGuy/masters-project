using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Camera mainCam;

    [SerializeField] private CameraSettings camSettings;

    private void Start()
    {
        mainCam = GetComponent<Camera>();
    }

    private void Update()
    {
        PanCamera();
        Zoom();
    }

    private void PanCamera()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * camSettings.movementSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * camSettings.movementSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.up * camSettings.movementSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.down * camSettings.movementSpeed * Time.deltaTime;
        }

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -6.4f * (5.0f / mainCam.orthographicSize), 6.4f * (5.0f / mainCam.orthographicSize)),
            Mathf.Clamp(transform.position.y, -3.6f * (5.0f / mainCam.orthographicSize), 3.6f * (5.0f / mainCam.orthographicSize)),
            transform.position.z);
    }

    private void Zoom()
    {
        if (Input.mouseScrollDelta.y > 0)
        {
            float newSize = mainCam.orthographicSize - camSettings.zoomStepSize;
            mainCam.orthographicSize = Mathf.Clamp(newSize, camSettings.minCamSize, camSettings.maxCamSize);
        }

        if (Input.mouseScrollDelta.y < 0)
        {
            float newSize = mainCam.orthographicSize + camSettings.zoomStepSize;
            mainCam.orthographicSize = Mathf.Clamp(newSize, camSettings.minCamSize, camSettings.maxCamSize);
        }
    }
}
