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
            // 먼저 버튼 리스너를 초기화하여 중복 리스너 추가를 방지
            itemButtons[i].onClick.RemoveAllListeners();

            if (i < currentItems.Count)
            {
                itemImages[i].sprite = currentItems[i].itemImage;
                itemSoulCosts[i].text = currentItems[i].soulCost.ToString();
                itemDescriptions[i].text = currentItems[i].description;
                Item item = currentItems[i]; // 현재 아이템을 로컬 변수로 저장
                itemButtons[i].onClick.AddListener(() => OnItemButtonClicked(item));
                itemButtons[i].gameObject.SetActive(true); // 버튼 활성화
            }
            else
            {
                itemImages[i].sprite = null;
                itemSoulCosts[i].text = "";
                itemDescriptions[i].text = "";
                itemButtons[i].gameObject.SetActive(false); // 버튼 비활성화
            }
        }
    }

    private void OnItemButtonClicked(Item item)
    {
        if (item != null)
        {
            playerStatus.EquipItem(item);
        }
        else
        {
            Debug.LogWarning("장착된아이템이 null입니다.");
        }
    }
}
