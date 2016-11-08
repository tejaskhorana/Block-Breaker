using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Paddle paddle;
	private bool hasStarted;
	private Vector3 paddleToBallVector;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position-paddle.transform.position;
		hasStarted = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!hasStarted) {

			//Lock ball to paddle
			this.transform.position = paddle.transform.position + paddleToBallVector;

						//Wait for mouse press to launch
			if (Input.GetMouseButtonDown(0)) { //more concise than GetMouseButton
				this.GetComponent<Rigidbody2D>().velocity = new Vector2(4f, 12f);
				hasStarted = true;
			}
		}
	}


	void OnCollisionEnter2D (Collision2D collision)
	{
		Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
		if (hasStarted) {
			this.GetComponent<AudioSource>().Play();
			this.GetComponent<Rigidbody2D>().velocity += tweak;
		}
	}
}
