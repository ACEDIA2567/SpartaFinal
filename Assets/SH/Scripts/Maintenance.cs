using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maintenance : BaseScene
{
    protected override void Init()
    {
        base.Init();

        SceneType = SceneType.MaintenanceScene_SH;

        Managers.UI.ShowSceneUI<UI_Maintenance>();
        Managers.UI.ShowHUD<UI_HUD>();
        Managers.UI.ShowSceneUI<UI_Player>();
    }


    public override void Clear()
    {

    }
}
