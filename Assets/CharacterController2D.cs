using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
    
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float secondJumpForce = 10f;
    [SerializeField] private float moveSmoothing = .05f;	
    [SerializeField] Animator anime;
    [SerializeField] private LayerMask WhatisGround;
    [SerializeField] private Transform groundPos;
    [SerializeField] private float checkRadius;
    [SerializeField] private bool doubleJump = true;
    [SerializeField] private Collider2D DisableCollider;	
    
    

    //private int timeJumpCounter;
    private bool isCrouch = false;
    private bool isGrounded;
    bool jump = false;
    float horizontalMove;
    private Rigidbody2D rBody;
    private Vector3 velocity = Vector3.zero;
    


    private void Awake() {
        rBody = GetComponent<Rigidbody2D>(); //Always getcomponent for rigidbody
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.GamePaused) { //check if game is paused
            //RUN
            horizontalMove = Input.GetAxisRaw("Horizontal"); //get the raw input based on keyboard or joystick
            anime.SetFloat("Horizontal", horizontalMove);

            
            //checkground
            isGrounded = Physics2D.OverlapCircle(groundPos.position, checkRadius, WhatisGround);
            if (isGrounded) {
                anime.SetBool("isJump", false);
                doubleJump = true; //set doubleJump true when touch ground
                jump = false;
            }
            else {
                anime.SetBool("isJump", true);
                jump = true;
            }

            //JUMPING
            //if key is pressed
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))) { 

                if (isGrounded) { //add force on ground
                    rBody.velocity = Vector2.up * jumpForce;
                }
                else { //if not on ground and can doublejump, add more force
                    if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))) { 

                        if (doubleJump) {
                            rBody.velocity = Vector2.up * secondJumpForce;
                            doubleJump = false;
                        }
                    }

                }
            }
            
            if ( (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.LeftControl)) && isGrounded && !jump ) {
                isCrouch = true;
            }
            else {
                isCrouch = false;
            }
            //Debug.Log(isCrouch);

            
            //Animations

            //Crouch
            if (isCrouch && isGrounded) {
                anime.SetBool("isCrouch", true);

                if (DisableCollider != null) {
                    DisableCollider.enabled = false;
                }
            }
            else {
                anime.SetBool("isCrouch", false);
                if (DisableCollider != null) {
                    DisableCollider.enabled = true;
                }
            }

            //RUN
            if (horizontalMove != 0 && !isCrouch) {
                anime.SetBool("isRun", true);
            }
            else {
                anime.SetBool("isRun", false);
            }

            //FLIPs
            if (horizontalMove < 0) {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else if (horizontalMove > 0){
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            
            if (rBody.position.y < -6) {
                FindObjectOfType<Manager>().ended();
                anime.SetBool("isDead", true);
            }
        }
    }

    void FixedUpdate() {

        if (!isCrouch) {
            Vector3 targetLocation = new Vector2(horizontalMove * moveSpeed, rBody.velocity.y); //set the vector before setting the velocity
            rBody.velocity = Vector3.SmoothDamp(rBody.velocity, targetLocation, ref velocity, moveSmoothing); //smoothng the animation
        }
    }
    
}
