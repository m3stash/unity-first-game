using UnityEngine;
using System.Collections;

public class SwordScript : MonoBehaviour 
{
	public GameObject explosion;		// Prefab of explosion effect.
	public int damageAmount=1;	
	public bool attacking=false;
	
	void Start () 
	{
		// Destroy the rocket after 2 seconds if it doesn't get destroyed before then.
//		Destroy(gameObject, 2);
	}
	
	
	void OnTriggerEnter2D (Collider2D col) 
	{
		// If it hits an enemy...
		if(col.tag == "Enemy" && attacking)
		{
			// ... find the Enemy script and call the Hurt function.
			col.gameObject.GetComponent<EnemyScript>().Hurt(damageAmount);
			attacking=false;
		}
	}
}
