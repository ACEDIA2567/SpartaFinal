using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Store_Item : UI_PopUp
{
    enum Texts
    {
        ItemText = 0,
        CostText
    }

    enum Buttons
    {
        UI_Store_Item = 0,
    }

    enum Images
    {
        ItemImg = 0,
    }

    string itemText, forceBtn, costText;
    Image itemImg;

    void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));
        Bind<TextMeshProUGUI>(typeof(Texts));
        Bind<Image>(typeof(Images));

        //todo :: 각 오브젝트에 값 넣기
        //Get<GameObject>((int)GamdObjects.StatName).GetComponent<TextMeshProUGUI>().text = statName;

        GetButton((int)Buttons.UI_Store_Item).gameObject.BindEvent(item);
    }

    private void item(PointerEventData data)
    {
        Debug.Log("아이템 구매");
    }

    // todo :: 버튼 눌렀을 때 장비 강화

    // todo :: 각 slot 정보 가져오기
    public void SetInfo() //, Image _statIcon
    {

    }
}
