using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject uiPanel;
    [SerializeField] private Image weaponImage;
    [SerializeField] private Image armorImage;
    [SerializeField] private Image ringImage;
    [SerializeField] private TextMeshProUGUI weaponDescription;
    [SerializeField] private TextMeshProUGUI armorDescription;
    [SerializeField] private TextMeshProUGUI ringDescription;

    private void Start()
    {
        HideUI();
    }

    public void ShowUI(Item weapon, Item armor, Item ring)
    {
        if (uiPanel != null)
        {
            if (weapon != null)
            {
                weaponImage.sprite = weapon.itemImage[0];
                weaponDescription.text = weapon.description;
            }
            else
            {
                weaponImage.sprite = null;
                weaponDescription.text = "No weapon equipped";
            }

            if (armor != null)
            {
                armorImage.sprite = armor.itemImage[0];
                armorDescription.text = armor.description;
            }
            else
            {
                armorImage.sprite = null;
                armorDescription.text = "No armor equipped";
            }

            if (ring != null)
            {
                ringImage.sprite = ring.itemImage[0];
                ringDescription.text = ring.description;
            }
            else
            {
                ringImage.sprite = null;
                ringDescription.text = "No ring equipped";
            }

            uiPanel.SetActive(true);
        }
    }

    public void HideUI()
    {
        if (uiPanel != null)
        {
            uiPanel.SetActive(false);
        }
    }

}
