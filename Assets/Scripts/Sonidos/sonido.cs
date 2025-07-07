using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sonido : MonoBehaviour
{
    public AudioSource source;

    /*public void PlaySound(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }

    public void StopSound()
    {
        if (source.isPlaying)
        {
            source.Stop();
        }
    }*/

    public void PlaySound(AudioClip clip)
    {
        source.clip = clip;
        source.Play();
    }

    public void StopSound()
    {
        if (source.isPlaying)
            source.Stop();
    }

}

