using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Store : UI_PopUp
{
    enum GameObjects
    {
        StoreSlots = 0,
    }

    enum Buttons
    {
        RerollBtn = 0,
        ExitBtn
    }

    private List<Item> currentItems;

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));
        Bind<GameObject>(typeof(GameObjects));

        RefreshItems();

        GetButton((int)Buttons.RerollBtn).gameObject.BindEvent(RerollBtn);
        GetButton((int)Buttons.ExitBtn).gameObject.BindEvent(ExitBtn);
    }

    private void ExitBtn(PointerEventData data)
    {
        base.ClosePopupUI();
    }

    private void RerollBtn(PointerEventData data)
    {
        RefreshItems();
    }

    private void RefreshItems()
    {
        currentItems = ItemManager.Instance.GetRandomItems(3);

        MakeSlots(currentItems);
    }

    // ites slot 생성
    private void MakeSlots(List<Item> currentItems)
    {
        Debug.Log("MakeSlots");
        GameObject slots = Get<GameObject>((int)GameObjects.StoreSlots);

        // 패널 초기화
        foreach (Transform child in slots.transform)
            Managers.Resource.Destroy(child.gameObject);

        foreach (Item item in currentItems)
        {
            GameObject stat = Managers.UI.MakeItems<UI_Store_Item>(parent: slots.transform).gameObject;

            UI_Store_Item storeItem = stat.GetOrAddComponent<UI_Store_Item>();
            storeItem.SetInfo(item);
        }
    }
}
