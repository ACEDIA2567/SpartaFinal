using System;
using System.ComponentModel;
using System.Reflection;
using UnityEngine;

#region Associated with Input
public enum InputDevices
{
    Keyboard,
    Mouse,
    Gamepad,
    Count,
}

public enum JoystickMode
{
    Fixed,
    Floating,
    Count,
}
public enum InputStatus
{
    Started,
    Performed,
    Canceled,
    Count,
}
public enum ActionType
{
    Idle,
    Hit,
    Die,
    Move,
    Attack,
    Evade,
    Skill,
    Interact,
    Count,
}

public enum AxisOptions
{
    Both,
    Horizontal,
    Vertical 
}
#endregion

public enum StatSpecies
{
    LV,
    Name,
    HP,
    plusHP,
    ATKPower,
    plusATKPower,
    ATKRate,
    plusATKRate,
    Defence,
    plusDefence,
    Speed,
    plusSpeed,
    Exp,
    MaxExp,
}
// This file contains all the enums
public enum UIEvent
{
    Click,
    PointerDown,
    PointerUp,
    BeginDrag,
    Drag,
    EndDrag,
    Count
}

public enum SceneType
{
    StartScene,
    BattleScene,
    MaintenanceScene,
    Count,
    Battle_SH, //테스트
    MaintenanceScene_SH,
    Start_SH //테스트
}

#region Sound Assets
public enum Sounds
{
    BGM,
    Battle,
    Start1,
    Start2,
    Start3,
    Boom,
    Smoke,
    Bullet,
    TankOn,
    TankMove,
    DestroyOn1,
    DestroyOn2,
    DestroyOn3,
    DestroyOn4,
    HitOn1,
    HitOn2,
    HitOn3,
    Click,
    Count
}
public enum Clips
{
    BGM,
    Battle,
    Start1,
    Start2,
    Start3,
    Boom,
    Smoke,
    Bullet,
    TankOn,
    TankMove,
    DestroyOn1,
    DestroyOn2,
    DestroyOn3,
    DestroyOn4,
    HitOn1,
    HitOn2,
    HitOn3,
    Click,
    Count
}
#endregion
public enum Tags
{
    Player,
    StartLine,
    EndLine,
    Map,
    UI,
    Obstacle,
    Bullets,
    Wire,
    Destroyer,
    Count,
}
public enum LayerMasks
{
    Count,
}

public enum BuffType
{
    SPEED_UP,
}



