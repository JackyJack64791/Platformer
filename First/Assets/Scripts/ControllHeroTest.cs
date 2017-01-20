﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllHeroTest : MonoBehaviour
{
    private Rigidbody2D rb;
    private float move;
    public float maxSpeedUp;
    public float maxSpeedHorizontal;
    private Transform transformHero;
    private Animator animationController;
    public bool grounded;
    public Transform groundCheck;
    
   
    // Use this for initialization
    void Start()
    {
       
        animationController = GetComponentInChildren<Animator>();
        transformHero = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();


    }
    private void FixedUpdate()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Water"));

        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            rb.AddForce(Vector2.up * maxSpeedUp);
        }

        if (Input.GetKey(KeyCode.A))
        {
            
            if (Mathf.Abs(rb.velocity.x) < maxSpeedHorizontal)
                rb.AddForce(new Vector2(-50f, 0f));
            
            //Rotate hero to moving side
            if (transformHero.rotation.eulerAngles.y == 180f)
                transformHero.Rotate(new Vector3(0, 180f, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            
            if (Mathf.Abs(rb.velocity.x) < maxSpeedHorizontal)
                rb.AddForce(new Vector2(50f, 0f));
            //Rotate hero to moving side
            if (transformHero.rotation.eulerAngles.y == 0)
                transformHero.Rotate(new Vector3(0, -180f, 0));
        }
        // Animation state machine control
        if (rb.velocity.y != 0)
        {
            animationController.SetBool("PlayerFall", true);
        }
        if (rb.velocity.y == 0)
        {
            animationController.SetBool("PlayerFall", false);
        }
        if (rb.velocity.x == 0)
        {
            animationController.SetBool("PlayerRun", false);
        }
        if (rb.velocity.x != 0)
        {
            animationController.SetBool("PlayerRun", true);
        }
        //var touch = Input.GetTouch(0);
        ////Moving hero in different sides
        //if (Input.touchCount == 1)
        //{
            
        //    if (touch.phase!=TouchPhase.Began && touch.phase == TouchPhase.Stationary)
        //    {
                
        //        if (touch.position.x <= Display.main.systemWidth / 2)
        //        {
        //            if (Mathf.Abs(rb.velocity.x) < maxSpeedHorizontal)
        //                rb.AddForce(new Vector2(-50f, 0f));
        //            //Rotate hero to moving side
        //            if (transformHero.rotation.eulerAngles.y == 180f)
        //                transformHero.Rotate(new Vector3(0, 180f, 0));
        //        }
        //        else
        //        {
        //            if (Mathf.Abs(rb.velocity.x) < maxSpeedHorizontal)
        //                rb.AddForce(new Vector2(50f, 0f));
        //            //Rotate hero to moving side
        //            if (transformHero.rotation.eulerAngles.y == 0)
        //                transformHero.Rotate(new Vector3(0, -180f, 0));
        //        }
        //    }
        //    //Swipe
        //    if (touch.phase != TouchPhase.Ended && touch.phase == TouchPhase.Moved )
        //    {
        //        if (touch.deltaPosition.y > 0 && Mathf.Abs(touch.deltaPosition.x)<10 && touch.deltaPosition.magnitude>7 && rb.velocity.y==0)
        //        {
        //            rb.AddForce(new Vector2(0f, 1000f));
        //        }
        //    }
        //    //Stop hero event
        //    if (touch.phase == TouchPhase.Ended)
        //    {
        //        rb.velocity = new Vector2(0f, rb.velocity.y);
        //    }
        //}
    }

    private void Update()
    {
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
