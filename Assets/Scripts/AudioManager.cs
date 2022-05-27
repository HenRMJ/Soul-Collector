using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    private void Awake()
    {
        // this creates an audio source for each sound so multiple can play at once, and sets the parameters for the audio source
        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
        }
    }

    public void PlaySound(string name)
    {
        Sound currentSound = Array.Find(sounds, sound => sound.name == name);
        currentSound.source.Play();
    }
}
