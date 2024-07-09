using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemManagerTest : MonoBehaviour
{
    [SerializeField] List<Item> items;
    float[] rarityThres;
    void Start()
    {
        items = new List<Item>();
        Managers.Item = this;
        rarityThres = new float[]
        {
            .02f, // Legendary
            .12f, // Epic
            .27f  // Rare
            // else: Normal
        };
        LoadItems();
    }

    public void LoadItems()
    {
        string dir = "Assets/Scripts/SYHScene/scriptableObject";
        items = new List<Item>(); 
//        items.Add(Managers.Resource.Load<Item>(dir + "/Item1 0"));
        Debug.Log("Loading Start");
        items = Resources.LoadAll<Item>(dir).ToList();
        for(int a=0; a<items.Count; a++)
            Debug.Log(a + " " + items[a].itemName);
    }

    public Item[] GetRandomItems(int count)
    {
        Item[] selectedItems = new Item[count];
        for (int i = 0; i < count; i++)
        {
            selectedItems[i] = GetRandomItem();
        }
        return selectedItems;
    }

    Item GetRandomItem()
    {
        float rand = Random.Range(0f, 1f);
        ItemRarity rarity;
        if (rand <= rarityThres[(int)ItemRarity.Legendary])
            rarity = ItemRarity.Legendary;
        else if (rand <= rarityThres[(int)ItemRarity.Epic])
            rarity = ItemRarity.Epic;
        else if (rand <= rarityThres[(int)ItemRarity.Rare])
            rarity = ItemRarity.Rare;
        else
            rarity = ItemRarity.Normal;
        List<Item> filteredItems = items.FindAll(item => item.rarity == rarity);
        return filteredItems[Random.Range(0, filteredItems.Count)];
    }
}