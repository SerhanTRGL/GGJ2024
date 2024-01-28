using UnityEngine;
using Pathfinding;

public class JammerStateMachine : MonoBehaviour, IInteractable{
    JammerBaseState currentState;
    public JammerWorkingState workingState = new JammerWorkingState();
    public JammerRunningState runningState = new JammerRunningState();
    public JammerSuccessfulExitState successfulExitState = new JammerSuccessfulExitState();
    public JammerCaptiveState captiveState = new JammerCaptiveState();
    public Chair jammerChair;
    public Path path;
    public int currentWaypoint = 0;
    public bool reachedEndOfPath = false;
    public Seeker seeker;
    public Rigidbody2D jammerRb;
    public Transform exitPoint;
    
    private void Start() {
        seeker = GetComponent<Seeker>();
        jammerRb = GetComponent<Rigidbody2D>();
        JammerManager.Instance.AddJammerToList(this);
        exitPoint = GameObject.FindGameObjectWithTag("Exit").transform;
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

    public void Interact()
    {
        currentState.Interact();
    }
}
