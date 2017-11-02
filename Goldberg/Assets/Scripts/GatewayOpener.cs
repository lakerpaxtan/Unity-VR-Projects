using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatewayOpener : MonoBehaviour {

	// Gate object of this gateway.
	public GameObject gate;

	void OnTriggerEnter(Collider other) {
		// If the entering object is the player...
		if (other.CompareTag("Player")) {
			// Get the collider component of the gate.
			Collider collider = gate.GetComponent<Collider>();

			// Set the collider's isTrigger to true, thus allowing the player to pass through it.
			collider.isTrigger = true;
		}
	}
}
