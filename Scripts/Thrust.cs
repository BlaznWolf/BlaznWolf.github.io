using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrust : MonoBehaviour {

	Rigidbody rb;
	public float thrustAmt;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.W)) {
			rb.AddForce (Vector3.forward * thrustAmt);
		}
		if (Input.GetKey (KeyCode.S)) {
			rb.AddForce (Vector3.back * thrustAmt);
		}
		if (Input.GetKey (KeyCode.A)) {
			rb.AddForce (Vector3.left * thrustAmt);
		}
		if (Input.GetKey (KeyCode.D)) {
			rb.AddForce (Vector3.right * thrustAmt);
		}
	}
}
