using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckPoint : MonoBehaviour
{
    public GameObject prompt;
    public ParticleSystem particles;
    public bool isSaving = false;
    public Personaje player;

    private void Start()
    {
        //prompt = GameObject.Find("PressEToElement");
    }

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
        prompt.SetActive(false);
        player.HP = 100;
        Debug.LogWarning("Saved Game bya player CheckPoint.");
        particles.Play();
        DataPersistenceManager.Instance.SaveGame();
        yield return new WaitForSeconds(3);
        isSaving = false;
    }
}
