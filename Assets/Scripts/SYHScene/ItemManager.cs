using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;

    [SerializeField] private List<Item> items;
    public Item none;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }

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
        ItemRarity selectedRarity = GetRandomRarity();
        List<Item> filteredItems = items.FindAll(item => item.rarity == selectedRarity);

        // ???? ???? ???? ?? ??, ?? ??
        while (filteredItems.Count == 0)
        {
            selectedRarity = GetRandomRarity();
            filteredItems = items.FindAll(item => item.rarity == selectedRarity);
        }

        return filteredItems[Random.Range(0, filteredItems.Count)];
    }

    private ItemRarity GetRandomRarity()
    {
        float rand = Random.Range(0f, 1f);

        if (rand <= 0.02f) return ItemRarity.Legendary;
        else if (rand <= 0.12f) return ItemRarity.Epic;
        else if (rand <= 0.27f) return ItemRarity.Rare;
        else return ItemRarity.Normal;
    }
}
