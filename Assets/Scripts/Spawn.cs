using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

	public GameObject prefab; //selected prefab from our project view 
	public Transform spawnPoint; //use the position of this transform as a spawn point
	public GameObject destroyMe; //destroy this object upon right click

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) { //if the left mouse button is being pressed during this frame...
			Instantiate (prefab, spawnPoint.position, Quaternion.identity); //instantiate(spawn) our prefab at spawnPoint.position with a rotation of Quaternion.identity("no rotation")
		}


		if (Input.GetMouseButtonDown (1)) { //if the right mouse button has been pressed DOWN during this frame...
			Destroy (destroyMe); //destroy the destroyMe object -- this will give you an error if you press more than once
		}
	}
}
