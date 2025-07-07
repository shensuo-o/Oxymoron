using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastWhirlwind : Oximorons
{
    [SerializeField] private Transform spawnPoint;

    void Update()
    {
        time += Time.deltaTime;
        time = Mathf.Clamp(time, 0, cooldown);
        if (slots[CompanionInventory.Instance.index] != null)
        {
            if (Input.GetMouseButtonDown(1) && time >= cooldown)
            {
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
        } 
    }
}
