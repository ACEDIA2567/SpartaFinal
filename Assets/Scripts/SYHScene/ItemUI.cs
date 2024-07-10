using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemUI : MonoBehaviour
{
    [SerializeField] private ItemManager itemManager;
    [SerializeField] private PlayStatus playerStatus;
    [SerializeField] private Image[] itemImages;
    [SerializeField] private TextMeshProUGUI[] itemSoulCosts;
    [SerializeField] private TextMeshProUGUI[] itemDescriptions;
    [SerializeField] private Button[] itemButtons;
    [SerializeField] private Button rerollButton; // 리롤 버튼 추가

    private List<Item> currentItems;

    private void Start()
    {
        RefreshItems();
        rerollButton.onClick.AddListener(OnRefreshButtonClicked);
    }

    public void OnRefreshButtonClicked()
    {
        RefreshItems();
    }

    private void RefreshItems()
    {
        currentItems = itemManager.GetRandomItems(3);

        for (int i = 0; i < itemButtons.Length; i++)
        {
            itemButtons[i].onClick.RemoveAllListeners();
            itemImages[i].sprite = null;
            itemSoulCosts[i].text = "";
            itemDescriptions[i].text = "";

            ItemType itemType = (ItemType)i;  // 무기, 방어구, 반지에 해당하는 아이템만 표시
//            Item item = currentItems.Find(it => it.itemType == itemType);
            Item item = currentItems[i];

            if (item != null)
            {
                itemImages[i].sprite = item.itemImage;
                itemSoulCosts[i].text = item.soulCost.ToString();
                itemDescriptions[i].text = item.description;
                itemButtons[i].onClick.AddListener(() => OnItemButtonClicked(item));
                itemButtons[i].gameObject.SetActive(true);
            }
            else
            {
                itemButtons[i].gameObject.SetActive(false);
            }
        }
    }

    private void OnItemButtonClicked(Item item)
    {
        if (item != null)
        {
            // style of YH
            playerStatus?.EquipItem(item);
            // style of YJ
            Managers.Game.player.Inventory?.ReplaceItem(item);
            Debug.Log("아이템 구매: " + item.itemName + ", 비용: " + item.soulCost + " 영혼");

        }
        else
        {
            Debug.LogWarning("장착된아이템이 없습니다.");
        }
    }
}
