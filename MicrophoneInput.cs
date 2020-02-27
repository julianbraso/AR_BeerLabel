using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class MicrophoneInput : MonoBehaviour
{
    public float sensitivity = 100;
    public float loudness = 0;
    AudioSource audioRef;

    void Start()
    {
        audioRef = GetComponent<AudioSource>();
        audioRef.clip = Microphone.Start(null, true, 10, 44100);
        iPhoneSpeaker.ForceToSpeaker();
        audioRef.loop = true; // Set the AudioClip to loop
        audioRef.mute = false; // Mute the sound, we don't want the player to hear it
        while (!(Microphone.GetPosition(null) > 0)) { } // Wait until the recording has started
        audioRef.Play(); // Play the audio source!
    }

    void Update()
    {
        loudness = GetAveragedVolume() * sensitivity;
    }

    float GetAveragedVolume()
    {
        float[] data = new float[256];
        float a = 0;
        audioRef.GetOutputData(data, 0);
        foreach (float s in data)
        {
            a += Mathf.Abs(s);
        }
        return a / 256;
    }
}