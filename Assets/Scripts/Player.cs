using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //KeyCodes
    KeyCode jump = KeyCode.Space;
    KeyCode left = KeyCode.A;
    KeyCode right = KeyCode.D;

    //Bools
    public bool playerCanMove = true;

    //Components
    Rigidbody2D rigidBody;
    Collider2D colliderBody;

    //variables
    [SerializeField] float fallMultiplier = 2.5f;
    [SerializeField] float lowJumpMultiplier = 2f;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
        colliderBody = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {

        //Should stop movement during cutscenes
        if(playerCanMove)
        {
            //Place movement functions in here
            Movement();
            JumpMovement();
        }
	}

    //This is being used for modifying the players jump velocity
    private void FixedUpdate()
    {
        //This increases the gravity that is on the player at the peak of their jump
        //This makes gravity feel more impactful/less floaty
        if(rigidBody.velocity.y < 0)
        {
            rigidBody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if(rigidBody.velocity.y > 0 && !Input.GetKey(jump))
        {
            rigidBody.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    void Movement()
    {
        if(Input.GetKey(right))
        {
            rigidBody.velocity = new Vector2(5f, rigidBody.velocity.y);
        }
        else if(Input.GetKey(left))
        {
            rigidBody.velocity = new Vector2(-5f, rigidBody.velocity.y);
        }
        else
        {
            rigidBody.velocity = new Vector2(0f, rigidBody.velocity.y);
        }
    }

    void JumpMovement()
    {
        if(Input.GetKeyDown(jump) && CheckIfPlayerCanJump())
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, 8f);
        }
    }

    //TODO make it so it doesn't just check the center i.e. check the left and right side of the player
    bool CheckIfPlayerCanJump()
    {
        Vector2 position = new Vector2(transform.position.x, colliderBody.bounds.min.y - .1f);
        bool canPlayerJump = Physics2D.Raycast(position, Vector2.down, .1f);
        return canPlayerJump;
    }

    //Move the player to the 
    public IEnumerator MoveToInteractable(Transform interactableTransform)
    {
        playerCanMove = false;
        yield return new WaitForSeconds(2f);
        playerCanMove = true;
    }

}
