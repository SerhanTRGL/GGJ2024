using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour{
    private float _timeLimit = 240f; //in seconds
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
        if(_inGameTimer <= 0){
            SceneManager.LoadScene("GoodEnd");
        }
        _inGameTimer = _inGameTimer < 0 ? 0 : _inGameTimer -= Time.deltaTime;
    }
}
