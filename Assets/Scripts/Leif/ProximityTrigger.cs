using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityTrigger : MonoBehaviour
{
    [SerializeField] private GameObject Leif;
    [SerializeField] private float TriggerDistance;
    [SerializeField] private GameObject prompt;
    [SerializeField] private string Type;

    void Awake()
    {
        Leif = GameObject.Find("Leif");
    }

    void Update()
    {
        var dist = transform.position - Leif.transform.position;

        if (dist.magnitude <= TriggerDistance)
        {
            prompt.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E) && Type == "Item")
            {
                Leif.GetComponent<Inventario>().AddItem(this.gameObject);
                prompt.SetActive(false);
                this.gameObject.SetActive(false);
            }
        }
        else
        {
            prompt.SetActive(false);
        }
    }
}
