using UnityEngine;

public class LoudnessFromClip : MonoBehaviour
{
    public int sampleWindow = 64;
    public AudioSource source;
    public float minValue = 0, maxValue = 1;

    public float loudnessSensibility = 1f;
    public float threshold = 0.1f;

    void Start()
    {
        if(source == null)
        {
            source = GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        //GetLoudnessFromAudioSource();
    }

    public float GetLoudnessFromAudioSource()
    {
        float loudness = GetLoudnessFromAudioClip(source.timeSamples, source.clip) * loudnessSensibility;

        if (loudness < threshold)
            loudness = 0;

        loudness = Mathf.Lerp(minValue, maxValue, loudness);

        //Debug.Log(loudness);

        return loudness;
    }

    float GetLoudnessFromAudioClip(int clipPosition, AudioClip clip)
    {

        int startPosition = clipPosition - sampleWindow;

        if (startPosition < 0)
            return 0;

        float[] waveDate = new float[sampleWindow];
        clip.GetData(waveDate, startPosition);

        //compute loudness
        float totalLoudness = 0;

        for (int i = 0; i < sampleWindow; i++)
        {
            totalLoudness += Mathf.Abs(waveDate[1]);
        }

        return totalLoudness / sampleWindow;
    }
}
