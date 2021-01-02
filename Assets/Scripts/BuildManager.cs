using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private BuildingTypeSO _buildingType;
    private BuildingTypeListSO _buildingTypeList;
    private Camera _camera;

    private void Awake()
    {
        _buildingTypeList = Resources.Load<BuildingTypeListSO>(nameof(BuildingTypeListSO));
        _buildingType = _buildingTypeList.list[0];
    }

    void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(_buildingType.prefab, GetMouseWorldPosition(), Quaternion.identity);
        }
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            _buildingType = _buildingTypeList.list[0];
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            _buildingType = _buildingTypeList.list[1];
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseWorldPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f;
        return mouseWorldPosition;
    }
}
