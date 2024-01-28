using UnityEngine;

public class JammerSuccessfulExitState : JammerBaseState
{
    public override void EnterState(JammerStateMachine jammerStateMachine)
    {
        Debug.Log("Jammer ran away successfully!");
        JammerManager.Instance.RemoveJammerFromList(jammerStateMachine);
        JammerManager.Instance.ReleaseToken();
        jammerStateMachine.audioController.PlaySound(jammerStateMachine.audioController.jammerEscape);
    }

    public override void ExitState(JammerStateMachine jammerStateMachine){

    }

    public override void Interact(){}

    public override void UpdateState(JammerStateMachine jammerStateMachine){
        if(!jammerStateMachine.audioController.jammerAudioSource.isPlaying){
            Object.Destroy(jammerStateMachine.gameObject);
        }
    }
}
