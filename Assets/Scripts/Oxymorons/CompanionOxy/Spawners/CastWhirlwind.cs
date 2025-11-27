using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastWhirlwind : Oximorons
{
    [SerializeField] private Transform spawnPoint;
    //public AudioSource source;
    //public AudioClip AudioCast;

    private void Awake()
    {
        time = cooldown;
    }

    void Update()
    {
        time += Time.deltaTime;
        time = Mathf.Clamp(time, 0, cooldown);

        if (slots[CompanionInventory.Instance.index] != null)
        {

            if (Input.GetMouseButtonDown(1) && time >= cooldown)
            {
                //PlaySound(AudioCast);
                StartCoroutine(SpawnAttack());
            }
        } 
    }

    private IEnumerator SpawnAttack()
    {
        trailSpawner.trailRenderer.gameObject.SetActive(true);
        trailSpawner.moveOn = true;
        yield return new WaitForSeconds(0.8f);
        trailSpawner.trailRenderer.gameObject.SetActive(false);
        trailSpawner.moveOn = false;
        PlayCast();
        Instantiate(proyectile, spawnPoint.position, spawnPoint.rotation);
        charges--;
        ResetCoolDown();
        if (charges <= 0)
        {
            TurnOff();
        }
        ClearSlot();
    }
    /*public void PlaySound(AudioClip clip)
    {
        source.clip = clip;
        source.Play();
    }*/
}
