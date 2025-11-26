using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckPoint : MonoBehaviour
{
    public GameObject prompt;
    public ParticleSystem particles;
    public bool isSaving = false;
    public Personaje player;
    public Animator animator;
    public AnimationClip clip;
    public AnimationClip compClip;
    public CompanionMovement comp;
    public CompanionAnimations companionAnimations;
    public GameObject animTarget;
    public GameObject tempTarget;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7 && !isSaving)
        {
            player = other.GetComponent<Personaje>();
            prompt.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 7 && !isSaving)
        {
            if (Input.GetKey(KeyCode.E))
            {
                StartCoroutine(Save());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            prompt.SetActive(false);
        }
    }

    private IEnumerator CompStartReading(bool set)
    {
        if (set == true)
        {
            tempTarget = comp.target;
            comp.target = animTarget;
            while (comp.rb.velocity.magnitude > 0)
            {
                yield return null;
            }
        }
        else if (set == false)
        {
            comp.target = tempTarget;
        }

        companionAnimations.PlayAnimation(compClip, set);
    }

    IEnumerator Save()
    {
        isSaving = true;
        StartCoroutine(CompStartReading(true));
        animator.SetBool(clip.name, isSaving);
        prompt.SetActive(false);
        player.HP = 100;
        Debug.LogWarning("Saved Game bya player CheckPoint.");
        particles.Play();
        DataPersistenceManager.Instance.SaveGame();
        while (comp.rb.velocity.magnitude > 0)
        {
            yield return null;
        }
        yield return new WaitForSeconds(3.4f);
        StartCoroutine(CompStartReading(false));
        isSaving = false;
        animator.SetBool(clip.name, isSaving);
    }
}
