using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField]
    Item[] items;

    void Start()
    {
        Init();
    }

    void Init()
    {
        // total count of equipments : 3
        items = new Item[3] { null, null, null };
        // call data from Save file
    }

    public void ReplaceItem(Item item)
    {
        items[(int)item.itemType] = item;
    }

    //public void EnchantItem(ItemType type)
    //{
    //    float p = 1f;
    //    if(items[(int)type].enchantmentLvl != 0)
    //        p = 1f / items[(int)type].enchantmentLvl;
    //    float rnd = Random.Range(0f, 1f);
    //    if (rnd < p)
    //    {
    //        items[(int)type].enchantmentLvl++;
    //    }
    //    else if (rnd < (1-p)*0.5)
    //    {
    //        items[(int)type].enchantValue--;
    //    }
    //    items[(int)type].enchantValue = 1 / p;
    //}
}