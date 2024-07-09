using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Item")][Serializable]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite itemImage;
    public int soulCost;
    public string description;
    public ItemRarity rarity;
    public ItemType type;
    public int enchantmentLvl;
    public float enchantValue;
}

public enum ItemRarity
{
    Legendary,
    Epic,
    Rare,
    Normal,
}

public enum ItemType
{
    Weapon,
    Skin,
    Ring,
    Count,
}
