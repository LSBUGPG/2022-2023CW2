using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilterButton : MonoBehaviour
{
    public ItemCategories _itemFilter;
    public bool showAllButton = false;
    public Color selectedColour = new Color(0, 0, 0, 0);
    public Color deselectedColour = new Color(0, 0, 0, .5f);
    public Image gfx;
    public DynamicInterface invInterface;
    private void OnEnable()
    {
        invInterface.onRedraw += UpdateUI;
    }
    private void OnDisable()
    {
        invInterface.onRedraw -= UpdateUI;
    }
    public void SelectFilter()
    {
        if (showAllButton)
        {
            invInterface.CreateSlots();
            return;
        }
        invInterface.CreateSlotsFiltered(_itemFilter);
    }
    public void UpdateUI()
    {
        if (invInterface.filtered)
        {
            if (showAllButton) { gfx.color = deselectedColour; return; }
            switch (invInterface.currFilter)
            {
                case ItemCategories.Weapon:
                    if(_itemFilter == ItemCategories.Weapon)
                    {
                        gfx.color = selectedColour;
                    }
                    else
                    {
                        gfx.color = deselectedColour;
                    }
                    return;
                case ItemCategories.Armour:
                    if (_itemFilter == ItemCategories.Armour)
                    {
                        gfx.color = selectedColour;
                    }
                    else
                    {
                        gfx.color = deselectedColour;
                    }
                    return;
                case ItemCategories.CurseStone:
                    if (_itemFilter == ItemCategories.CurseStone)
                    {
                        gfx.color = selectedColour;
                    }
                    else
                    {
                        gfx.color = deselectedColour;
                    }
                    return;
                case ItemCategories.Hybrid:
                    if (_itemFilter == ItemCategories.Hybrid)
                    {
                        gfx.color = selectedColour;
                    }
                    else
                    {
                        gfx.color = deselectedColour;
                    }
                    return;
                case ItemCategories.Henchmen:
                    if (_itemFilter == ItemCategories.Henchmen)
                    {
                        gfx.color = selectedColour;
                    }
                    else
                    {
                        gfx.color = deselectedColour;
                    }
                    return;
            }
        }
        else
        {
            if (showAllButton) { gfx.color = selectedColour; return; }
            else { gfx.color = deselectedColour; }
        }
    }
}
