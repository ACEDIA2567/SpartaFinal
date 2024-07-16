using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Maintenance : UI_Scene
{
    enum Texts
    {
        SoulCnt = 0,
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
        
        // yjkim
        EquipWeaponT1N,
        EquipWeaponT1R,
        EquipWeaponT2E,
        EquipWeaponT2L,
        EquipArmorT1,
        EquipArmorT2,
        EquipRing,
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
        
//        GetButton((int)Buttons.Test).gameObject.BindEvent(UpdatePlayerStatUI);
        GetButton((int)Buttons.EquipWeaponT1N).gameObject.BindEvent(EquipWT1N);
        GetButton((int)Buttons.EquipWeaponT1R).gameObject.BindEvent(EquipWT1R);
        GetButton((int)Buttons.EquipWeaponT2E).gameObject.BindEvent(EquipWT2E);
        GetButton((int)Buttons.EquipWeaponT2L).gameObject.BindEvent(EquipWT2L);
        GetButton((int)Buttons.EquipArmorT1).gameObject.BindEvent(EquipAT1);
        GetButton((int)Buttons.EquipArmorT2).gameObject.BindEvent(EquipAT2);
    }

    void EquipAT1(PointerEventData obj)
    {
        Item item = Managers.Resource.Load<Item>("ItemData/ItemArmorT1");
        Managers.Game.player.Inventory.Equip(item);
    }

    void EquipAT2(PointerEventData obj)
    {
        Item item = Managers.Resource.Load<Item>("ItemData/ItemArmorT2");
        Managers.Game.player.Inventory.Equip(item);
    }

    void EquipWT1N(PointerEventData obj)
    {
        Item item = Managers.Resource.Load<Item>("ItemData/ItemWeaponT1N");
        Managers.Game.player.Inventory.Equip(item);
    }
    
    void EquipWT1R(PointerEventData obj)
    {
        Item item = Managers.Resource.Load<Item>("ItemData/ItemWeaponT1R");
        Managers.Game.player.Inventory.Equip(item);
    }

    void EquipWT2E(PointerEventData obj)
    {
        Item item = Managers.Resource.Load<Item>("ItemData/ItemWeaponT2E");
        Managers.Game.player.Inventory.Equip(item);
    }

    void EquipWT2L(PointerEventData obj)
    {
        Item item = Managers.Resource.Load<Item>("ItemData/ItemWeaponT2L");
        Managers.Game.player.Inventory.Equip(item);
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
        int lv =     statHandler.GetStat<int>(StatSpecies.LV).value;
        int curExp = statHandler.GetStat<int>(StatSpecies.Exp).value;
        int maxExp = statHandler.GetStat<int>(StatSpecies.MaxExp).value;
        int soulCount = Managers.Game.player.Inventory.soulCount;

        Get<TextMeshProUGUI>((int)Texts.SoulCnt).text = $"{soulCount} 소울";
        Get<TextMeshProUGUI>((int)Texts.LevelCnt).text = $"{lv} LV";
        GetImage((int)Images.LevelAmount).fillAmount = (float)curExp / maxExp;
        Debug.Log((float)curExp/maxExp);
    }
}
