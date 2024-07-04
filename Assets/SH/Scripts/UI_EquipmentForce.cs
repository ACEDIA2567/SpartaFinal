using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_EquipmentForce : UI_PopUp
{
    enum Buttons
    {
        CharacterForceBtn = 0,
        Weapon,
        Coat,
        Ring,
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

        Get<Button>((int)Buttons.CharacterForceBtn).gameObject.BindEvent(CharacterForceBtn);
    }

    private void CharacterForceBtn(PointerEventData data)
    {
        Debug.Log("버튼 눌림");
        ClosePopupUI();
    }
}
