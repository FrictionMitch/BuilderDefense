using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResourcesUI : MonoBehaviour
{
    [SerializeField] private float offset = -160f;

    private ResourceTypeListSO _resourceTypeList;
    private Dictionary<ResourceTypeSO, Transform> resourceTypeTransformDictionary;
    private void Awake()
    {
        _resourceTypeList = Resources.Load<ResourceTypeListSO>(nameof(ResourceTypeListSO));

        resourceTypeTransformDictionary = new Dictionary<ResourceTypeSO, Transform>();
        
        Transform resourceTemplate = transform.Find("resourceTemplate");
        resourceTemplate.gameObject.SetActive(false);

        int index = 0;
        foreach (ResourceTypeSO resourceType in _resourceTypeList.list)
        {
            Transform resourceTransform = Instantiate(resourceTemplate, this.transform);
            resourceTransform.gameObject.SetActive(true);

            resourceTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(offset * index, 0f);

            resourceTransform.Find("image").GetComponent<Image>().sprite = resourceType.sprite;

            resourceTypeTransformDictionary[resourceType] = resourceTransform;
            ++index;

        }
    }

    private void Start()
    {
        UpdateResourceAmount();
    }

    private void UpdateResourceAmount()
    {
        foreach (ResourceTypeSO resourceType in _resourceTypeList.list)
        {
            Transform resourceTransform = resourceTypeTransformDictionary[resourceType];
            
            int resourceAmount = ResourceManager.Instance.GetResourceAmount(resourceType);
            resourceTransform.Find("text").GetComponent<TextMeshProUGUI>().SetText(resourceAmount.ToString());
        }
    }

    private void OnEnable()
    {
        ResourceManager.Instance.OnResourceAmountChanged += UpdateResourceAmount;
    }

    private void OnDisable()
    {
        ResourceManager.Instance.OnResourceAmountChanged -= UpdateResourceAmount;
    }
}
