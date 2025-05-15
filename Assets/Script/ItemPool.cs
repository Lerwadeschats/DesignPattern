
using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public struct ItemDataPooling
{
    public GameObject _itemPrefab;
    public int count;
}

public class ItemPool : MonoBehaviour
{
    [SerializeField] List<ItemDataPooling> itemsData;
    List<Item> items = new List<Item>();

    private void OnEnable()
    {
        for (int i = 0; i < itemsData.Count; i++)
        {
            ItemDataPooling item = itemsData[i];
            for (int j = 0; j < item.count; j++)
            {
                GameObject newItem = Instantiate(item._itemPrefab, transform.position, Quaternion.identity, transform);
                Item newItemData = newItem.GetComponent<Item>();
                if (newItemData == null) continue;
                newItemData.OnDeactivate += DeactivateItem;
                items.Add(newItem.GetComponent<Item>());
                newItem.SetActive(false);
               

            }
        }
    }

    public void ActivateItem(Item item, Vector3 position)
    {
        Item itemInList = GetItemInList(item, false);
        if (itemInList == null) return;
        itemInList.transform.position = position;
        itemInList.gameObject.SetActive(true);
    }

    public void DeactivateItem(Item item)
    {
        Item itemInList = GetItemInList(item, true);
        if (itemInList == null) return;
        itemInList.transform.position = transform.position;
        itemInList.gameObject.SetActive(false);
    }

    public Item GetItemInList(Item item, bool isAlreadyUsed)
    {
        return items.Find(x => x.GetType() ==  item.GetType() && x.gameObject.activeInHierarchy == isAlreadyUsed);
    }

    public List<Item> GetItemsInList(Item item, bool isAlreadyUsed)
    {
        return items.FindAll(x => x.GetType() == item.GetType() && x.gameObject.activeInHierarchy == isAlreadyUsed);
    }

    public float GetDroppingChance(Item item)
    {

        
        List<Item> allItemsOfClass = items.Where(x => x.GetType() == item.GetType()).ToList();
        List<Item> itemsUsable = allItemsOfClass.Where(x => !x.gameObject.activeInHierarchy).ToList();
        return (float)itemsUsable.Count/ allItemsOfClass.Count;
    }

    public int GetMaxCountItem(Item item)
    {
        return GetItemsInList(item, false).Count;
    }
}
