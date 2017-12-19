using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

	public GameObject prefab;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {



		//declare a new ray and assign it to cast the ray from the cursor position into our scene 
		Ray beam = Camera.main.ScreenPointToRay (Input.mousePosition);

		//using the debug function drawray so we can see the rays path in the scene view
		Debug.DrawRay (beam.origin, beam.direction * 1000f, Color.red);

		//we use raycasthit to store the information about what our ray hit once it was cast
		RaycastHit beamHit = new RaycastHit ();

		if (Physics.Raycast (beam, out beamHit, 1000f)) {
			Debug.Log ("you hit something at" + beamHit.point);
			if (Input.GetMouseButtonDown (2)) {
				//add force to a random 3D direction (using insideunitsphere) to the rigidbody of the thing our beam hit if left click
				beamHit.rigidbody.AddForce(Random.insideUnitSphere * 5000f); 
			}
			if(Input.GetMouseButtonDown(1)){
				//instantiate a new prefab at the point in which our beam hit if you right click
				Instantiate (prefab, beamHit.point, Quaternion.identity);
			}
			if (Input.GetMouseButtonDown (0)) {
				//destroy the gameobject whose collider you hit if you middle click
				Destroy(beamHit.collider.gameObject);
			}

		}
	}
}
