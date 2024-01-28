using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JammerManager : MonoBehaviour{
    public static JammerManager Instance{get; private set;}
    [SerializeField] private int _maxSimultaneousExits = 5;
    [SerializeField] private int _availableExitTokens;
    [SerializeField] private List<JammerStateMachine> _jammers = new List<JammerStateMachine>();
    private static int remainingJammers = 15;
    private void Awake() {
        if(Instance != null && Instance != this){
            Destroy(this);
        }
        else{
            Instance = this;
        }

        _availableExitTokens = _maxSimultaneousExits;
    }

    public bool TakeToken(){
        if(_availableExitTokens > 0){
            _availableExitTokens--;
            return true; //Successful take
        }
        return false; //Unsuccessful take
    }

    public void ReleaseToken(){
        _availableExitTokens = _availableExitTokens>_maxSimultaneousExits?_maxSimultaneousExits:_availableExitTokens+1;
    }

    public void AddJammerToList(JammerStateMachine jammer){
        if(!_jammers.Contains(jammer)){
            _jammers.Add(jammer);
        }
    }

    public void RemoveJammerFromList(JammerStateMachine jammer){
        if(_jammers.Contains(jammer)){
            remainingJammers--;
            _jammers.Remove(jammer);
            if(remainingJammers == 0){
                SceneManager.LoadScene("BadEnd");
            }
        }
    }

    public int GetRemainingJammers(){
        return remainingJammers;
    }
    
}
