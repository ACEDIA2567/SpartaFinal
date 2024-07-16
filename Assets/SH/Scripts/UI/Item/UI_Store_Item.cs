using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Store_Item : UI_PopUp
{
    enum Texts
    {
        ItemName = 0,
        CostText
    }

    enum Buttons
    {
        UI_Store_Item = 0,
    }

    enum Images
    {
        ItemImg = 0,
    }

    string itemName, forceBtn, costText;
    Sprite itemImg;

    Item item;

    void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));
        Bind<TextMeshProUGUI>(typeof(Texts));
        Bind<Image>(typeof(Images));

        GetImage((int)Images.ItemImg).sprite = itemImg;
        GetText((int)Texts.ItemName).text = itemName;
        GetText((int)Texts.CostText).text = $"{costText}";

        GetButton((int)Buttons.UI_Store_Item).gameObject.BindEvent(BuyItem);
    }

    private void BuyItem(PointerEventData data)
    {
        if (item != null)
        {
            Managers.Game.player.Inventory?.ReplaceItem(item);
            Debug.Log("아이템 구매: " + item.itemName + ", 비용: " + item.soulCost + " 영혼");

        }
        else
        {
            Debug.LogWarning("장착된아이템이 없습니다.");
        }
    }

    public void SetInfo(Item _item)
    {
        item = _item;

        itemImg = item.itemImage;
        itemName = item.itemName;
        costText = item.soulCost.ToString();
    }
}
