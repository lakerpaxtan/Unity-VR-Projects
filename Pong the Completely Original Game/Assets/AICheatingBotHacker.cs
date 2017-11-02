using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICheatingBotHacker : MonoBehaviour {

    public GameObject RedPuck;
    public GameObject WhitePuck;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        AIMovementChecker();
	}
    void AIMovementChecker()
    {
        if (WhitePuck.transform.position.z + 1.5 > RedPuck.transform.position.z )
        {
            RedPuck.transform.Translate(0f, Random.Range(0.1f, 0.2f), 0);
        }
        if (WhitePuck.transform.position.z - 1.5 < RedPuck.transform.position.z)
        {
            RedPuck.transform.Translate(0f, -Random.Range(0.1f, 0.2f), 0);
        }
    }
}
