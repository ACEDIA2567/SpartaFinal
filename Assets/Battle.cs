using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : BaseScene
{
    protected override void Init()
    {
        base.Init();

        SceneType = SceneType.Battle_SH;

        Managers.UI.ShowSceneUI<UI_Player>();
        Managers.UI.ShowHUD<UI_HUD>();
    }


    public override void Clear()
    {

    }
}
