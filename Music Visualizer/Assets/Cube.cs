using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{


    public float startScale;
    public float scaleMultiplier;
    public int band;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 8; i++)
        {







            this.transform.localScale = new Vector3(1, SpectrumAnalyzer.audioBands[band-1] * scaleMultiplier + startScale, 1);


        }
    }
}
