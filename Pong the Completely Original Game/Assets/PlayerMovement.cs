using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public GameObject BluePuck;
    public float speed; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        MovementKeys();
     
    }
    void MovementKeys()
    {
        if (BluePuck.transform.position.z > -4.5 )
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(0, -speed, 0);
            };
        if (BluePuck.transform.position.z < 4.5)
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(0, speed, 0);
            };
    }
}
