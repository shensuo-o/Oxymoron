using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowLight : Oximorons
{
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
                PlayCast();
                Vector3 mousePos = Input.mousePosition;
                mousePos.z = 50;
                Vector3 pos = Camera.main.ScreenToWorldPoint(mousePos);
                Instantiate(proyectile, pos, Quaternion.identity);
                //PlaySound(AudioCast);
                charges--;
                ResetCoolDown();
                if (charges <= 0)
                {
                    TurnOff();
                }
                ClearSlot();

            }
        }
    }
    /*public void PlaySound(AudioClip clip)
    {
        source.clip = clip;
        source.Play();
    }*/
}
