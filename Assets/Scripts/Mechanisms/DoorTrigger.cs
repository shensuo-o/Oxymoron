using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameObject thingToMove;
    public bool open;
    public float Vertical;
    public int layer;

    public AudioSource source;
    public AudioClip AudioCast;
    public Animator animator;

    public GameObject animatedObject;
    private void Start()
    {
        open = false;
        animator = animatedObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == layer && !open)
        {
            thingToMove.transform.position += new Vector3(0, Vertical, 0);
            open = true;

            if (animator != null)
            {
                animator.SetBool("Solved", true);
                PlaySound(AudioCast);
            }

           
            other.gameObject.SetActive(false);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        source.clip = clip;
        source.Play();
    }
}
