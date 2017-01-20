﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllHero : MonoBehaviour
{
    private Rigidbody2D rb;
    private float move;
    public float maxSpeedUp;
    public float maxSpeedHorizontal;
    private Transform transformHero;
    private Animator animationController;
    public Transform groundCheck;
    public bool grounded;
    
   
    // Use this for initialization
    void Start()
    {
        animationController = GetComponentInChildren<Animator>();
        transformHero = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        //Check on ground or not
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Water"));
        //Movement control
        
        var touchCount = Input.touches.Length;
        
        //Moving hero in different sides
        if (touchCount == 1)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase != TouchPhase.Began && touch.phase == TouchPhase.Stationary)
            {
                animationController.SetBool("PlayerRun", true);
                if (touch.position.x <= Display.main.systemWidth / 2)
                {
                    if (Mathf.Abs(rb.velocity.x) < maxSpeedHorizontal)
                        rb.AddForce(new Vector2(-50f, 0f));
                    //Rotate hero to moving side
                    if (transformHero.rotation.eulerAngles.y == 180f)
                        transformHero.Rotate(new Vector3(0, 180f, 0));
                }
                else
                {
                    if (Mathf.Abs(rb.velocity.x) < maxSpeedHorizontal)
                        rb.AddForce(new Vector2(50f, 0f));
                    //Rotate hero to moving side
                    if (transformHero.rotation.eulerAngles.y == 0)
                        transformHero.Rotate(new Vector3(0, -180f, 0));
                }
            }
            //Swipe
            if (touch.phase != TouchPhase.Ended && touch.phase == TouchPhase.Moved && grounded)
            {
                if (touch.deltaPosition.y > 0 && Mathf.Abs(touch.deltaPosition.x) < 10 && touch.deltaPosition.magnitude > 7)
                {
                    rb.AddForce(Vector2.up * maxSpeedUp);
                }
            }
            //Stop hero event
            if (touch.phase == TouchPhase.Ended)
            {
                rb.velocity = new Vector2(0f, rb.velocity.y);
                animationController.SetBool("PlayerRun", false);
            }
        }
        else
        {
            var touch = Input.GetTouch(0);
            var touch2 = Input.GetTouch(1);

        }
       
    }
    // Update is called once per frame
    void Update()
    {


        // Animation state machine control
        if (!grounded)
        {
            animationController.SetBool("PlayerFall", true);
        }
        else
        {
            animationController.SetBool("PlayerFall", false);
        }
        
       
        
      

        
    }

}
