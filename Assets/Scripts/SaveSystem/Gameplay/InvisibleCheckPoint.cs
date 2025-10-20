using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleCheckPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            Debug.LogWarning("Saved game bya invisible CheckPoint.");
            DataPersistenceManager.Instance.SaveGame();
        }
    }
}
