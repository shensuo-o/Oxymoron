using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sonido : MonoBehaviour
{
    public AudioSource source;

    public void PlaySound(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }
}
