using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Maintenance : UI_Scene
{
    enum Texts
    {
        LevelCnt,
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

    public void UpdatePlayerStatUI(PointerEventData data)
    {
        PlayerStatHandler statHandler = Managers.Game.player.StatHandler;
        int lv =     (statHandler.GetStat(StatSpecies.LV) as StatInt).value;
        int curExp = (statHandler.GetStat(StatSpecies.Exp) as StatInt).value;
        int maxExp = (statHandler.GetStat(StatSpecies.MaxExp) as StatInt).value;
        int soulCount = Managers.Game.player.Inventory.soulCount;

        GetImage((int)Images.LevelAmount).fillAmount = (float)curExp / maxExp;
        Debug.Log((float)curExp/maxExp);
    }
}
