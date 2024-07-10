using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerInventory : MonoBehaviour
{
    public int soulCount;
    [SerializeField]
    public Item[] items;

    void Start()
    {
        Init();
        Managers.Game.player.Inventory = this;
    }

    void Init()
    {
        soulCount = 0;
        // total count of equipments : 3
        items = new Item[Enum.GetNames(typeof(ItemType)).Length];
        // call data from Save file
    }

    public void ReplaceItem(Item item)
    {
        if (soulCount >= item.soulCost)
        {
            soulCount -= item.soulCost;
            items[(int)item.itemType] = item;
        }
        else
        {
            Debug.Log($"You don't have enough soul counts to buy {item.itemName}");
        }
    }

    public Item GetEquippedItem(ItemType type) => items[(int)type];
    
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