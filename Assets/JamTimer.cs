using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JamTimer : MonoBehaviour{
    [SerializeField] private TextMeshProUGUI timerText;
    private float _hourConstant;
    private float _minuteConstant;
    [SerializeField] private List<string> _allTimeRepresentations = new List<string>();
    private void Start() {
        _hourConstant = 720f / 48f;
        _minuteConstant = _hourConstant / 4f;
        
        GenerateAllTimeRepresentations();
    }

    
    void Update(){

    }

    private void GenerateAllTimeRepresentations(){
        int hours = 48;
        for(int i = 0; i<=720f/_minuteConstant; i++){
            string text = hours.ToString() + "Hrs ";
            if(i%4 == 0){
                text += "00 Mins";
                hours--;
            }
            if(i%4 == 3){
                text += "15 Mins";
            }
            if(i%4 == 2){
                text += "30 Mins";
            }
            if(i%4 == 1){
                text += "45 Mins";
            }

            _allTimeRepresentations.Add(text);
        }
    }
}
