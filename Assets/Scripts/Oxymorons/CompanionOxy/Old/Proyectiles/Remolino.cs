using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remolino : MonoBehaviour
{
    [SerializeField] private float velocidad = 10f;
    [SerializeField] private float tiempoDeVida = 5f;
    [SerializeField] private float tiempoQuietoAntesDeMorir = 1f;
    [SerializeField] private float fuerzaLevantamiento = 5f;
    [SerializeField] private GameObject personaje;

    private float tiempoTranscurrido = 0f;
    private bool estaQuieto = false;
    private List<Rigidbody> enemigosLevantados = new List<Rigidbody>();
    private Vector3 direccionMovimiento;

    public void SetVelocidad(float v)
    {
        velocidad = v;
    }

    public void SetPersonaje(GameObject p)
    {
        personaje = p;
        float direccionX = Mathf.Sign(personaje.transform.localScale.x);
        direccionMovimiento = Vector3.right * direccionX;
    }

    void Start()
    {
        if (personaje == null)
        {
            Debug.LogWarning("Personaje no asignado al remolino.");
            direccionMovimiento = Vector3.right;
        }
        Invoke(nameof(Desaparecer), tiempoDeVida);
    }

    void Update()
    {
        tiempoTranscurrido += Time.deltaTime;

        if (tiempoTranscurrido < tiempoDeVida - tiempoQuietoAntesDeMorir)
        {
            transform.Translate(direccionMovimiento * velocidad * Time.deltaTime);
        }
        else if (!estaQuieto)
        {
            estaQuieto = true;
            Debug.Log("Remolino se detiene.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null && !enemigosLevantados.Contains(rb))
            {
                rb.useGravity = false;
                rb.velocity = Vector3.zero;
                rb.AddForce(Vector3.up * fuerzaLevantamiento, ForceMode.Impulse);
                enemigosLevantados.Add(rb);
                Debug.Log("Enemigo levantado y flotando.");
            }
        }
    }

    private void Desaparecer()
    {
        foreach (Rigidbody rb in enemigosLevantados)
        {
            if (rb != null)
            {
                rb.useGravity = true;
            }
        }

        Destroy(gameObject);
    }
}



