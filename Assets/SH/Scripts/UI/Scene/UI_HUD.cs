using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_HUD : UI_Scene
{
    enum Buttons
    {
        Option = 0,
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));

        GetButton((int)Buttons.Option).gameObject.BindEvent(Option);
    }

    private void Option(PointerEventData data)
    {
        Managers.UI.ShowPopupUI<UI_Options>();
    }
}
