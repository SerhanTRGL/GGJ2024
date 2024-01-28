using UnityEngine;

public class Chair : MonoBehaviour
{
    private GameObject currentlySitting;
    public bool IsOccupied => currentlySitting != null;

    public void Sit(GameObject sitter){
        currentlySitting = sitter;
        sitter.transform.position = transform.position;
    }

    public void GetUp(GameObject getUpper){
        currentlySitting = null;
    }
}
