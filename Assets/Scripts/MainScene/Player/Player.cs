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

    private void Start()
    {
        Managers.Game.player = this;
        StateHandler = new PlayerStateHandler();
    }
}