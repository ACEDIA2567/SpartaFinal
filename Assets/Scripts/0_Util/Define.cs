using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Associated with Input
public enum InputDevices
{
    Keyboard,
    Mouse,
    Gamepad,
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
    Move,
    Attack,
    Evade,
    Skill,
    SkillB,
    Count,
}

public enum AxisOptions
{
    Both,
    Horizontal,
    Vertical 
}
#endregion
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
    MainScene,
    Count,
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

public enum AttackType
{
    Normal,
    Explosive,
    Concussive,
    Spell,
    Count
}

public enum ArmorType
{
    Small,
    Medium,
    Large,
    Shield,
    Count
}

