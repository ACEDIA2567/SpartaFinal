using System;
using UnityEngine;

public class PlayerInteractionYJ : MonoBehaviour
{
    public float activationDistance;
    GameObject targetObject;
    public CanvasGroup actionButtonCanvasGroup;

    UIController uiController;

    void Start()
    {
        activationDistance = 5f;
        uiController = FindObjectOfType<UIController>();
        actionButtonCanvasGroup = FindObjectOfType<CanvasGroup>();
        SetButtonState(false);
    }

    void Update()
    {
        if (targetObject != null && actionButtonCanvasGroup != null)
        {
            float distance = Vector3.Distance(transform.position, targetObject.transform.position);
            if (distance <= activationDistance)
                SetButtonState(true);
            else
            {
                SetButtonState(false);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerInventory inventory = Managers.Game.player.Inventory;
        if (other.gameObject.CompareTag("UI"))
        {
            uiController.ShowUI(
                inventory.GetEquippedItem(ItemType.Weapon),
                inventory.GetEquippedItem(ItemType.Armor),
                inventory.GetEquippedItem(ItemType.Ring)
                );
            SetButtonState(true);
        }
        
        if(other.gameObject.name == "Alchemist_idle_0")
            SetButtonState(true);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("UI"))
            uiController.HideUI();
        if(other.gameObject.name == "Alchemist_idle_0")
            SetButtonState(false);
    }

    void SetButtonState(bool isActive)
    {
        if (isActive)
        {
            actionButtonCanvasGroup.alpha = 1f;
            actionButtonCanvasGroup.interactable = true;
            actionButtonCanvasGroup.blocksRaycasts = true;
        }
        else
        {
            actionButtonCanvasGroup.alpha = .2f;
            actionButtonCanvasGroup.interactable = false;
            actionButtonCanvasGroup.blocksRaycasts = false;
        }
    }
}