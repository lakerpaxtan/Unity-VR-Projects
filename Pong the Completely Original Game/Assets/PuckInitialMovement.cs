using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckInitialMovement : MonoBehaviour {

    public GameObject Puck;
    public Rigidbody rb;
    public GameObject RedSide;
    public GameObject BlueSide; 
	// Use this for initialization
	void Start () {
        
        rb.velocity = new Vector3(Random.Range(5f, 7f), 0, Random.Range(5f, 10f));

	}
	
	// Update is called once per frame
	void Update () {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerAIGoal")
        {
            GameObject.Find("ScoreUI").GetComponent<ScoreUI>().scorePlayerAI = GameObject.Find("ScoreUI").GetComponent<ScoreUI>().scorePlayerAI + 1;
            Puck.transform.position = new Vector3(0f, 1f, 0f);
            rb.velocity = new Vector3(0f, 0f, 0f);
            Invoke("PleaseResetforAI", 2f);
        }
        if (collision.gameObject.tag == "PlayerGoal")
        {
            GameObject.Find("ScoreUI").GetComponent<ScoreUI>().scorePlayer = GameObject.Find("ScoreUI").GetComponent<ScoreUI>().scorePlayer + 1;
            Puck.transform.position = new Vector3(0f, 1f, 0f);
            rb.velocity = new Vector3(0f, 0f, 0f);
            Invoke("PleaseResetforPlayer", 2f);

        }
        if (collision.gameObject.tag == "PlayerController" || collision.gameObject.tag == "AIController" )
        {
          
            rb.velocity = rb.velocity * 1.1f;
        }
       
    }

    void PleaseResetforPlayer()
    {

       rb.velocity = new Vector3(Random.Range(5f, 7f), 0, Random.Range(-10f, -5f));
    }

    void PleaseResetforAI()
    {

       rb.velocity = new Vector3(-Random.Range(5f, 7f), 0, Random.Range(5f, 10f));
    }
}
