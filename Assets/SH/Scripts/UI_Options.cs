using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Options : UI_PopUp
{
    enum Buttons
    {
        Option = 0,
        ExitGame,
        ExitBtn,
    }

    private void Start()
    {
        Init();
    }
    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));

        GetButton((int)Buttons.Option).gameObject.BindEvent(Option);
        GetButton((int)Buttons.ExitGame).gameObject.BindEvent(ExitGame);
        GetButton((int)Buttons.ExitBtn).gameObject.BindEvent(ExitBtn);
    }

    private void ExitBtn(PointerEventData data)
    {
        base.ClosePopupUI();
    }

    private void ExitGame(PointerEventData data)
    {
        Managers.Scene.LoadScene(SceneType.StartScene);
    }

    private void Option(PointerEventData data)
    {
        //Managers.UI.ShowPopupUI<ui_options_sound>();
    }

}
