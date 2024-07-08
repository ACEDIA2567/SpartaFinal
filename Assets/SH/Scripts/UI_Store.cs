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
    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));
        Bind<GameObject>(typeof(GameObjects));

        MakeSlots();

        GetButton((int)Buttons.RerollBtn).gameObject.BindEvent(RerollBtn);
        GetButton((int)Buttons.ExitBtn).gameObject.BindEvent(ExitBtn);
    }

    private void ExitBtn(PointerEventData data)
    {
        base.ClosePopupUI();
    }

    private void RerollBtn(PointerEventData data)
    {
        // todo :: Reroll
        Debug.Log("Reroll");
    }
    private void MakeSlots()
    {
        GameObject slots = Get<GameObject>((int)GameObjects.StoreSlots);

        // 패널 초기화
        foreach (Transform child in slots.transform)
            Managers.Resource.Destroy(child.gameObject);

        for (int i = 0; i < 3; i++)
        {
            GameObject stat = Managers.UI.MakeItems<UI_Store_Item>(parent: slots.transform).gameObject;

            UI_Store_Item storeItem = stat.GetOrAddComponent<UI_Store_Item>();
            storeItem.SetInfo();
        }
    }
}
