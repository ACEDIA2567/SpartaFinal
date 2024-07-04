using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerInputHandler InputHandler { get; set; }
    public PlayerStateHandler StateHandler { get; set; }

    private void Start()
    {
        Managers.Game.player = this;
    }
}