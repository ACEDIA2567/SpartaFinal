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
    Sprite itemImg;

    Item item;

    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));
        Bind<Image>(typeof(Images));
        Bind<TextMeshProUGUI>(typeof(Texts));

        //todo :: 각 오브젝트에 값 넣기
        //GetText((int)Texts.ItemText).GetComponent<TextMeshProUGUI>().text = itemText;
        //GetImage((int)Images.ItemImg).GetComponent<Image>().sprite = itemImg;
    }

    public void SetInfo(Item _item)
    {
        //itemText = _item.itemName;
        //itemImg = _item.itemImage;
    }
}
