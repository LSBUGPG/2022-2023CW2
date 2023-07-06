using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Database", menuName = "Inventory System/New Database", order = 1)]
public class ItemDatabaseSO : ScriptableObject
{
    public ItemSO[] items;

    public void OnValidate()
    {
        for (int i = 0; i < items.Length; i++)
        {
            items[i].data.id = i;
        }
    }
}
