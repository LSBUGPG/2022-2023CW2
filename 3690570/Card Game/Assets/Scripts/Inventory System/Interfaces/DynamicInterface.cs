using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DynamicInterface : InvDisplay
{
    public ItemCategories currFilter = ItemCategories.Weapon;
    public bool filtered = false;
    public GameObject slotPrefab;
    int slotCount;
    public Action onRedraw;
    public override void Start()
    {
        base.Start();
        if (filtered) { CreateSlotsFiltered(currFilter); }
        inventory.onNewSlot += AddSlot;
    }
    public void ClearSlots()
    {
        foreach (Transform child in container)
        {
            RemoveSlot(child.gameObject);
        }
    }
    public override void CreateSlots()
    {
        filtered = false;
        ClearSlots();
        intfSlots = new Dictionary<GameObject, InvSlot>();
        for (int i = 0; i < inventory.GetSlots.Count; i++)
        {
            AddSlot(inventory.GetSlots[i]);
        }
        //UpdateInvLinks();
        onRedraw?.Invoke();
    }
    public void CreateSlotsFiltered(ItemCategories _type)
    {
        filtered = true;
        currFilter = _type;
        ClearSlots();
        intfSlots = new Dictionary<GameObject, InvSlot>();
        for (int i = 0; i < inventory.GetSlots.Count; i++)
        {
            AddSlot(inventory.GetSlots[i]);
        }
        onRedraw?.Invoke();
    }
    public void AddSlot(InvSlot _slot)
    {
        if (filtered)
        {
            if(inventory.itemDB.items[_slot.item.id].type != currFilter) { return; }
        }
        slotCount++;
        var obj = Instantiate(slotPrefab, Vector3.zero, Quaternion.identity, container);
        AddEvent(obj, EventTriggerType.PointerEnter, delegate { OnEnter(obj); });
        AddEvent(obj, EventTriggerType.PointerExit, delegate { OnExit(obj); });
        AddEvent(obj, EventTriggerType.BeginDrag, delegate { OnDragStart(obj); });
        AddEvent(obj, EventTriggerType.EndDrag, delegate { OnDragEnd(obj); });
        AddEvent(obj, EventTriggerType.Drag, delegate { OnDrag(obj); });
        _slot.slotDisplay = obj;
        intfSlots.Add(obj, _slot);
        intfSlots[obj] = _slot;
        _slot.parent = this;
        _slot.slotDisplay = obj;
        obj.GetComponent<SlotCtrl>().Setup(_slot);
    }
    public void RemoveSlot(GameObject _obj)
    {
        slotCount--;
        intfSlots.Remove(_obj);
        Destroy(_obj);
    }
}
