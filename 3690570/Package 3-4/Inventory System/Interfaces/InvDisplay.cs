using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class InvDisplay : MonoBehaviour
{
    public InventorySO inventory;
    public InventorySO prevInventory;
    public RectTransform container;

    public Dictionary<GameObject, InvSlot> intfSlots = new Dictionary<GameObject, InvSlot>();
    public virtual void Start()
    {
        for (int i = 0; i < inventory.GetSlots.Count; i++)
        {
            inventory.GetSlots[i].parent = this;
        }
        CreateSlots();
        AddEvent(container.gameObject, EventTriggerType.PointerEnter, delegate { OnEnterInterface(gameObject); });
        AddEvent(container.gameObject, EventTriggerType.PointerExit, delegate { OnExitInterface(gameObject); });
    }
    public abstract void CreateSlots();
    public void UpdateInvLinks()
    {
        int i = 0;
        foreach (var key in intfSlots.Keys.ToList())
        {
            intfSlots[key] = inventory.GetSlots[i];
            inventory.GetSlots[i].parent = this;
            inventory.GetSlots[i].slotDisplay = key;
            //intfSlots[key].onAfterUpdate += key.GetComponent<SlotCtrl>().UpdateUI;
            i++;
        }
    }
    private void Update()
    {
        if(prevInventory != inventory)
        {
            UpdateInvLinks();
        }
        prevInventory = inventory;
        intfSlots.UpdateSlotDisplay();
    }
    protected void AddEvent(GameObject _obj, EventTriggerType _type, UnityAction<BaseEventData> _action)
    {
        EventTrigger trigger = _obj.GetComponent<EventTrigger>();
        if (!trigger) { Debug.LogWarning("EventTrigger component is missing on inventory component: " + _obj.name.ToString(), _obj.transform); return; }

        var eTrigger = new EventTrigger.Entry();
        eTrigger.eventID = _type;
        eTrigger.callback.AddListener(_action);
        trigger.triggers.Add(eTrigger);
    }
    public void OnEnter(GameObject obj)
    {
        MouseData.slotHoveredOver = obj;
        Debug.Log("Hovered Item: " + intfSlots[obj].item.itemName);
        MouseData.interfaceMouseIsOver = intfSlots[obj].parent;
        //Debug.Log("Slot enteted, over interface: " + MouseData.interfaceMouseIsOver.gameObject.name.ToString());
    }
    public void OnEnterInterface(GameObject obj)
    {
        MouseData.interfaceMouseIsOver = obj.GetComponent<InvDisplay>();
        Debug.Log("Interface enteted, over interface: " + MouseData.interfaceMouseIsOver.gameObject.name.ToString());
    }
    public void OnExitInterface(GameObject obj)
    {
        MouseData.interfaceMouseIsOver = null;
        Debug.Log("Interface exited");
    }

    public void OnExit(GameObject obj)
    {
        MouseData.interfaceMouseIsOver = null;
        MouseData.slotHoveredOver = null;
        //Debug.Log("Slot exited, over interface: " + MouseData.interfaceMouseIsOver.gameObject.name.ToString());
    }

    public void OnDragStart(GameObject obj)
    {
        MouseData.tempItemBeingDragged = CreateTempItem(obj);
    }
    private GameObject CreateTempItem(GameObject obj)
    {
        GameObject tempItem = null;
        if (intfSlots[obj].item.id >= 0)
        {
            tempItem = new GameObject();
            var rt = tempItem.AddComponent<RectTransform>();
            rt.sizeDelta = new Vector2(50, 50);
            tempItem.transform.SetParent(transform.parent);
            var img = tempItem.AddComponent<Image>();
            img.sprite = intfSlots[obj].GetItemObject().itemIMG;
            img.raycastTarget = false;
        }
        return tempItem;
    }
    public void OnDragEnd(GameObject obj)
    {

        Destroy(MouseData.tempItemBeingDragged);

        if (MouseData.interfaceMouseIsOver == null && MouseData.slotHoveredOver == null)
        {
            //intfSlots[obj].RemoveItem();
            Debug.Log("No Interface or Slot found on drag end... Cancelling", this);
            return;
        }
        if (MouseData.slotHoveredOver != null)
        {
            InvSlot mouseHoverSlotData = MouseData.interfaceMouseIsOver.intfSlots[MouseData.slotHoveredOver];
            inventory.SwapItems(intfSlots[obj], mouseHoverSlotData);
        }
        else if (MouseData.interfaceMouseIsOver)
        {
            if(MouseData.interfaceMouseIsOver == this) { return; }
            if (MouseData.interfaceMouseIsOver.inventory.AddItem(intfSlots[obj].item))
            {
                intfSlots[obj].RemoveItem();
                this.UpdateInvLinks();
                MouseData.interfaceMouseIsOver.UpdateInvLinks();
            }
        }
    }

    public void OnDrag(GameObject obj)
    {
        if (MouseData.tempItemBeingDragged != null)
            MouseData.tempItemBeingDragged.GetComponent<RectTransform>().position = Input.mousePosition;
    }
}

public static class MouseData
{
    public static InvDisplay interfaceMouseIsOver;
    public static GameObject tempItemBeingDragged;
    public static GameObject slotHoveredOver;
}

public static class ExtensionMethods
{
    public static void UpdateSlotDisplay(this Dictionary<GameObject, InvSlot> _intfSlots)
    {
        foreach (KeyValuePair<GameObject, InvSlot> _slot in _intfSlots)
        {
            _slot.Key.GetComponent<SlotCtrl>().UpdateUI(_slot.Value);
        }
    }
}

