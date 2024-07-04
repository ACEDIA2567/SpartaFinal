using System;
using UnityEngine;

public abstract class BehaviourBase : MonoBehaviour
{
    protected InputBase input;
    protected StateBase state;
    protected Action action;

    protected abstract void Init();
}