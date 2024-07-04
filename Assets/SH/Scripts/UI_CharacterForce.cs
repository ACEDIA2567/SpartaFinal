using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_CharacterForce : UI_PopUp
{
    enum Buttons
    {
        ExitBtn = 0,
    }

    private void Start()
    {
         Init();
    }

    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));

        Get<Button>((int)Buttons.ExitBtn).gameObject.BindEvent(ExitBtn);

        CreateStats();
    }

    private void ExitBtn(PointerEventData data)
    {
        Debug.Log("눌림");
        ClosePopupUI();
    }

    private void CreateStats()
    {
        for(int i = 0; i < 2; i++)
        {
            Debug.Log("스탯강화ui 생성");
        }
    }

    
}
