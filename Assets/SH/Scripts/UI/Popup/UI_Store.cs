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

    // 리팩토링 : setactive(false)로 바꿔서 이 스크립트에서 다 끝내게 해야함
    private List<Item> currentItems;
    private List<Item> saveItems;

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        // UI
        Bind<Button>(typeof(Buttons));
        Bind<GameObject>(typeof(GameObjects));

        GetButton((int)Buttons.RerollBtn).gameObject.BindEvent(RerollBtn);
        GetButton((int)Buttons.ExitBtn).gameObject.BindEvent(ExitBtn);

        // Feature
        saveItems = Managers.UI.storeSaveItems;

        if (saveItems != null)
        {
            currentItems = saveItems;
            MakeSlots();
        }
        else
        {
            Reroll();
        }
    }

    private void ExitBtn(PointerEventData data)
    {
        Managers.UI.storeSaveItems = currentItems; // 현재 아이템 리스트 저장

        base.ClosePopupUI();
    }

    private void RerollBtn(PointerEventData data)
    {
        Reroll();
    }

    /// <summary>
    /// 리롤 버튼
    /// </summary>
    private void Reroll()
    {
        RefreshItems();
        MakeSlots();
    }

    /// <summary>
    /// 아이템 랜덤 생성
    /// </summary>
    private void RefreshItems()
    {
        currentItems = ItemManager.Instance.GetRandomItems(3);
    }

    /// <summary>
    /// item slot 생성
    /// </summary>
    private void MakeSlots()
    {
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
