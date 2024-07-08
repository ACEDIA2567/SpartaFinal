using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_CharacterForce_Item : UIBase
{
    enum GamdObjects
    {
        StatIcon = 0,
        StatName,
        StatCurrentLevel,
        StatDescription,
        ChangeAmount,
        CostText,
        LevelBtn
    }

    string statName, statDescription, chageAmount, costText;
    int statCurrentLevel;
    Image statIcon;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    public override void Init()
    {
        Bind<GameObject>(typeof(GamdObjects));

        Get<GameObject>((int)GamdObjects.StatName).GetComponent<TextMeshProUGUI>().text = statName;
        Get<GameObject>((int)GamdObjects.StatCurrentLevel).GetComponent<TextMeshProUGUI>().text = statCurrentLevel.ToString();
        Get<GameObject>((int)GamdObjects.StatDescription).GetComponent<TextMeshProUGUI>().text = statDescription;
        Get<GameObject>((int)GamdObjects.ChangeAmount).GetComponent<TextMeshProUGUI>().text = chageAmount;
        Get<GameObject>((int)GamdObjects.CostText).GetComponent<TextMeshProUGUI>().text = costText;
        Get<GameObject>((int)GamdObjects.LevelBtn).BindEvent(ForceStat);
    }

    private void ForceStat(PointerEventData data)
    {
        statCurrentLevel++;
        Get<GameObject>((int)GamdObjects.StatCurrentLevel).GetComponent<TextMeshProUGUI>().text = statCurrentLevel.ToString();
    }

    public void SetInfo(string _statName, string _statDescription, string _changeAmount, string _costText, int _statCurrentLevel) //, Image _statIcon
    {
        statName = _statName;
        statDescription = _statDescription;
        chageAmount = _changeAmount;
        costText = _costText;
        statCurrentLevel = _statCurrentLevel;
    }
}
