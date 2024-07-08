using System;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Maintenance : UI_Scene
{
    enum Texts
    {
        Soul = 0,
        Level,
    }

    enum Images
    {
        LevelAmount = 0
    }

    enum Buttons
    {
        CharacterForce = 0,
        EquipmentForce,
        Store,
        VillageAttack,
    }

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        Bind<TextMeshProUGUI>(typeof(Texts));
        Bind<Image>(typeof(Images));
        Bind<Button>(typeof(Buttons));

        GetButton((int)Buttons.CharacterForce).gameObject.BindEvent(CharactoerForce);
        GetButton((int)Buttons.EquipmentForce).gameObject.BindEvent(EquipmentForce);
        GetButton((int)Buttons.Store).gameObject.BindEvent(Store);
        GetButton((int)Buttons.VillageAttack).gameObject.BindEvent(VillageAttack);
    }

    private void VillageAttack(PointerEventData data)
    {
        Managers.UI.ShowPopupUI<UI_VillageAttack>();
    }

    private void Store(PointerEventData data)
    {
        Managers.UI.ShowPopupUI<UI_Store>();
    }

    private void EquipmentForce(PointerEventData data)
    {
        Managers.UI.ShowPopupUI<UI_EquipmentForce>();
    }

    private void CharactoerForce(PointerEventData data)
    {
        Managers.UI.ShowPopupUI<UI_CharacterForce>();
    }
}
