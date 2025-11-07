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

    IEnumerator Save()
    {
        isSaving = true;
        CompanionAnimations.Instance.PlayAnimation(compClip, true);
        animator.SetBool(clip.name, isSaving);
        prompt.SetActive(false);
        player.HP = 100;
        Debug.LogWarning("Saved Game bya player CheckPoint.");
        particles.Play();
        DataPersistenceManager.Instance.SaveGame();
        yield return new WaitForSeconds(1.4f);
        CompanionAnimations.Instance.PlayAnimation(compClip, false);
        yield return new WaitForSeconds(2f);
        isSaving = false;
        animator.SetBool(clip.name, isSaving);
    }
}
