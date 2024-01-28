public abstract class JammerBaseState : IInteractable{
    public abstract void EnterState(JammerStateMachine jammerStateMachine);
    public abstract void UpdateState(JammerStateMachine jammerStateMachine);
    public abstract void ExitState(JammerStateMachine jammerStateMachine);
    public abstract void Interact();
}
