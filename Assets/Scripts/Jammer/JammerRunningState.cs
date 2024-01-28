using Pathfinding;
using UnityEngine;
using DG.Tweening;

public class JammerRunningState : JammerBaseState
{
    JammerStateMachine jammer;
    public override void EnterState(JammerStateMachine jammerStateMachine)
    {
        waitCounter = 0;
        jammer = jammerStateMachine;
        jammer.seeker.StartPath(jammer.jammerRb.position, jammer.exitPoint.position, OnPathComplete);
    }

    private void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            jammer.path = p;
            jammer.currentWaypoint = 0;
        }
    }

    bool isTravelling = false;
    Tween tween;
    private float waitCounter;
    public override void UpdateState(JammerStateMachine jammerStateMachine)
    {
        if (waitCounter >= 0.5f)
        {
            if (jammer.path == null)
            {
                return;
            }
            if (jammer.currentWaypoint >= jammer.path.vectorPath.Count)
            {
                jammer.reachedEndOfPath = true;
                tween.Kill();
                isTravelling = false;
                jammerStateMachine.SwitchState(jammerStateMachine.successfulExitState);
                return;
            }
            else
            {
                jammer.reachedEndOfPath = false;
            }

            if (!isTravelling && !jammer.reachedEndOfPath)
            {

                tween = jammer.transform.DOMove(jammer.path.vectorPath[jammer.currentWaypoint], 0.2f)
                .SetEase(Ease.Linear)
                .OnStart(() =>
                {
                    isTravelling = true;
                })
                .OnComplete(() =>
                {
                    isTravelling = false;
                    jammer.currentWaypoint++;
                });
            }
        }
        else{
            waitCounter += Time.deltaTime;
        }
    }

    public override void ExitState(JammerStateMachine jammerStateMachine)
    {

    }
    public override void Interact()
    {
        PlayerInteraction p = GameObject.FindWithTag("Player").GetComponent<PlayerInteraction>();
        p.currentlyHeldJammer = jammer.gameObject;
        tween.Kill();
        jammer.transform.parent = p.transform;
        jammer.transform.localPosition = p.holdPoint.localPosition;
        isTravelling = false;
        jammer.SwitchState(jammer.captiveState);
    }
}
