using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maintenance : BaseScene
{
    protected override void Init()
    {
        base.Init();

        SceneType = SceneType.MaintenanceScene;

        Managers.UI.ShowSceneUI<UI_Maintenance>();
        Managers.UI.ShowHUD<UI_HUD>();
    }


    public override void Clear()
    {

    }
}
