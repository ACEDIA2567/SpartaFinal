using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_VillageAttack : UI_PopUp
{
    enum Images
    {
        MapImg = 0,
    }

    enum Buttons
    {
        Village = 0,
        Market,
        City,
        Palace,
        ExitBtn
    }

    private void Start()
    {
        Init();    
    }

    public override void Init()
    {
        base.Init();

        Bind<Image>(typeof(Images));
        Bind<Button>(typeof(Buttons));

        GetButton((int)Buttons.Village).gameObject.BindEvent(Village);
        GetButton((int)Buttons.Market).gameObject.BindEvent(Market);
        GetButton((int)Buttons.City).gameObject.BindEvent(City);
        GetButton((int)Buttons.ExitBtn).gameObject.BindEvent(ExitBtn);
    }

    private void City(PointerEventData data)
    {
        // todo :: 레벨링
        Managers.Scene.LoadScene(SceneType.Battle_SH);
    }

    private void Market(PointerEventData data)
    {
        // todo :: 레벨링
        Managers.Scene.LoadScene(SceneType.Battle_SH);
    }

    private void Village(PointerEventData data)
    {
        // todo :: 레벨링
        Managers.Scene.LoadScene(SceneType.Battle_SH);
    }

    private void ExitBtn(PointerEventData data)
    {
        base.ClosePopupUI();
    }
}
