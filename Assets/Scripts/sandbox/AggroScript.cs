using UnityEngine;
using System.Collections;

public class AggroScript : MonoBehaviour {

	public Transform player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D col){
		if(col.tag == "Player"){
			print("aggro");
			transform.LookAt(player);
		}
	}
	void OnTriggerExit2D (Collider2D col){
		if(col.tag == "Player"){
			print("exit");
		}
	}
}
