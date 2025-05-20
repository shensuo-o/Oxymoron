using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProximityTrigger : MonoBehaviour
{
    [SerializeField] private GameObject Leif;
    [SerializeField] private GameObject prompt;

    [SerializeField] private float TriggerDistance;
    [SerializeField] private string Message;
    [SerializeField] private float timeToRead;
    [SerializeField] private float currentSpeed;

    void Awake()
    {
        Leif = GameObject.Find("Leif");
    }

    void Update()
    {
        var dist = transform.position - Leif.transform.position; //Mide la distancia entre Leif y el tutorial.
        if (dist.magnitude <= TriggerDistance)
        {
            SetTutorialActive();//Activa el texto del tutorial.
        }

        if (timeToRead <= 0)
        {
            SetNextTutorial();//Apaga el texto, activa el siguiente tutorial y se desactiva a si mismo.
        }
    }

    private void SetTutorialActive()
    {
        prompt.SetActive(true);
        prompt.GetComponent<TextMeshProUGUI>().text = Message;

        currentSpeed = Leif.GetComponent<Personaje>().Speed;
        Leif.GetComponent<Personaje>().Speed = 0;

        timeToRead -= Time.deltaTime;
    }

    private void SetNextTutorial()
    {
        prompt.SetActive(false);
        Leif.GetComponent<Personaje>().Speed = currentSpeed;
        InteractionsManager.Instance.SetNext();
        gameObject.SetActive(false);
    }
}
