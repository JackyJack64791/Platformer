using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllHero : MonoBehaviour
{
    private Rigidbody2D rb;
    public float maxSpeedUp;
    public float maxSpeedHorizontal;
    private Transform transformHero;
    private Animator animationController;

    public Transform groundCheck;
    public bool grounded;
    public bool jump;
    public bool move;
    public int coins;
    public Text score;

    // Use this for initialization
    void Start()
    {
        animationController = GetComponentInChildren<Animator>();
        transformHero = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            coins++;
            score.text = coins.ToString();
        }
    }

    private void FixedUpdate()
    {
        //Movement
        if (jump)
        {
            jump = false;
            rb.AddForce(Vector2.up * maxSpeedUp);
        }
    }
    // Update is called once per frame
    void Update()
    {
        foreach (var touch in Input.touches)
        {
            var touchSpeed=touch.deltaPosition.magnitude / touch.deltaTime;
            //Swipe
            if (touch.phase != TouchPhase.Ended && touch.phase == TouchPhase.Moved && rb.velocity.y == 0 )
            {
                if (touch.deltaPosition.y > 0 && Mathf.Abs(touch.deltaPosition.x) < 10 && touch.deltaPosition.magnitude > 7 && !jump)
                {
                    
                    jump = true;
                    
                }
            }

            //Moving hero in different sides
            if (touch.phase != TouchPhase.Began && touch.phase == TouchPhase.Stationary && touch.fingerId == 0 && touch.deltaPosition.magnitude==0)
            {
                
                animationController.SetBool("PlayerRun", true);
                if (touch.position.x <= Display.main.systemWidth / 2 )
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
           
            //Stop hero event
            if (touch.phase == TouchPhase.Ended && touch.fingerId == 0)
            {
                Debug.Log("sTOP!");
                rb.velocity = new Vector2(0f, rb.velocity.y);
                animationController.SetBool("PlayerRun", false);
            }
        }

        // Animation state machine control
        if (rb.velocity.y != 0)
        {
            animationController.SetBool("PlayerFall", true);
        }
        else
        {
            animationController.SetBool("PlayerFall", false);
        }
    }
}
