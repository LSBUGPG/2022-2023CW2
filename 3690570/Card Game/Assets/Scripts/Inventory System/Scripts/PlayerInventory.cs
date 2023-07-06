using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public InventorySO inv, battleHand;

    private void OnApplicationQuit()
    {
        inv.Clear();
        battleHand.Clear();
    }
}
