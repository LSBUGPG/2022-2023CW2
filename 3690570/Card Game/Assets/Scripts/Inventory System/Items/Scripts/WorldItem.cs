using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldItem : MonoBehaviour
{
    public ItemSO item;
    public SpriteRenderer gfx;
    private void Awake()
    {
        if(item != null)
        {
            Setup(item);
        }
    }
    public void Setup(ItemSO _item)
    {
        item = _item;
        gfx.sprite = item.itemIMG;
    }
    private void Update()
    {
        gfx.transform.LookAt(Camera.main.transform, Vector3.up);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("World Item Triggered");
        if(other.TryGetComponent(out PlayerInventory pInv))
        {
            Debug.Log("World Item found player inventory");
            Destroy(gameObject); //May prevent code from running below
            if(item != null)
            {
                pInv.inv.AddItem(item);
            }
        }
    }
}
