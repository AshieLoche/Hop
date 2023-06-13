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

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        moveSpeed = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) 
        {
            anim.SetTrigger("backward");
        } 
        else if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetTrigger("left");
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetTrigger("forward");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetTrigger("right");
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetTrigger("backwardPause");
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetTrigger("leftPause");
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            anim.SetTrigger("forwardPause");
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetTrigger("rightPause");
        }
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
}