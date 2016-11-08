using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public AudioClip crack;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public GameObject smoke;

	private int numHits;
	private LevelManager levelManager;
	private bool isBreakable;

	// Use this for initialization
	void Start ()
	{
		isBreakable = (this.tag == "breakable");
		if (isBreakable) {
			breakableCount++;
		}
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		numHits = 0;
	}

	void OnCollisionEnter2D (Collision2D collision)
	{
		if (isBreakable) {
			AudioSource.PlayClipAtPoint(crack, transform.position);
			handleHits();
		}
	}

	void handleHits ()
	{
		int maxHits = hitSprites.Length + 1;
		numHits++;	
		if (numHits >= maxHits) {
			breakableCount--;
			levelManager.brickDestroyed();
			puffSmoke();
			Destroy (gameObject);
		} else {
			loadSprites();
		}
	}

	void puffSmoke ()
	{
		GameObject smokePuff = Instantiate(smoke, gameObject.transform.position, Quaternion.identity) as GameObject;
		smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;

	}

	void loadSprites ()
	{
		int spriteIndex = numHits - 1;
		//handle case here sprite index doesn't have an image
		if (hitSprites [spriteIndex]) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
	}
}
