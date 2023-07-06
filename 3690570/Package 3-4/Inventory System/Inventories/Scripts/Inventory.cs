using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Inventory
{
    public List<InvSlot> slots = new List<InvSlot>();
    public void ClearAndResize(int _size)
    {
        Clear();
        for (int i = 0; i < _size; i++)
        {
            slots.Add(new InvSlot());
        }
    }
    public void Clear()
    {
        slots.Clear();
        slots.TrimExcess();
    }
    public bool ContainsItem(ItemSO _item)
    {
        return slots.Find(i => i.item.id == _item.data.id) != null;
    }
    public bool ContainsItem(int _itemID)
    {
        return slots.Find(i => i.item.id == _itemID) != null;
    }
}
