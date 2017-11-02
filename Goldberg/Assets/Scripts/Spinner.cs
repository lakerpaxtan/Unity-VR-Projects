using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour {

    public float rotateTime = 1; // Second
    public float waitTime = 2; // Seconds
    public float delay = 0;

    float rotateRate; // Degrees per second
    float timeRemaining = 0;
    float angleAnchor;
    float anglesTurned = 0;
    string state = "WAITING";

	// Use this for initialization
	void Start () {
        rotateRate = 180.0f / rotateTime;
        angleAnchor = transform.localEulerAngles.y;
        anglesTurned = 0;
        timeRemaining += delay;
        state = "WAITING";
    }
	
	// Update is called once per frame
	void Update () {
        if (state == "WAITING")
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0)
                InitRotate();
        }
        else
        {
            float rotateAmount = rotateRate * Time.deltaTime;
            anglesTurned += rotateAmount;
            transform.Rotate(new Vector3(0, rotateAmount, 0));
            if (anglesTurned >= 180)
            {
                Vector3 currRot = transform.localEulerAngles;
                transform.localEulerAngles = new Vector3(currRot.x, angleAnchor + 180, currRot.z);
                InitWait();
            }
        }
	}

    void InitWait ()
    {
        timeRemaining = waitTime;
        state = "WAITING";
    }

    void InitRotate()
    {
        anglesTurned = 0;
        angleAnchor = transform.localEulerAngles.y;
        state = "ROTATING";
    }
}
