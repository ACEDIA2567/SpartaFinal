using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Maintenance : UI_Scene
{
    enum Texts
    {
        Soul = 0,
        Level,
        
        // for the state display
        CurrentState,
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
        
        Test, // for the test of stat on display
    
        GiveSoul,
        GiveExp10,
        LvlUp,
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
        
        // yjkim added
        GetButton((int)Buttons.Test).gameObject.BindEvent(UpdatePlayerStatUI);
        
//        GetButton((int)Buttons.GiveSoul).gameObject.BindEvent
//        (data => Util.GetOrAddComponent<PlayerInventory>(Managers.Game.player.gameObject).GiveSoul(10));
//        
//        GetButton((int)Buttons.GiveSoul).gameObject.BindEvent(UpdatePlayerStatUI);
        
        GetButton((int)Buttons.GiveExp10).gameObject.BindEvent
        (data => Managers.Game.player.StatHandler.AddExp(10));
        GetButton((int)Buttons.GiveExp10).gameObject.BindEvent(UpdatePlayerStatUI);
        
        GetButton((int)Buttons.LvlUp).gameObject.BindEvent
        (data => Managers.Game.player.StatHandler.LevelUp(1));
        GetButton((int)Buttons.LvlUp).gameObject.BindEvent((UpdatePlayerStatUI));
    }

    void UpdateStateText(PointerEventData obj)
    {
        Get<TextMeshProUGUI>((int)Texts.CurrentState).text = $"{Managers.Game.player.StateHandler.stateMachine.GetCurrentState()}";
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

        Get<TextMeshProUGUI>((int)Texts.Soul).text = $"{soulCount} 소울";
        Get<TextMeshProUGUI>((int)Texts.Level).text = $"{lv} LV";
        GetImage((int)Images.LevelAmount).fillAmount = (float)curExp / maxExp;
        Debug.Log((float)curExp/maxExp);
    }
}
