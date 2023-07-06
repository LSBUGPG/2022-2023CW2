using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotCtrl : MonoBehaviour
{
    [SerializeField] Image itemIMG;
    InvSlot currSlot;
    public void Setup(InvSlot _slot)
    {
        currSlot = _slot;
        currSlot.onAfterUpdate += UpdateUI;
    }
    private void OnDisable()
    {
        if(currSlot != null)
        {
            currSlot.onAfterUpdate -= UpdateUI;
        }
    }
    public void UpdateUI(InvSlot _slot)
    {
        if(_slot.item.id >= 0)
        {
            itemIMG.color = new Color(1, 1, 1, 1);
            itemIMG.sprite = _slot.GetItemObject().itemIMG;
        }
        else
        {
            itemIMG.color = new Color(1, 1, 1, 0);
        }
    }
}
