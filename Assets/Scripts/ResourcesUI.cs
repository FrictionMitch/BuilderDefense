using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesUI : MonoBehaviour
{
    private void Awake()
    {
        ResourceTypeListSO resourceTypeList = Resources.Load<ResourceTypeListSO>(nameof(ResourceTypeListSO));

        foreach (ResourceTypeSO resourceType in resourceTypeList.list)
        {
            Transform resourceTemplate = transform.Find("resourceTemplate");
        }
    }
}
