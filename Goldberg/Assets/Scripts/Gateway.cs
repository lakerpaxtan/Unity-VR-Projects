using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gateway : MonoBehaviour {

    // The script manager object for this scene.
    public HW1ScriptManager manager;

	// Has the player passed through this gateway yet?
	public bool activated = false;

	// The colored marker object on the gateway arch.
	public GameObject marker;

	// The material to be used on the marker when the gate is activated.
	public Material activeMat;

    // The spawn point object for the gateway.
    public GameObject spawnPointObject;

	public void Activate()
    {
		// Update the state.
		activated = true;

		// Get the mesh renderer component on the marker.
		MeshRenderer meshRenderer = marker.GetComponent<MeshRenderer>();

		// Change the material on the marker.
		meshRenderer.material = activeMat;

        // Tell the manager this gateway has been activated.
        manager.ProcessGatewayActivation(this);
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!activated)
            {
                Activate();
            }
        }
    }
}
