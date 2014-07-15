using UnityEngine;

/// <summary>
/// Parallax scrolling
/// </summary>
public class ScrollingScript : MonoBehaviour
{
	/// <summary>
	/// Vitesse du défilement
	/// </summary>
	public Vector2 speed = new Vector2(2, 2);
	
	/// <summary>
	/// Direction du défilement
	/// </summary>
	public Vector2 direction = new Vector2(-1, 0);
	private Transform camTransform;
	private Vector3 camPos;
	void Awake(){
		camTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
		camPos = camTransform.position;
	}
	
	void FixedUpdate()
	{
		Vector3 newPos = camTransform.position;
		float inputX = (camPos.x - newPos.x);
		float inputY = (camPos.y - newPos.y);
//		if (Mathf.Abs(inputX) > 0) {
//			print (inputX);
			camPos = newPos;

			// Mouvement
			Vector3 movement = new Vector3 (
				direction.x * speed.x * inputX,
				direction.y * speed.y * inputY,
				0);
			
			movement *= Time.deltaTime;
			transform.Translate (movement);
//		}
	}
}