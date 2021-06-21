using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerAudio : MonoBehaviour
{
    public AudioClip[] footsteps;

    private AudioSource audioS;

    private int perlinNoiseIndex = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        audioS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayFootstep()
    {
        //Don't want to use a random function.
        audioS.PlayOneShot(footsteps[Random.RandomRange(0, footsteps.Length)]);
        perlinNoiseIndex++;
    }

    public bool currentlyPlaying()
    {
        return audioS.isPlaying;
    }
}
