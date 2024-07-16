using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Options : UI_PopUp
{
    enum Buttons
    {
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

        GetButton((int)Buttons.ExitBtn).gameObject.BindEvent(ExitBtn);
    }

    private void ExitBtn(PointerEventData data)
    {
        base.ClosePopupUI();
    }

}
