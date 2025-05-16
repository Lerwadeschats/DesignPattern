using System.Collections.Generic;
using System;
using UnityEngine;



public class Drop : MonoBehaviour
{

    [Serializable]
    public struct DropContent
    {
        public GameObject item;
        public int minAmount;
        public int maxAmount;
        [Range(0, 1f)] public float chance;
        
    }
    [SerializeField] List<DropContent> _availableContent;

    List<Item> _currentContent = new List<Item>();

    ItemPool _pool;

    private void Start()
    {
        _pool = FindFirstObjectByType<ItemPool>();
        CreateNewDrop();
    }
    public void CreateNewDrop()
    {
        int contentCount = UnityEngine.Random.Range(0, _availableContent.Count + 1);
        for (int i = 0; i < contentCount; i++)
        {
            DropContent content = GetContentByChance();
            if (content.item == null) continue;
            for (int j = 0; j < GetRandomAmount(content); j++)
            {
                Item contentItem = content.item.GetComponent<Item>();
                _currentContent.Add(contentItem);
            }
            
        }
    }

    DropContent GetContentByChance()
    {
        List<DropContent> possibleContent = new List<DropContent>();
        
        float randChance = UnityEngine.Random.Range(0, 1f);
        for (int i = 0; i < _availableContent.Count; i++)
        {
            float itemChance = _pool.GetDroppingChance(_availableContent[i].item.GetComponent<Item>()) * _availableContent[i].chance;
            if (itemChance >= randChance)
            {
                possibleContent.Add(_availableContent[i]);
            }
        }
        if (possibleContent.Count > 0)
        {
            int randElement = UnityEngine.Random.Range(0, possibleContent.Count);
            return possibleContent[randElement];
        }
        
        return new DropContent();

    }

    int GetRandomAmount(DropContent content)
    {
        Item item = content.item.GetComponent<Item>();
        int randAmount = UnityEngine.Random.Range(content.minAmount, content.maxAmount);
        Mathf.Clamp(randAmount, 0, _pool.GetMaxCountItem(item));
        return UnityEngine.Random.Range(content.minAmount, content.maxAmount);
    }

    public void SpawnDrop()
    {
        foreach (var item in _currentContent)
        {
            _pool.ActivateItem(item, GetRandomPos());
        }
    }

    Vector3 GetRandomPos()
    {
        Vector3 currentPos = transform.position;
        Vector3 randVector = new Vector3(UnityEngine.Random.Range(currentPos.x - 1, currentPos.x + 1), 1, UnityEngine.Random.Range(currentPos.z - 1, currentPos.z + 1));
        return randVector;
    }
    
}
