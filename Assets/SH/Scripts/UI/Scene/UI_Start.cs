using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UI_Start : UI_Scene
{
    enum Texts
    {
        StartMessage = 0,
    }
    enum Images
    {
        BackBoard = 0,
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        Bind<Image>(typeof(Images));
        Bind<TextMeshProUGUI>(typeof(Texts));

        GetImage((int)Images.BackBoard).gameObject.BindEvent(BackBoard);
    }

    private void BackBoard(PointerEventData data)
    {
        Managers.Scene.LoadScene(SceneType.MaintenanceScene);
    }

}
