using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LimitedInterface : InvDisplay
{
    public GameObject[] slots;
    public override void CreateSlots()
    {
        intfSlots = new Dictionary<GameObject, InvSlot>();
        for (int i = 0; i < inventory.GetSlots.Capacity; i++)
        {
            var obj = slots[i];
            AddEvent(obj, EventTriggerType.PointerEnter, delegate { OnEnter(obj); });
            AddEvent(obj, EventTriggerType.PointerExit, delegate { OnExit(obj); });
            AddEvent(obj, EventTriggerType.BeginDrag, delegate { OnDragStart(obj); });
            AddEvent(obj, EventTriggerType.EndDrag, delegate { OnDragEnd(obj); });
            AddEvent(obj, EventTriggerType.Drag, delegate { OnDrag(obj); });
            inventory.GetSlots[i].slotDisplay = obj;
            intfSlots.Add(obj, inventory.GetSlots[i]);
        }
    }
}
