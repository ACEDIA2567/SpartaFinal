using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerInventory : MonoBehaviour
{
    public int soulCount;
    [SerializeField]
    public Item[] items;

    Dictionary<ItemType, SpriteRenderer[]> renderers;
//    SpriteRenderer[] renderers;

    void Start()
    {
        Init();
        Managers.Game.player.Inventory = this;
    }

    void Init()
    {
        soulCount = 1000;
        // total count of equipments : 3
        items = new Item[Enum.GetNames(typeof(ItemType)).Length];
        renderers = new Dictionary<ItemType, SpriteRenderer[]>();
        renderers[ItemType.Weapon] = new SpriteRenderer[2];
        renderers[ItemType.Weapon][0] =
            Util.FindChild<SpriteRenderer>(Managers.Game.player.gameObject, "L_Weapon", true);
        renderers[ItemType.Weapon][1] =
            Util.FindChild<SpriteRenderer>(Managers.Game.player.gameObject, "R_Weapon", true);
        
        renderers[ItemType.Armor] = new SpriteRenderer[3];
        renderers[ItemType.Armor][0] = 
            Util.FindChild<SpriteRenderer>(Managers.Game.player.gameObject, "BodyArmor", true);
        renderers[ItemType.Armor][1] = 
            Util.FindChild<SpriteRenderer>(Managers.Game.player.gameObject, "21_LCArm", true);
        renderers[ItemType.Armor][2] = 
            Util.FindChild<SpriteRenderer>(Managers.Game.player.gameObject, "-19_RCArm", true);
        
        renderers[ItemType.Ring] = null;

        // call data from Save file
    }

    public void GiveSoul(int amount)
    {
        soulCount += amount;
    }

    public void ReplaceItem(Item item)
    {
        if (soulCount >= item.soulCost)
        {
            soulCount -= item.soulCost;
            items[(int)item.itemType] = item;
            EquipAll();
        }
        else
        {
            Debug.Log($"You don't have enough soul counts to buy {item.itemName}");
        }
    }

    void EquipAll()
    {
        foreach (var item in items)
            Equip(item);
    }

    public void Equip(Item item)
    {
        items[(int)item.itemType] = item; // store item on the player inventory
        if (item.itemType == ItemType.Ring) 
            return; // how do I show the ring image with the SPUM prefab?
        else if (item.itemType == ItemType.Armor)
        {
            renderers[ItemType.Armor][0].sprite = item.itemImage[0];
            renderers[ItemType.Armor][1].sprite = item.itemImage[1];
            renderers[ItemType.Armor][2].sprite = item.itemImage[2];
        }
        else
        {
            renderers[ItemType.Weapon][1].sprite = item.itemImage[0];
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