using System.Collections.Generic;
using UnityEngine;


public class Table : MonoBehaviour{
    [SerializeField] public List<Chair> chairs;
    [SerializeField] private List<GameObject> jammerPrefabs;
    public int ChairCount {
        get {
            return chairs.Count;
        }
    }

    void Start(){
        Chair[] chairObjects = GetComponentsInChildren<Chair>();
        foreach(Chair chairObject in chairObjects) {
            chairs.Add(chairObject);
        }
        SpawnJammers();
    }

    public Chair GetEmptyChair(){
        foreach(Chair chair in chairs){
            if(!chair.IsOccupied){
                return chair;
            }
        }
        return null;
    }
    
    private void SpawnJammers(){
        foreach(Chair chair in chairs){
            Debug.Log(Random.Range(0, jammerPrefabs.Count));
            GameObject jammer = Instantiate(jammerPrefabs[Random.Range(0, jammerPrefabs.Count)]);
            jammer.GetComponent<JammerStateMachine>().jammerChair = chair;
            chair.Sit(jammer);
        }
    }
}