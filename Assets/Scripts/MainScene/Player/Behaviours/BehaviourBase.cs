using System;
using UnityEngine;

public abstract class BehaviourBase : MonoBehaviour
{
    protected InputBase input;
    protected StateBase state;
    protected Action action;

    public virtual void Start()
    {
        Init();
    }

    protected abstract void Init();
}