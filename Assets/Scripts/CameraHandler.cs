using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;
    [SerializeField] private float speedMultiplier = 30f;
    [SerializeField] private float zoomAmount = 2f;
    [SerializeField] private float zoomSpeed = 5f;
    [SerializeField] private float minZoom = 1f, maxZoom = 30f;

    private float _orthographicSize;
    private float _targetOrthographicSize;

    private void Start()
    {
        _orthographicSize = cinemachineVirtualCamera.m_Lens.OrthographicSize;
        _targetOrthographicSize = _orthographicSize;
    }
    private void Update()
    {
        Movement();
        CameraZoom();
    }

    private void Movement()
    {
        float horiz = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = new Vector3(horiz, vert, 0).normalized;
        transform.position += moveDirection * (speedMultiplier * Time.deltaTime);
    }

    private void CameraZoom()
    {
        _targetOrthographicSize += -Input.mouseScrollDelta.y;
        _targetOrthographicSize = Mathf.Clamp(_targetOrthographicSize, minZoom, maxZoom);

        _orthographicSize = Mathf.Lerp(_orthographicSize, _targetOrthographicSize, Time.deltaTime * zoomSpeed);
        
        cinemachineVirtualCamera.m_Lens.OrthographicSize = _orthographicSize * zoomAmount;
    }
}
