using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_CharacterForce : UI_PopUp
{
    enum GameObjects
    {
        Slots = 0,
    }

    enum Buttons
    {
        ExitBtn,
    }

    private void Start()
    {
         Init();
    }

    public override void Init()
    {
        base.Init();

        Bind<GameObject>(typeof(GameObjects));
        Bind<Button>(typeof(Buttons));

        GetButton((int)Buttons.ExitBtn).gameObject.BindEvent(ExitBtn); 

        MakeSlots();
    }

    private void ExitBtn(PointerEventData data)
    {
        base.ClosePopupUI();
    }

    private void MakeSlots()
    {
        GameObject slots = Get<GameObject>((int)GameObjects.Slots);
        
        // 패널 초기화
        foreach(Transform child in slots.transform)
            Managers.Resource.Destroy(child.gameObject);

        for(int i = 0; i < 3; i++)
        {
            GameObject stat = Managers.UI.MakeItems<UI_CharacterForce_Item>(parent:slots.transform).gameObject;

            UI_CharacterForce_Item characterStatForce = stat.GetOrAddComponent<UI_CharacterForce_Item>();
            characterStatForce.SetInfo("", "", "", "", 0);
        }
    }

    
}
