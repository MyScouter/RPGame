using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform traget;

    public Vector3 offset;
    public float zoomSpeed =4f;
    public float minZoom = 5f;
    public float maxZoom = 15f;

    public float pitch = 2f;

    public float yawSpeed = 100f;

    private float yawInput = 0f;
    private float currentZoom = 10f;

    public void Update()
    {
        currentZoom-=Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        yawInput-=Input.GetAxis("Horizontal") * yawSpeed *Time.deltaTime;
        
    }

    private void LateUpdate()
    {
        
        transform.position = traget.position - offset * currentZoom;
        transform.LookAt(transform.position + (Vector3.back+Vector3.down) * pitch);

        transform.RotateAround(traget.position, Vector3.up, yawInput);

    }
}
