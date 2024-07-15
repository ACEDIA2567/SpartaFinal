using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class UI_EquipmentForce : UI_PopUp
{
    enum GameObjects
    {
        EquipmentSlots = 0,
    }

    enum Buttons
    {
        CharacterForceBtn = 0,
        ExitBtn
    }

    private List<Item> equipmentItems = new List<Item>();

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));
        Bind<GameObject>(typeof(GameObjects));

        LoadItems();

        GetButton((int)Buttons.CharacterForceBtn).gameObject.BindEvent(CharacterForceBtn);
        GetButton((int)Buttons.ExitBtn).gameObject.BindEvent(ExitBtn);

        MakeSlots();
    }

    private void LoadItems()
    {
        // todo :: 인벤토리에 있는 무기, 외피, 반지 가져오기
        for(int i = 0; i < 3; i++)
        {
            ItemType type = (ItemType)i;
            Item item = Managers.Game.player.Inventory.GetEquippedItem(type);
            equipmentItems.Add(item);
        }
    }

    private void ExitBtn(PointerEventData data)
    {
        base.ClosePopupUI();
    }

    private void CharacterForceBtn(PointerEventData data)
    {
        Managers.UI.ShowPopupUI<UI_CharacterForce>();
    }

    private void MakeSlots()
    {
        GameObject slots = Get<GameObject>((int)GameObjects.EquipmentSlots);

        // 패널 초기화
        foreach (Transform child in slots.transform)
            Managers.Resource.Destroy(child.gameObject);

        for(int i = 0; i < 3; i++)
        {
            if (equipmentItems[i] == null)
                equipmentItems[i] = ItemManager.Instance.none;

            GameObject stat = Managers.UI.MakeItems<UI_EquipmentForce_item>(parent: slots.transform).gameObject;

            UI_EquipmentForce_item equipmentStatForce = stat.GetOrAddComponent<UI_EquipmentForce_item>();
            equipmentStatForce.SetInfo(equipmentItems[i]);
        }
    }
}
