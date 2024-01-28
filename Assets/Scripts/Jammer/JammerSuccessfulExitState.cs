using UnityEngine;

public class JammerSuccessfulExitState : JammerBaseState
{
    public override void EnterState(JammerStateMachine jammerStateMachine)
    {
        Debug.Log("Jammer ran away successfully!");
        JammerManager.Instance.RemoveJammerFromList(jammerStateMachine);
        JammerManager.Instance.ReleaseToken();
        Object.Destroy(jammerStateMachine.gameObject);
    }

    public override void ExitState(JammerStateMachine jammerStateMachine){}

    public override void Interact(){}

    public override void UpdateState(JammerStateMachine jammerStateMachine){}
}
