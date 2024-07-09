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
        NewGame = 0,
        GamePlay,
        Options,
        Exit,
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

        GetButton((int)Buttons.NewGame).gameObject.BindEvent(NewGame);
        GetButton((int)Buttons.GamePlay).gameObject.BindEvent(GamePlay);
        GetButton((int)Buttons.Options).gameObject.BindEvent(Options);
        GetButton((int)Buttons.Exit).gameObject.BindEvent(Exit);
    }

    private void Options(PointerEventData data)
    {
        Managers.UI.ShowPopupUI<UI_Options>();
    }

    private void Exit(PointerEventData data)
    {
        Managers.Scene.ExitGame();
    }

    private void GamePlay(PointerEventData data)
    {
        Managers.Scene.LoadScene(SceneType.MaintenanceScene);
    }

    private void NewGame(PointerEventData data)
    {
        Managers.Scene.LoadScene(SceneType.MaintenanceScene);
    }
}
