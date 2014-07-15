using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour
{
	//public float moveSpeed = 2f;		// The speed the enemy moves at.
	public int HP = 1;					// How many times the enemy can be hit before it dies.
	public Sprite deadEnemy;			// A sprite of the enemy when it's dead.
	//public Sprite damagedEnemy;			// An optional sprite of the enemy when it's damaged.
	//public AudioClip[] deathClips;		// An array of audioclips that can play when the enemy dies.
	//public GameObject hundredPointsUI;	// A prefab of 100 that appears when the enemy dies.
	//public float deathSpinMin = -100f;			// A value to give the minimum amount of Torque when dying
	//public float deathSpinMax = 100f;			// A value to give the maximum amount of Torque when dying

	public float moveSpeed = 3f;
	
	private SpriteRenderer ren;			// Reference to the sprite renderer.
	//private Transform frontCheck;		// Reference to the position of the gameobject used for checking if something is in front.
	private bool dead = false;			// Whether or not the enemy is dead.
	[HideInInspector]
	public bool facingRight = true;	
	
	void Awake()
	{
		// Setting up the references.
		ren = transform.GetComponent<SpriteRenderer>();
		//frontCheck = transform.Find("frontCheck").transform;
		//score = GameObject.Find("Score").GetComponent<Score>();
	}
	
	void FixedUpdate (){
		// Create an array of all the colliders in front of the enemy.
		//Collider2D[] frontHits = Physics2D.OverlapPointAll(frontCheck.position, 1);
		
		// Check each of the colliders.
		//foreach(Collider2D c in frontHits)
		//{
			// If any of the colliders is an Obstacle...
		//	if(c.tag == "Obstacle")
//			{
				// ... Flip the enemy and stop checking the other colliders.
//				Flip ();
//				break;
//			}
//		}
		
		// Set the enemy's velocity to moveSpeed in the x direction.
		//rigidbody2D.velocity = new Vector2(transform.localScale.x * moveSpeed, rigidbody2D.velocity.y);	
		
		if (HP <= 0 && !dead){
			Death ();
		}
	}
	
	public void Hurt(int damageAmount)
	{
		// Reduce the number of hit points by one.
		HP-=damageAmount;
	}
	
	void Death()
	{
		SpriteRenderer[] otherRenderers = GetComponentsInChildren<SpriteRenderer>();
		
		// Disable all of them sprite renderers.
		foreach(SpriteRenderer s in otherRenderers)
		{
			s.enabled = false;
		}
		
		// Re-enable the main sprite renderer and set it's sprite to the deadEnemy sprite.
		ren.enabled = true;
		ren.sprite = deadEnemy;
		
		// Set dead to true.
		dead = true;
		
		// Find all of the colliders on the gameobject and set them all to be triggers.
//		Collider2D[] cols = GetComponents<Collider2D>();
//		foreach(Collider2D c in cols)
//		{
//			c.isTrigger = true;
//		}
		
		// Create a vector that is just above the enemy.
		Vector3 scorePos;
		scorePos = transform.position;
		scorePos.y += 1.5f;
		
		// Instantiate the 100 points prefab at this point.
//		Instantiate(hundredPointsUI, scorePos, Quaternion.identity);
	}
	
	
	public void Flip()
	{
		// Multiply the x component of localScale by -1.
		Vector3 enemyScale = transform.localScale;
		enemyScale.x *= -1;
		transform.localScale = enemyScale;
	}
}
