using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UI_Start : UI_Scene
{
    enum Texts
    {
        Title = 0,
    }
    enum Buttons
    {
        GamePlay = 0,
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        Bind<TextMeshProUGUI>(typeof(Texts));
        Bind<Button>(typeof(Buttons));

        GetButton((int)Buttons.GamePlay).gameObject.BindEvent(GamePlay);
    }

    private void GamePlay(PointerEventData data)
    {
        Managers.Scene.LoadScene(SceneType.MaintenanceScene_SH);
    }

}
