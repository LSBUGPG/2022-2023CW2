using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

[System.Serializable]
public class InvSlot
{
    public ItemCategories[] allowedItems = new ItemCategories[0];

    [System.NonSerialized]
    public InvDisplay parent;
    [System.NonSerialized]
    public GameObject slotDisplay;

    [System.NonSerialized]
    public Action<InvSlot> onAfterUpdate;
    [System.NonSerialized]
    public Action<InvSlot> onBeforeUpdate;

    public ItemData item;

    public ItemSO GetItemObject()
    {
        return item.id >= 0 ? parent.inventory.itemDB.items[item.id] : null;
    }
    public InvSlot() => UpdateSlot(new ItemData());
    public InvSlot(ItemData _item) => UpdateSlot(_item);
    public void RemoveItem() => UpdateSlot(new ItemData());
    public void UpdateSlot(ItemData _item)
    {
        onBeforeUpdate?.Invoke(this);
        item = _item;
        onAfterUpdate?.Invoke(this);
    }
    public bool CanPlaceInSlot(ItemSO itemObject)
    {
        if (allowedItems.Length <= 0 || itemObject == null || itemObject.data.id < 0)
            return true;
        for (int i = 0; i < allowedItems.Length; i++)
        {
            if (itemObject.type == allowedItems[i])
                return true;
        }
        return false;
    }
}
