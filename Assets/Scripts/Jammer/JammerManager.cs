using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class JammerManager : MonoBehaviour{

    public static JammerManager Instance{get; private set;}
    [SerializeField] private int _maxSimultaneousExits = 5;
    [SerializeField] private int _availableExitTokens;
    [SerializeField] private List<Jammer> _jammers = new List<Jammer>();
    
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
        _availableExitTokens = _availableExitTokens>_maxSimultaneousExits?_maxSimultaneousExits:_availableExitTokens++;
    }

    public void AddJammerToList(Jammer jammer){
        if(!_jammers.Contains(jammer)){
            _jammers.Add(jammer);
        }
    }
    
    public void RemoveJammerFromList(Jammer jammer){
        if(_jammers.Contains(jammer)){
            _jammers.Remove(jammer);
        }
    }
}
