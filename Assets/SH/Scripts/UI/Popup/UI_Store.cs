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

    // �����丵 : setactive(false)�� �ٲ㼭 �� ��ũ��Ʈ���� �� ������ �ؾ���
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
        Managers.UI.storeSaveItems = currentItems; // ���� ������ ����Ʈ ����

        base.ClosePopupUI();
    }

    private void RerollBtn(PointerEventData data)
    {
        Reroll();
    }

    /// <summary>
    /// ���� ��ư
    /// </summary>
    private void Reroll()
    {
        RefreshItems();
        MakeSlots();
    }

    /// <summary>
    /// ������ ���� ����
    /// </summary>
    private void RefreshItems()
    {
        currentItems = ItemManager.Instance.GetRandomItems(3);
    }

    /// <summary>
    /// item slot ����
    /// </summary>
    private void MakeSlots()
    {
        GameObject slots = Get<GameObject>((int)GameObjects.StoreSlots);

        // �г� �ʱ�ȭ
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
