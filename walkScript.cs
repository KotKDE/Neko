using UnityEngine;
using System.Collections;
using System;

public class walkScript : MonoBehaviour {
	public float maxSpeed = 10f;
	public float jumpForce = 700f;
	bool facingRight = true;
	bool grounded = false;
	public Transform groundCheck;
	public float groundRadius = 0.2f;
	public LayerMask whatIsGround;

	public float move;

    Animator state;

	// Use this for initialization
	void Start () {
         state = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

      if(GetKeyDown(KeyCode.Space)){
      state.SetInteger("states", 1);
      };
      
      if(GeyKeyDown(KeyCode.Ctrl)){
      state.SetInteger("states", 2);
      };
      
      if(Input.GetAxis("Horizontal")=>0){
      state.SetInteger("states", 3);
      };
      
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);

		move = Input.GetAxis ("Horizontal");

	}

	void Update(){
		if (grounded && (Input.GetKeyDown (KeyCode.W)||Input.GetKeyDown (KeyCode.UpArrow))) {

			rigidbody2D.AddForce (new Vector2(0f,jumpForce));
		}
		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);
		
		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();



		if (Input.GetKey(KeyCode.Escape))
		{
			Application.Quit();
		}

		if (Input.GetKey(KeyCode.R))
		{
			Application.LoadLevel(Application.loadedLevel);
		}


	}
	
	void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}		
}