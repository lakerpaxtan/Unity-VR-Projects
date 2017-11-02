using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{

    public HW1ScriptManager manager;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (manager.currentScore == manager.maxScore)
            {
                manager.winText.text = "You Win!";
            }
        }
    }
}