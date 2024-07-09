using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayStatus : MonoBehaviour
{
    private Item equippedWeapon;
    private Item equippedArmor;
    private Item equippedRing;

    public void EquipItem(Item newItem)
    {
        switch (newItem.itemType)
        {
            case ItemType.Weapon:
                equippedWeapon = newItem;
                Debug.Log("무기 장착: " + newItem.itemName);
                break;
            case ItemType.Armor:
                equippedArmor = newItem;
                Debug.Log("외피 장착: " + newItem.itemName);
                break;
            case ItemType.Ring:
                equippedRing = newItem;
                Debug.Log("반지 장착: " + newItem.itemName);
                break;
        }
    }

    public Item GetEquippedItem(ItemType itemType)
    {
        return itemType switch
        {
            ItemType.Weapon => equippedWeapon,
            ItemType.Armor => equippedArmor,
            ItemType.Ring => equippedRing,
            _ => null,
        };
    }
}
