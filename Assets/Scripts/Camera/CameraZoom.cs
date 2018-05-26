using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{

    private Camera _mainCamera;

    // Максимальное и минимальное значение для зума
    public float DefaultZoom = 10;
    public float MinZoom = 8;
    public float MaxZoom = 12;

    // Use this for initialization
    void Start()
    {

        _mainCamera = transform.GetChild(0).gameObject.GetComponent<Camera>();
        if (_mainCamera != null)
        {
            _mainCamera.fieldOfView = DefaultZoom;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_mainCamera != null)
        {
            // Zoom +
            if ((_mainCamera.fieldOfView <= MaxZoom) && Input.mouseScrollDelta.y < 0)
            {
                _mainCamera.fieldOfView += 0.1f;
            }

            // Zoom -
            if ((_mainCamera.fieldOfView >= MinZoom) && Input.mouseScrollDelta.y > 0)
            {
                _mainCamera.fieldOfView -= 0.1f;
            }
        }
    }
}
