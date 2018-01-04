using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LordLauncher : MonoBehaviour {

	Rigidbody2D body;

	public float windupTime;
	public Vector2 windupForce;

	bool windingUp = false;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D>();

		StartCoroutine(WindUpAndRelease());
	}
	
	// Update is called once per frame
	void Update () {
		if (windingUp) {
			body.AddForce(windupForce, ForceMode2D.Impulse);
		}
	}

	IEnumerator WindUpAndRelease() {

		windingUp = true;
		body.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

		yield return new WaitForSeconds(windupTime);

		windingUp = false;
		body.constraints = RigidbodyConstraints2D.None;
	}
}
