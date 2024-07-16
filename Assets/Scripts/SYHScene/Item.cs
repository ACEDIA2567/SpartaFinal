using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public enum ItemType { Weapon, Armor, Ring }
public enum ItemType { Weapon, Armor, Ring, Test } //Test
public enum ArmorPart{Body,Left,Right}
public enum ItemRarity { Normal, Rare, Epic, Legendary, Test }

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite[] itemImage;
    public string description;
    public ItemType itemType;
    public ItemRarity rarity;
    public int soulCost;
}
