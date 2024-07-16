using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteractionYJ : MonoBehaviour
{
    public float activationDistance;
    int objCnt; // objects under interaction
    GameObject targetObject;
    CapsuleCollider2D collider2D;
    (Vector2 offset,Vector2 size) defaultColliderConfig; // at battle map
    (Vector2 offset,Vector2 size) wideColliderConfig; // at home
    public bool IsHome { get; set; }
    UI_Player uiPlayer;

    void Start()
    {
        activationDistance = 5f;
        objCnt = 0;
        collider2D = GetComponent<CapsuleCollider2D>();
        defaultColliderConfig = (new Vector2(0f,0.7f), new Vector2(1f,1.3f));
        wideColliderConfig = (new Vector2(0f,0.7f), new Vector2(5f,1.3f));
        IsHome = true;
        ChangeInteractionRange(IsHome);
        uiPlayer = Managers.UI.FindUI<UI_Player>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(uiPlayer == null)
            uiPlayer = Managers.UI.FindUI<UI_Player>();
            
        if (IsHome && objCnt == 0)
        {
            uiPlayer.ChangeImageTransparency(ActionType.Interact,true);
            uiPlayer.SetButtonActivity(ActionType.Interact,true);
        }
        objCnt++;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        objCnt--;
        if (IsHome && objCnt == 0)
        {
            uiPlayer.ChangeImageTransparency(ActionType.Interact,false);
            uiPlayer.SetButtonActivity(ActionType.Interact,false);
        }
    }

    public void ChangeInteractionRange(bool ishome)
    {
        if (ishome)
        {
            collider2D.offset = wideColliderConfig.offset;
            collider2D.size = wideColliderConfig.size;
        }
        else
        {
            collider2D.offset = defaultColliderConfig.offset;
            collider2D.size = defaultColliderConfig.size;
        }
    }
    void SetButtonState(bool isActive)
    {
    }
}