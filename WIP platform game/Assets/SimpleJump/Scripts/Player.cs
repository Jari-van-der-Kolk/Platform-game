/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System;
using UnityEngine;

/*
 * Simple Jump
 * */



public class Player : MonoBehaviour {

    [SerializeField] private LayerMask platformsLayerMask;
    //private Player_Base playerBase;
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider2d;

    
    [SerializeField] private ControlState controlState;

    [SerializeField] private float midAirControl = 3f;
    [SerializeField] private float moveSpeed = 40f;
    [SerializeField] private float jumpVelocity = 100f;

    [Header("Ground check  position")]
    [SerializeField] private Vector2 groundCheckPosition;
    [SerializeField] private Vector2 groundCheckSize;

    [SerializeField] private bool isGrounded;
    
    enum ControlState
    {
        FullAirControl,
        SomeMidAirControl,
        NoMidAirControl
    };

    
    
    private void Awake() {
        //playerBase = gameObject.GetComponent<Player_Base>();
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
    }

    private void Update() {
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space)) {
            rigidbody2d.velocity = Vector2.up * jumpVelocity;
        }

        switch (controlState)
        {
            case (ControlState.NoMidAirControl):
                HandleMovement_NoMidAirControl();
                break;
             case (ControlState.SomeMidAirControl):
                HandleMovement_SomeMidAirControl();
                 break;
            case(ControlState.FullAirControl):
                HandleMovement_FullMidAirControl();
                break;
        }
        

        // Set Animations
        isGrounded = IsGrounded();
        if (IsGrounded()) {
            if (rigidbody2d.velocity.x == 0) {
                //playerBase.PlayIdleAnim();
            } else {
                //playerBase.PlayMoveAnim(new Vector2(rigidbody2d.velocity.x, 0f));
            }
        } else {
            //playerBase.PlayJumpAnim(rigidbody2d.velocity);
        }
    }

    private bool IsGrounded() {
        return Physics2D.BoxCast(transform.position + (Vector3)groundCheckPosition, groundCheckSize, 0f, Vector2.down, 0, platformsLayerMask);
    }
    
    private void HandleMovement_FullMidAirControl() {
        if (Input.GetKey(KeyCode.A)) {
            rigidbody2d.velocity = new Vector2(-moveSpeed, rigidbody2d.velocity.y);
        } else {
            if (Input.GetKey(KeyCode.D)) {
                rigidbody2d.velocity = new Vector2(+moveSpeed, rigidbody2d.velocity.y);
            } else {
                // No keys pressed
                rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y);
            }
        }
    }

    private void HandleMovement_SomeMidAirControl() {
        if (Input.GetKey(KeyCode.A)) {
            if (IsGrounded()) {
                rigidbody2d.velocity = new Vector2(-moveSpeed, rigidbody2d.velocity.y);
            } else {
                rigidbody2d.velocity += new Vector2(-moveSpeed * midAirControl * Time.deltaTime, 0);
                rigidbody2d.velocity = new Vector2(Mathf.Clamp(rigidbody2d.velocity.x, -moveSpeed, +moveSpeed), rigidbody2d.velocity.y);
            }
        } else {
            if (Input.GetKey(KeyCode.D)) {
                if (IsGrounded()) {
                    rigidbody2d.velocity = new Vector2(+moveSpeed, rigidbody2d.velocity.y);
                } else {
                    rigidbody2d.velocity += new Vector2(+moveSpeed * midAirControl * Time.deltaTime, 0);
                    rigidbody2d.velocity = new Vector2(Mathf.Clamp(rigidbody2d.velocity.x, -moveSpeed, +moveSpeed), rigidbody2d.velocity.y);
                }
            } else {
                // No keys pressed
                if (IsGrounded()) {
                    rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y);
                }
            }
        }
    }

    private void HandleMovement_NoMidAirControl() {
        if (IsGrounded()) {
            if (Input.GetKey(KeyCode.A)) {
                rigidbody2d.velocity = new Vector2(-moveSpeed, rigidbody2d.velocity.y);
            } else {
                if (Input.GetKey(KeyCode.D)) {
                    rigidbody2d.velocity = new Vector2(+moveSpeed, rigidbody2d.velocity.y);
                } else {
                    // No keys pressed
                    rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position + (Vector3)groundCheckPosition, groundCheckSize);
    }
}