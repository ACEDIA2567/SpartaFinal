using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class UI_EquipmentForce_item : UI_PopUp
{
    enum Texts
    {
        ItemText = 0,
    }

    enum Buttons
    {
        ForceBtn = 0,
    }

    enum Images
    {
        ItemImg = 0,
    }

    private void Start()
    {
        Init();
    }

    string itemText, forceBtn;
    Image itemImg;

    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));
        Bind<Image>(typeof(Images));
        Bind<TextMeshProUGUI>(typeof(Texts));

        //todo :: 각 오브젝트에 값 넣기
        //Get<GameObject>((int)GamdObjects.StatName).GetComponent<TextMeshProUGUI>().text = statName;
    }

    // todo :: 버튼 눌렀을 때 장비 강화

    // todo :: 각 slot 정보 가져오기
    public void SetInfo() //, Image _statIcon
    {

    }
}
