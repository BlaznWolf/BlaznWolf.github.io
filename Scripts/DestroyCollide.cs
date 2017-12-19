using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCollide : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//OnCollisionEnter will run each time the GameObject this is attached to collides with something
	void OnCollisionEnter(Collision collisionReport){
		Destroy(collisionReport.gameObject); //destroy the gameobject that was collided with as stored in the collisionreport
	}
}
