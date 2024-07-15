using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Result : UI_PopUp
{
    enum Texts
    {
        Title = 0,
        AcquiredSoul,
        AcquiredLevel,

    }
    enum Buttons
    {
        BackToMaintenance = 0
    }

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));
        Bind<TextMeshProUGUI>(typeof(Texts));

        GetButton((int)Buttons.BackToMaintenance).gameObject.BindEvent(BackToMaintenance);
    }

    private void BackToMaintenance(PointerEventData data)
    {
        Managers.Scene.LoadScene(SceneType.MaintenanceScene);
    }
}
