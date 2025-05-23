using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TormentaTranquila : OxyCompanion
{
    [SerializeField] private GameObject remolinoPrefab; // Prefab del remolino
    [SerializeField] private float remolinoSpeed = 5f;   // Velocidad del remolino

    protected override void CheckQ()
    {
        if (gameObject.activeInHierarchy && Input.GetKeyDown(KeyCode.Alpha3))
        {
            Action();
        }
    }

    protected override void Action()
    {
        Debug.Log("Tormenta Tranquila");

        if (Character != null)
        {
            // 1. Distancia entre cámara y personaje para calcular el punto Z del mouse
            float zDist = Mathf.Abs(Camera.main.transform.position.z - Character.transform.position.z);

            // 2. Obtener posición del mouse en el mundo
            Vector3 mouseScreenPos = Input.mousePosition;
            mouseScreenPos.z = zDist;
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
            mouseWorldPos.z = Character.transform.position.z; // corregimos Z para mantenerlo en el mismo plano

            // 3. Dirección del remolino
            Vector3 spawnPosition = Character.transform.position;
            Vector3 direction = (mouseWorldPos - spawnPosition).normalized;

            // 4. Instanciar el remolino en la dirección deseada
            GameObject nuevoRemolino = Instantiate(remolinoPrefab, spawnPosition, Quaternion.LookRotation(Vector3.forward));

            // 5. Aplicar velocidad con Rigidbody
            Rigidbody rb = nuevoRemolino.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = direction * remolinoSpeed;
            }

            // 6. Configurar el remolino (si necesita referencia al personaje)
            Remolino remolinoScript = nuevoRemolino.GetComponent<Remolino>();
            if (remolinoScript != null)
            {
                remolinoScript.SetPersonaje(Character);
            }

            // (Opcional) Efectos visuales o sonoros
        }
        else
        {
            Debug.LogError("El objeto Character no está asignado correctamente.");
        }
    }
}
