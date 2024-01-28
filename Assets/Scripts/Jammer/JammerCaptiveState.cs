using UnityEngine;

public class JammerCaptiveState : JammerBaseState
{
    PlayerInteraction p;
    private Collider2D col;
    JammerStateMachine jammer;
    public override void EnterState(JammerStateMachine jammerStateMachine)
    {
        p = GameObject.FindWithTag("Player").GetComponent<PlayerInteraction>();
        jammerStateMachine.jammerRb.velocity = Vector2.zero;
        jammer = jammerStateMachine;
        jammer.audioController.PlaySound(jammer.audioController.jammerCaught);
    }

    public override void ExitState(JammerStateMachine jammerStateMachine){}

    public override void Interact(){
        p.currentlyHeldJammer = null;
        jammer.transform.parent = null;

        Table table;
        if(col != null){
            if(col.TryGetComponent(out table)){
                if(table != null){
                    Chair chair = table.GetEmptyChair();
                    if(chair != null){
                        chair.Sit(jammer.gameObject);
                        JammerManager.Instance.ReleaseToken();
                        jammer.audioController.PlaySound(jammer.audioController.jammerMadeSit);
                        jammer.SwitchState(jammer.workingState);
                    }
                }
                else{
                    jammer.SwitchState(jammer.runningState);
                }
            }       
        }
        else{
            jammer.SwitchState(jammer.runningState);
        }
    }

    public override void UpdateState(JammerStateMachine jammerStateMachine){
        jammerStateMachine.transform.localPosition = p.holdPoint.localPosition;
        col = Physics2D.OverlapCircle(jammerStateMachine.transform.position, 3f, LayerMask.GetMask("Desk"));
        Debug.Log(col?.name);
    }
}
