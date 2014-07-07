using UnityEngine;
using System.Collections;

public class SwordScript : MonoBehaviour 
{
	public int damageAmount=1;	
	public bool attacking=false;
	[HideInInspector]
	public int forceToAdd=1;
	public int attackForce=500;
	void Start () 
	{
		// Destroy the rocket after 2 seconds if it doesn't get destroyed before then.
//		Destroy(gameObject, 2);
	}
	
	
	void OnTriggerEnter2D (Collider2D col){
		if(col.tag == "Enemy" && attacking){
			// ... find the Enemy script and call the Hurt function.
			col.gameObject.GetComponent<EnemyScript>().Hurt(damageAmount);
			col.rigidbody2D.AddForce(new Vector2(forceToAdd*attackForce, forceToAdd*attackForce));
			attacking=false;
		}
	}
}
