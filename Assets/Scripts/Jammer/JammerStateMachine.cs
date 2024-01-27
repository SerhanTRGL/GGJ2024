using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JammerStateMachine : MonoBehaviour
{
    JammerBaseState currentState;
    public JammerWorkingState workingState = new JammerWorkingState();
    public JammerRunningState runningState = new JammerRunningState();
    public JammerSuccessfulExitState exitState = new JammerSuccessfulExitState();
    public JammerCaptiveState captiveState = new JammerCaptiveState();
    public JammerStunnedState stunnedState = new JammerStunnedState();
    
    private void Start() {
        currentState = workingState;
        currentState.EnterState(this);
    }

    private void Update() {
        currentState.UpdateState(this);
    }
    
    public void SwitchState(JammerBaseState nextState){
        currentState.ExitState(this);
        currentState = nextState;
        currentState.EnterState(this);
    }
}
