using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGenerator : MonoBehaviour
{
  private BuildingTypeSO _buildingType;
  private float _timer;
  private float _timerMax;

  private int _tempCount;

  private void Awake()
  {
    _buildingType = GetComponent<BuildingTypeHolder>().buildingType;
    _timerMax = _buildingType.resourceGeneratorData.timerMax;
  }

  private void Update()
  {
    _timer -= Time.deltaTime;

    if (_timer <= 0f)
    {
      ++_tempCount;
      _timer += _timerMax;
      ResourceManager.Instance.AddResource(_buildingType.resourceGeneratorData.resourceType, 1);
    }
    
  }
}
