using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Player : UI_Scene
{
    enum Images
    {
        BackImg = 0,
        Joystick,
        
        // yjkim
        AttackBtn,
        InteractBtn,
        SkillBtn_1,
        SkillBtn_2,
        
    }

    enum Buttons
    {
        AttackBtn = 0,
        InteractBtn,
        SkillBtn_1,
        SkillBtn_2,
    }

    void Start()
    {
        Managers.UI.UIlist.Add(this);
        Init();
    }

    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));
        Bind<Image>(typeof(Images));

        GetButton((int)Buttons.AttackBtn).gameObject.BindEvent(AttackBtn);
        GetButton((int)Buttons.InteractBtn).gameObject.BindEvent(InteractBtn);
        GetButton((int)Buttons.SkillBtn_1).gameObject.BindEvent(SkillBtn_1);
        GetButton((int)Buttons.SkillBtn_2).gameObject.BindEvent(SkillBtn_2);

        string sceneName = SceneManager.GetActiveScene().name;
        if (sceneName == "BattleScene")
        {
            GetButton((int)Buttons.InteractBtn).gameObject.SetActive(false);
        }
        else
        {
            MaintenancePlayer();
        }

    }

    private void MaintenancePlayer()
    {
        GetButton((int)Buttons.AttackBtn).gameObject.SetActive(false);
        GetButton((int)Buttons.SkillBtn_1).gameObject.SetActive(false);
        GetButton((int)Buttons.SkillBtn_2).gameObject.SetActive(false);
        GetButton((int)Buttons.InteractBtn).gameObject.SetActive(true);
    }

    private void SkillBtn_2(PointerEventData data)
    {
        // todo :: ��ų2 Action
        Debug.Log("��ų2");
    }

    private void SkillBtn_1(PointerEventData data)
    {
        // todo :: ��ų1 Action
        Debug.Log("��ų1");
    }

    private void InteractBtn(PointerEventData data)
    {
        // todo :: ��ȣ�ۿ�
        Debug.Log("��ȣ�ۿ�");
    }

    private void AttackBtn(PointerEventData data)
    {
        // todo :: Attack Action
        Debug.Log("����");
        Managers.Game.player.SpumPrefabs.PlayAnimation(nameof(SPUM_AnimClipList.Attack_Normal));
    }

    public void ChangeImageTransparency(ActionType type, bool active)
    {
        if (type == ActionType.Attack)
        {
            Color color = GetImage((int)Images.AttackBtn).color;
            color.a = active ? 1f : 50 / 255f;
            GetImage((int)Images.AttackBtn).color = color;
        }
        else if (type == ActionType.Skill)
        {
            Color color = GetImage((int)Images.SkillBtn_1).color;
            color.a = active ? 1f : 50 / 255f;
            GetImage((int)Images.SkillBtn_1).color = color;
        }
        else if (type == ActionType.Interact)
        {
            Color color = GetImage((int)Images.InteractBtn).color;
            color.a = active ? 1f : 50 / 255f;
            GetImage((int)Images.InteractBtn).color = color;
        }
    }

    public void SetButtonActivity(ActionType type, bool active)
    {
        if (type == ActionType.Interact)
        {
            GetButton((int)Buttons.InteractBtn).enabled = active;
        }
    }
}
