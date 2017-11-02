using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpectrumAnalyzer : MonoBehaviour {

    AudioSource audioSource;
    public static float[] samples = new float[512];
    public static float[] freqBand = new float[8];


	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        GetSpectrumAudioSource();
        MakeFrequencyBands();
        CreateAudioBands();
	}

    void GetSpectrumAudioSource()
    {
        audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }

    void MakeFrequencyBands()
    {
        int count = 0;

        for (int i = 0; i<8; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i + 1);

            if (i==7)
            {
                sampleCount += 2; 
            }

            for (int j = 0; j<sampleCount; j++)
            {
                average += samples[count];
                count++;
            }

            average /= count;
            freqBand[i] = (i + 1) * 100 * average;
        }
        
    }

    float[] freqBandHighest = new float[8];
    public static float[] audioBands = new float[8];

    void CreateAudioBands()
    {
        for (int i=0; i<8; i++)
        {
            if (freqBandHighest[i] < freqBand[i]) 
            {
                freqBandHighest[i] = freqBand[i];
            }
        }

        for (int i = 0; i < 8; i++)
        {
            audioBands[i] = (freqBand[i] / freqBandHighest[i]);
        }



    }
}

    
