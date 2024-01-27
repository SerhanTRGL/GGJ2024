using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class JammerBaseState{
    public abstract void EnterState(JammerStateMachine jammerStateMachine);
    public abstract void UpdateState(JammerStateMachine jammerStateMachine);
    public abstract void ExitState(JammerStateMachine jammerStateMachine);
    public abstract void Interact(JammerStateMachine jammerStateMachine);
}
