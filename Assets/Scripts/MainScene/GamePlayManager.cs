using System;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    public Player player { get; set; }

    private void Start()
    {
        Managers.Game = this;
    }
}