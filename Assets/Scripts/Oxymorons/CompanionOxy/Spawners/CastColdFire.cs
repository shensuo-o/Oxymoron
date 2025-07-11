using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastColdFire : Oximorons
{
    public Transform target;

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
                gameObject.GetComponentInParent<CompanionMovement>().setAim();
                Instantiate(proyectile, target.position, Quaternion.identity);
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
}
