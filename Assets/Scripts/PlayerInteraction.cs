using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private PlayerMovement movement;
    public GameObject currentlyHeldJammer;
    public Transform holdPoint;
    [SerializeField] private Collider2D col;
    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    private void Update() {
        Debug.DrawRay(transform.position, movement.movementDir, Color.cyan);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, movement.movementDir, 2f, LayerMask.GetMask("Jammer"));
        
        if(Input.GetKeyDown(KeyCode.E)){
            if(currentlyHeldJammer == null){
                if(hit.collider != null){
                    hit.collider.GetComponent<IInteractable>().Interact();
                }
            }
            else{
                currentlyHeldJammer.GetComponent<IInteractable>().Interact();
            }
        }

    }
}
