using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
	[HideInInspector]
	public bool facingRight = true;			// For determining which way the player is currently facing.
	[HideInInspector]
	public bool jump = false;	
	[HideInInspector]
	public bool attack = false;
	[HideInInspector]
	public bool waitingEndOfAttack =false;

	public float moveForce = 365f;			// Amount of force added to move the player left and right.
	public float maxSpeed = 5f;				
	public float jumpForce = 10f;			
	public float attackDuration;
	public Animator animator;
	
	private Transform groundCheck;			// A position marking where to check if the player is grounded.
	private bool grounded = false;			// Whether or not the player is grounded.
	private SwordScript swordScript;
	private Object attackLock = new Object();
	void Awake(){
		// Setting up references.
		groundCheck = transform.Find("groundCheck");
		swordScript = GetComponentsInChildren<SwordScript>()[0];
		animator = GetComponent<Animator>();
	}
	
	
	void Update(){
		// The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));  

		// If the jump button is pressed and the player is grounded then the player should jump.
		if(Input.GetButtonDown("Jump") && grounded)
			jump = true;
		if (Input.GetButtonDown("Fire1") && !attack) {
			print ("fire");
			attack = true;
		}
	}
	
	
	void FixedUpdate (){

		float h = Input.GetAxis ("Horizontal");

		// The Speed animator parameter is set to the absolute value of the horizontal input.
		animator.SetFloat ("Speed", Mathf.Abs (h));

		// If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
		if (h * rigidbody2D.velocity.x < maxSpeed && !attack) {
			rigidbody2D.AddForce (Vector2.right * h * moveForce);
		}

		// If the player's horizontal velocity is greater than the maxSpeed...
	if (Mathf.Abs (rigidbody2D.velocity.x) > maxSpeed && !attack) {
			rigidbody2D.velocity = new Vector2 (Mathf.Sign (rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);
		}
		// If the input is moving the player right and the player is facing left...
		if (h > 0 && !facingRight) {
			Flip ();
		} else if (h < 0 && facingRight) {
				Flip ();
		}
			
						// If the player should jump...
		 if (jump){
			// Set the Jump animator trigger parameter.
			animator.SetTrigger("Jump");

			// Add a vertical force to the player.
			rigidbody2D.AddForce(new Vector2(0f, jumpForce));
			
			// Make sure the player can't jump again until the jump conditions from Update are satisfied.
			jump = false;
		}else if (attack && !animator.GetBool ("attack")) {
			print ("fixedupdate");
			waitingEndOfAttack=true;
			animator.SetBool ("attack",true);	
			swordScript.forceToAdd = (facingRight?1:-1);
			swordScript.attacking=true;
//			StartCoroutine(finishAttack());
		}
	}
	void finishAttack() {
		print ("FINISH ATTACK");
		attack = false;
		animator.SetBool ("attack",false);	
		swordScript.attacking = false;
		waitingEndOfAttack = false;
	}
	
	void Flip (){
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;
		
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

}
