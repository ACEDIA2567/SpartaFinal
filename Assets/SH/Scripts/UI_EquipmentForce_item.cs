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

        //todo :: �� ������Ʈ�� �� �ֱ�
        //Get<GameObject>((int)GamdObjects.StatName).GetComponent<TextMeshProUGUI>().text = statName;
    }

    // todo :: ��ư ������ �� ��� ��ȭ

    // todo :: �� slot ���� ��������
    public void SetInfo() //, Image _statIcon
    {

    }
}
