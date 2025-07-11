using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private AudioSource source;
    public AudioClip clips;
    public ParticleSystem fireflies;
    public Color newColor;
    public bool madeSound = false;

    private void Awake()
    {
        source = this.GetComponent<AudioSource>();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
 
            SaveSpawn.Instance.transform.position = transform.position;
            if(!madeSound)
            {
                PlaySound(clips);
                madeSound = true;
            }
        
            Color colorWithAlpha = new Color(newColor.r, newColor.g, newColor.b, 1f);
            var mainPS = fireflies.main;
            var noisePS = fireflies.noise;
            mainPS.startColor = new ParticleSystem.MinMaxGradient(colorWithAlpha);
            noisePS.strength = 3;
        }
    }


    public void PlaySound(AudioClip clip)
    {
        source.clip = clip;
        source.Play();
    }
}
