using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory System/New Item", order = 1)]
public class ItemSO : ScriptableObject
{
    public ItemData data = new ItemData();
    public string itemDesc;
    public Sprite itemIMG;
    public GameObject itemPrefab;
    public ItemCategories type;
    public float statValue;

    public ItemData CreateItem()
    {
        ItemData newItem = new ItemData(this);
        return newItem;
    }
}
