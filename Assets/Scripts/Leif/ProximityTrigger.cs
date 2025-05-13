using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProximityTrigger : MonoBehaviour
{
    [SerializeField] private GameObject Leif;
    [SerializeField] private float TriggerDistance;
    [SerializeField] private GameObject prompt;
    [SerializeField] private string Type;
    [SerializeField] private string Message;
    [SerializeField] private float timeToRead;
    [SerializeField] private bool isRead;

    void Awake()
    {
        Leif = GameObject.Find("Leif");
        isRead = false;
    }

    void Update()
    {
        var dist = transform.position - Leif.transform.position;

        if (dist.magnitude <= TriggerDistance && timeToRead >= 0)
        {
            prompt.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E) && Type == "Item")
            {
                Leif.GetComponent<Inventario>().AddItem(this.gameObject);
                prompt.SetActive(false);
                this.gameObject.SetActive(false);
            }
            else if(Type == "Tutorial")
            {
                isRead = true;
                timeToRead -= Time.deltaTime;
                prompt.gameObject.GetComponent<TextMeshProUGUI>().text = Message;
            }
        }
        else
        {
            if (isRead)
            {
                timeToRead = 0;
            }

            prompt.SetActive(false);

            if (timeToRead <= 0)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
