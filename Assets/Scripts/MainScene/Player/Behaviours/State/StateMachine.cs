public class StateMachine
{
    public IState previousState { get; private set; }
    protected IState currentState;

    public void ChangeState(IState nextState)
    {
        if (currentState != nextState)
        {
            currentState?.Exit();
            previousState = currentState;
            currentState = nextState;
            currentState?.Enter();
        }
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