public class StateMachine
{
    protected IState currentState;

    public void ChangeState(IState nextState)
    {
        currentState?.Exit();
        currentState = nextState;
        currentState?.Enter();
    }

//    public void Update()
//    {
//        currentState?.Update();
//    }
//
//    public void PhysicsUpdate()
//    {
//        currentState?.FixedUpdate();
//    }
}