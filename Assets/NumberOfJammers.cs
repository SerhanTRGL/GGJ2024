using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumberOfJammers : MonoBehaviour
{
    public TextMeshProUGUI noOfJammers;

    private void Update() {
        noOfJammers.text = JammerManager.Instance.GetRemainingJammers().ToString();
    }
}
