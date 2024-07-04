using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite itemImage;
    public int soulCost;
    public string description;
    public ItemRarity rarity;
}

public enum ItemRarity
{
    Normal,
    Rare,
    Epic,
    Legendary
}
