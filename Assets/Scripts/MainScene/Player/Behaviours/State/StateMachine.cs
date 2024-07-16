public class StateMachine
{
    public IState previousState { get; private set; }
    protected IState currentState;

    public StateMachine()
    {
        previousState = new StateIdle(this);
        currentState = new StateIdle(this);
    }
    public void ChangeState(IState nextState)
    {
        if (currentState != nextState &&
            nextState.CanTransitState(currentState))
        {
            currentState?.Exit();
            previousState = currentState;
            currentState = nextState;
            currentState?.Enter();
        }
    }

    // Debugging method
    public string GetCurrentState() => currentState.GetType().ToString();
}