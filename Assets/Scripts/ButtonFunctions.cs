using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    public void LoadNextScene(){
        SceneManager.LoadScene(1);
    }
    public void ExitGame(){
        Application.Quit();
    }
    
}
