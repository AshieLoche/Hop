using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //Speed (How fast the will navigate in our game)
    public float moveSpeed;
    //RigidBody (Handles Physics, Make our player move)
    private Rigidbody2D rigidBody;
    //Vector2 dictates where the player is moving
    private Vector2 movementInput;
    //Animator access our animator to play animation
    private Animator anim;
    //Counts coins collected
    private int coinCounter;
    //Player health
    public int healthPoints;

    //private enum SpriteOrientation
    //{
    //    ORIENT_LEFT,
    //    ORIENT_FORWARD,
    //    ORIENT_RIGHT,
    //    ORIENT_BACKWARD
    //}
    //private SpriteOrientation orientation = SpriteOrientation.ORIENT_FORWARD;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (/*movementChecker &&*/ (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
        //{
        //    resetAnimation();
        //    anim.SetTrigger("backward");
        //    orientation = SpriteOrientation.ORIENT_BACKWARD;
        //}
        //if (/*movementChecker &&*/ (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)))
        //{
        //    resetAnimation();
        //    anim.SetTrigger("left");
        //    orientation = SpriteOrientation.ORIENT_LEFT;
        //}
        //if (/*movementChecker &&*/ (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)))
        //{
        //    resetAnimation();
        //    anim.SetTrigger("forward");
        //    orientation = SpriteOrientation.ORIENT_FORWARD;
        //}
        //if (/*movementChecker &&*/ (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))) 
        //{
        //    resetAnimation();
        //    anim.SetTrigger("right");
        //    orientation = SpriteOrientation.ORIENT_RIGHT;
        //}
        //if (/*!movementChecker &&*/ (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow)))
        //{
        //    anim.SetTrigger("backwardPause");
        //    //movementChecker = true;
        //}
        //if (/*!movementChecker &&*/ (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow)))
        //{
        //    anim.SetTrigger("leftPause");
        //    //movementChecker = true;
        //}
        //if (/*!movementChecker &&*/ (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow)))
        //{
        //    anim.SetTrigger("forwardPause");
        //    //movementChecker = true;
        //}
        //if (/*!movementChecker &&*/ (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow)))
        //{
        //    anim.SetTrigger("rightPause");
        //    //movementChecker = true;
        //}
        //if (Input.GetMouseButtonDown(0) && orientation == SpriteOrientation.ORIENT_FORWARD) 
        //{
        //    resetAnimation();
        //    anim.SetTrigger("forwardStab");
        //}
        //if (Input.GetMouseButtonUp(0) && orientation == SpriteOrientation.ORIENT_FORWARD)
        //{
        //    anim.SetTrigger("forwardPause");
        //    //movementChecker = true;
        //}
        
        anim.SetFloat("horizontal", movementInput.x);
        anim.SetFloat("vertical", movementInput.y);
        anim.SetFloat("speed", movementInput.sqrMagnitude);

        //if(healthPoints <= 0 ) 
        //{
        //    Destroy(gameObject);
        //}
    }

    private void resetAnimation()
    {
        anim.ResetTrigger("forwardPause");
        anim.ResetTrigger("rightPause");
        anim.ResetTrigger("leftPause");
        anim.ResetTrigger("backwardPause");
        //movementChecker = false;
    }

    //Fixed update for physics calculations
    private void FixedUpdate()
    {
        rigidBody.velocity = movementInput * moveSpeed;
    }

    //To get the Input System Clicks
    private void OnMove(InputValue inputValue)
    {
        //Converts WASD to Vector2 Values
        movementInput = inputValue.Get<Vector2>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coins"))
        {
            coinCounter++;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("HealthPotion"))
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("SpeedPotion"))
        {
            Transform col = collision.transform;
            col.transform.position = new Vector2(999, 999);
        }
    }
}