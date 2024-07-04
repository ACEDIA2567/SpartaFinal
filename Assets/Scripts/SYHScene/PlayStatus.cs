using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayStatus : MonoBehaviour
{
    public Item equippedItem;

    public void EquipItem(Item item)
    {
        equippedItem = item;
       
        Debug.Log("현재 장착 아이템: " + item.itemName);
    }
}
