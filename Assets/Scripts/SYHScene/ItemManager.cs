using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private List<Item> items; // 36개의 아이템 목록

    public List<Item> GetRandomItems(int count)
    {
        List<Item> selectedItems = new List<Item>();
        for (int i = 0; i < count; i++)
        {
            selectedItems.Add(GetRandomItem());
        }
        return selectedItems;
    }

    private Item GetRandomItem()
    {
        float rand = Random.Range(0f, 1f);
        ItemRarity selectedRarity;

        if (rand <= 0.02f) selectedRarity = ItemRarity.Legendary;
        else if (rand <= 0.12f) selectedRarity = ItemRarity.Epic;
        else if (rand <= 0.27f) selectedRarity = ItemRarity.Rare;
        else selectedRarity = ItemRarity.Normal;

        List<Item> filteredItems = items.FindAll(item => item.rarity == selectedRarity);
        return filteredItems[Random.Range(0, filteredItems.Count)];
    }
}
