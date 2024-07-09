using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : BaseScene
{
    protected override void Init()
    {
        base.Init();

        SceneType = SceneType.Start_SH;

        Managers.UI.ShowSceneUI<UI_Start>();
    }


    public override void Clear()
    {

    }
}
