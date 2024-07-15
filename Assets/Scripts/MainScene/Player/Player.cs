using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public bool isMoving;
    public bool isAttacking;
    public PlayerInputHandler InputHandler { get; set; }
    public PlayerStateHandler StateHandler { get; set; }
    public PlayerStatHandler StatHandler { get; set; }
    public PlayerInventory Inventory { get; set; }
    public SPUM_Prefabs SpumPrefabs { get; private set; }

    private void Start()
    {
        Managers.Game.player = this;
        StateHandler = new PlayerStateHandler();
        StatHandler = new PlayerStatHandler();
        
        // SPUM test
        SpumPrefabs = GetComponentInChildren<SPUM_Prefabs>();
        SPUM_Prefabs spumPrefabs = GetComponentInChildren<SPUM_Prefabs>();
        AnimationClip[] clips = spumPrefabs.AnimationClips;
        spumPrefabs.PlayAnimation("Attack_Normal");
        AnimatorClipInfo[] clipInfos = spumPrefabs._anim.GetCurrentAnimatorClipInfo(0);
        Debug.Log(clipInfos.Length);
    }
}