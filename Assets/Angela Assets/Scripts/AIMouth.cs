using UnityEngine;


    public class AIMouth : MonoBehaviour {
        public Transform mouth;

        public AudioSource _voice;
        private float _mouthSize;

    public int sampleWindow = 64;
    
    public float minValue = 0, maxValue = 1;

    public float loudnessSensibility = 1f;
    public float threshold = 0.1f;

    void Start()
    {
        if (_voice == null)
        {
            _voice = GetComponent<AudioSource>();
        }
    }

    

    void Update() {
    //Debug.Log(_voice.volume.ToString());
        // Use the current voice volume (a value between 0 - 1) to calculate the target mouth size (between 0.1 and 1.0)
        float targetMouthSize = Mathf.Lerp(0.1f, 1.0f, GetLoudnessFromAudioSource());

        // Animate the mouth size towards the target mouth size to keep the open / close animation smooth
        _mouthSize = Mathf.Lerp(_mouthSize, targetMouthSize, 30.0f * Time.deltaTime);

        // Apply the mouth size to the scale of the mouth geometry
        Vector3 localScale = mouth.localScale;
        localScale.y = _mouthSize;
        mouth.localScale = localScale;
    }

    public float GetLoudnessFromAudioSource()
    {
        float loudness = GetLoudnessFromAudioClip(_voice.timeSamples, _voice.clip) * loudnessSensibility;

        if (loudness < threshold)
            loudness = 0;

      //  loudness = Mathf.Lerp(minValue, maxValue, loudness);

       // Debug.Log(loudness);

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



