using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/New Inventory", order = 1)]
public class InventorySO : ScriptableObject
{
    public string savePath;
    public ItemDatabaseSO itemDB;
    [SerializeField]
    Inventory contents = new Inventory();
    public List<InvSlot> GetSlots => contents.slots;
    public int invSize = 25;
    public bool limitSize = false;
    public Action<InvSlot> onNewSlot;

    private void OnValidate()
    {
        contents.ClearAndResize(invSize);
    }
    public bool AddItem(ItemSO _item)
    {
        if (EmptySlotCount <= 0 && limitSize)
        {
            return false;
        }
        else if(EmptySlotCount <= 0 && !limitSize)
        {
            InvSlot newSlot = new InvSlot();
            contents.slots.Add(newSlot);
            onNewSlot?.Invoke(newSlot);
        }    

        GetEmptySlot().UpdateSlot(_item.data);
        
        return true;
    }
    public bool AddItem(ItemData _item)
    {
        if (EmptySlotCount <= 0 && limitSize)
        {
            return false;
        }
        else if (EmptySlotCount <= 0 && !limitSize)
        {
            InvSlot newSlot = new InvSlot();
            contents.slots.Add(newSlot);
            GetEmptySlot().UpdateSlot(_item);
            onNewSlot?.Invoke(newSlot);
            return true;
        }

        GetEmptySlot().UpdateSlot(_item);
        return true;
    }
    public int EmptySlotCount
    {
        get
        {
            int counter = 0;
            for (int i = 0; i < GetSlots.Count; i++)
            {
                if (GetSlots[i].item.id <= -1)
                {
                    counter++;
                }
            }
            return counter;
        }
    }
    public InvSlot GetEmptySlot()
    {
        for (int i = 0; i < GetSlots.Count; i++)
        {
            if (GetSlots[i].item.id <= -1)
            {
                return GetSlots[i];
            }
        }
        return null;
    }
    public InvSlot FindItemOnInventory(ItemData _item)
    {
        for (int i = 0; i < GetSlots.Count; i++)
        {
            if (GetSlots[i].item.id == _item.id)
            {
                return GetSlots[i];
            }
        }
        return null;
    }


    public bool IsItemInInventory(ItemSO item)
    {
        for (int i = 0; i < GetSlots.Count; i++)
        {
            if (GetSlots[i].item.id == item.data.id)
            {
                return true;
            }
        }
        return false;
    }
    public void SwapItems(InvSlot _sending, InvSlot _rec)
    {
        if (_sending == _rec)
            return;
        if(_rec.CanPlaceInSlot(_sending.GetItemObject()) && _sending.CanPlaceInSlot(_rec.GetItemObject()))
        {
            InvSlot temp = new InvSlot(_rec.item);
            _rec.UpdateSlot(_sending.item);
            _sending.UpdateSlot(temp.item);

            if (!_rec.parent.inventory.limitSize)
            {
                if(_rec.item.id < 0)
                {
                    DynamicInterface dInt = _rec.parent as DynamicInterface;
                    if(dInt != null)
                    {
                        dInt.RemoveSlot(_rec.slotDisplay);
                        _rec.parent.inventory.GetSlots.Remove(_rec);
                    }
                }
            }
            if (!_sending.parent.inventory.limitSize)
            {
                if (_sending.item.id < 0)
                {
                    DynamicInterface dInt = _sending.parent as DynamicInterface;
                    if (dInt != null)
                    {
                        dInt.RemoveSlot(_sending.slotDisplay);
                        _sending.parent.inventory.GetSlots.Remove(_sending);
                    }
                }
            }
        }
    }
    [ContextMenu("Save")]
    public void Save()
    {
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Create, FileAccess.Write);
        formatter.Serialize(stream, contents);
        stream.Close();
    }

    [ContextMenu("Load")]
    public void Load()
    {
        if (File.Exists(string.Concat(Application.persistentDataPath, savePath)))
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Open, FileAccess.Read);
            Inventory newContainer = (Inventory)formatter.Deserialize(stream);
            for (int i = 0; i < GetSlots.Count; i++)
            {
                GetSlots[i].UpdateSlot(newContainer.slots[i].item);
            }
            stream.Close();
        }
    }
    [ContextMenu("Clear")]
    public void Clear()
    {
        contents.Clear();
        contents.ClearAndResize(invSize);
    }
}

