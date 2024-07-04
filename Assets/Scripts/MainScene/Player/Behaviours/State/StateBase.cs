using System;
using System.Collections.Generic;

public abstract class StateBase : IState
{
    protected StateMachine stateMachine;

    public StateBase(StateMachine stateMachine) => this.stateMachine = stateMachine;

    public abstract void Enter();

    public abstract void Exit();
}