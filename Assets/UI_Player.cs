using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Player : UI_Scene
{
    enum Images
    {
        BackImg = 0,
        Joystick,
    }

    enum Buttons
    {
        AttackBtn = 0,
        InteractBtn,
        SkillBtn_1,
        SkillBtn_2,
    }

    private void Start()
    {
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
        Debug.Log(sceneName);
        if (sceneName == "Battle_SH")
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
        // todo :: 스킬2 Action
        Debug.Log("스킬2");
    }

    private void SkillBtn_1(PointerEventData data)
    {
        // todo :: 스킬1 Action
        Debug.Log("스킬1");
    }

    private void InteractBtn(PointerEventData data)
    {
        // todo :: 상호작용
        Debug.Log("상호작용");
    }

    private void AttackBtn(PointerEventData data)
    {
        // todo :: Attack Action
        Debug.Log("공격");
    }
}
