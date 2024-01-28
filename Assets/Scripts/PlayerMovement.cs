using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour{
    [SerializeField] private float xSpeed;
    [SerializeField] private float ySpeed;
    [SerializeField] private float dashMultiplier;
    [SerializeField] public Vector2 movementDir;
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private bool _isDashing = false;
    [SerializeField] private float _dashDuration = 0.25f;
    [SerializeField] private float _dashDurationTimer = 0f;
    [SerializeField] private float _dashCooldown;
    [SerializeField] private float _dashCooldownTimer = 0f;
    [SerializeField] private PlayerInteraction p;
    private void Awake() {
        playerRb = GetComponent<Rigidbody2D>();
        p = GetComponent<PlayerInteraction>();
        movementDir = Vector2.right;
    }
    private void Start() {
        _dashCooldownTimer = _dashCooldown;
    }

    private void FixedUpdate() {
        HandleMovement();
        if(p.currentlyHeldJammer == null){
            HandleDash();
        }
    }


    private void HandleMovement(){
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        
        if(horizontalInput>0){
            transform.localScale = new Vector3(1,1,1);
        }
        else if(horizontalInput<0){
            transform.localScale = new Vector3(-1, 1, 1);
        }
        playerRb.velocity = _isDashing ? playerRb.velocity : new Vector2(horizontalInput*xSpeed, verticalInput*ySpeed);
        movementDir = !(horizontalInput==0 && verticalInput==0) ? playerRb.velocity : movementDir;
    }

    private void HandleDash(){
        bool dashInput = Input.GetKey(KeyCode.LeftShift);
        if(dashInput && !_isDashing && _dashCooldownTimer ==_dashCooldown){
            playerRb.AddForce(movementDir.normalized*dashMultiplier);
            _isDashing = true;
        }

        if(_isDashing){
            _dashDurationTimer += Time.fixedDeltaTime;
            if(_dashDurationTimer >= _dashDuration){
                _isDashing = false;
                _dashDurationTimer = 0f;
                _dashCooldownTimer = 0f;
            }
        }
        _dashCooldownTimer = _dashCooldownTimer >=_dashCooldown ? _dashCooldown : _dashCooldownTimer + Time.fixedDeltaTime;
    }
}



