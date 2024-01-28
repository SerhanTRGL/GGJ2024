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
        _hourConstant = 240f / 48f;
        _minuteConstant = _hourConstant / 4f;
        
        GenerateAllTimeRepresentations();
    }

    int index = 0;
    float minuteTimer = 0;
    void Update(){
        timerText.text = _allTimeRepresentations[index];
        minuteTimer += Time.deltaTime;
        if(minuteTimer>=_minuteConstant){
            index = index < _allTimeRepresentations.Count ? index+1 : _allTimeRepresentations.Count-1;
            minuteTimer=0;
        }
    }

    private void GenerateAllTimeRepresentations(){
        int hours = 48;
        for(int i = 0; i<=240f/_minuteConstant; i++){
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
