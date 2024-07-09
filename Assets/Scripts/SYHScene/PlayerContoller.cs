using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    private UIController uiController;
    private PlayStatus playerStatus;

    private void Start()
    {
        uiController = FindObjectOfType<UIController>();
        playerStatus = GetComponent<PlayStatus>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("UI"))
        {
            uiController.ShowUI(
                playerStatus.GetEquippedItem(ItemType.Weapon),
                playerStatus.GetEquippedItem(ItemType.Armor),
                playerStatus.GetEquippedItem(ItemType.Ring)
            );
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag ("UI"))
        {
            uiController.HideUI();
        }
    }
}

