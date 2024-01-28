using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class hitSoundOnCollide : MonoBehaviour
{
    public AudioSource source;

    public float minPitch = 0.8f;
    public float maxPitch = 1.2f;

    void Start()
    {
        if (source == null)
        {
            source = GetComponent<AudioSource>();
        }
    }



    // This method is called when a collision is detected
    void OnCollisionEnter(Collision collision)
    {
        // Randomize the pitch
        source.pitch = Random.Range(minPitch, maxPitch);

        // Play the sound
        source.Play();
    }
}