using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JammerWorkingState : JammerBaseState{
    //Absolutely wait for 10s
    private float _waitTime = 10f;

    //Chance of escaping each second after absolute wait
    private float _exitChance = 0.1f; 
    private float _waitTimeCounter;
    private float _secondCounter;
    public override void EnterState(JammerStateMachine jammerStateMachine){
        _waitTimeCounter = 0f;
        _secondCounter = 1f;
    }
    public override void UpdateState(JammerStateMachine jammerStateMachine){
        if(_waitTimeCounter >= _waitTime){
            if(_secondCounter >= 1f){
                if(Random.Range(0f, 1f) <= _exitChance && JammerManager.Instance.TakeToken()){
                    Debug.Log("Jammer #0 is RUNNING AWAY!");
                    //jammerStateMachine.SwitchState(jammerStateMachine.runningState);
                }
                _secondCounter = 0f;
            }
            _secondCounter += Time.deltaTime;
        }
        _waitTimeCounter = _waitTimeCounter > _waitTime ? _waitTime : _waitTimeCounter+Time.deltaTime;
    }

    public override void ExitState(JammerStateMachine jammerStateMachine)
    {
        throw new System.NotImplementedException();
    }

    public override void Interact(JammerStateMachine jammerStateMachine)
    {
        throw new System.NotImplementedException();
    }


}
