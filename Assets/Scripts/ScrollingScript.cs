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
	

	
	void Update()
	{
		float inputX = Input.GetAxis("Horizontal");
		// Mouvement
		Vector3 movement = new Vector3(
			direction.x * speed.x * inputX,
			speed.y * direction.y,
			0);
		
		movement *= Time.deltaTime;
		transform.Translate(movement);

	}
}