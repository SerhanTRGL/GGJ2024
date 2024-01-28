using UnityEngine;

public class GameManager : MonoBehaviour{
    private float _timeLimit = 720f; //in seconds
    private  float _inGameTimer; 
    public float InGameTimer => _inGameTimer; 
    public float TimeLimit => _timeLimit;

    public static GameManager Instance;
    private void Awake() {
        if(Instance != null && Instance != this){
            Destroy(this);
        }
        else{
            Instance = this;
        }
    }
    //OnGameOver
    private void Start() {
        _inGameTimer = _timeLimit;
    }
    
    // Update is called once per frame
    void Update(){
        _inGameTimer = _inGameTimer < 0 ? 0 : _inGameTimer -= Time.deltaTime;
    }
}
