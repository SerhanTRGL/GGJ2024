using UnityEngine;

public class JammerWorkingState : JammerBaseState{
    //Absolutely wait for 10s
    private float _waitTime = 7f;
    //Chance of escaping each second after absolute wait
    private float _exitChance = 0.10f; 
    private float _waitTimeCounter;
    private float _secondCounter;
    public override void EnterState(JammerStateMachine jammerStateMachine){
        _waitTimeCounter = 0f;
        _secondCounter = 1f;
    }
    public override void UpdateState(JammerStateMachine jammerStateMachine){
        if(_waitTimeCounter >= _waitTime){
            if(_secondCounter >= 0.75f){
                if(Random.Range(0f, 1f) <= _exitChance && JammerManager.Instance.TakeToken()){
                    jammerStateMachine.jammerChair.GetUp(jammerStateMachine.gameObject);
                    jammerStateMachine.SwitchState(jammerStateMachine.runningState);
                }
                else{
                    _waitTimeCounter = 0;
                }
                _secondCounter = 0f;
            }
            _secondCounter += Time.deltaTime;
        }
        _waitTimeCounter = _waitTimeCounter > _waitTime ? _waitTime : _waitTimeCounter+Time.deltaTime;
    }

    public override void ExitState(JammerStateMachine jammerStateMachine){
        
    }

    public override void Interact()
    {
    }


}
