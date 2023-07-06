[System.Serializable]
public class ItemData
{
    public string itemName;
    public int id = -1;
    public ItemData()
    {
        itemName = "";
        id = -1;
    }
    public ItemData(ItemSO item)
    {
        itemName = item.name;
        id = item.data.id;
    }
}
