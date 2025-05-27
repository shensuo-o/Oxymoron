using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingScaler : MonoBehaviour
{
    public Vector3 finalScale = new Vector3(1, 1, 1); // Que tan grandote va a tar el anillo (como el de tu senora)
    public float duration = 2f; // Tiempo que tarda en escalarse.... como el anillo de tu senora

    private void OnEnable()
    {
        transform.localScale = Vector3.zero; // Empieza en tamaño 0, como tu senora
        StartCoroutine(ScaleUp());
    }

    private System.Collections.IEnumerator ScaleUp()
    {
        float elapsed = 0f;
        Vector3 initialScale = Vector3.zero;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            transform.localScale = Vector3.Lerp(initialScale, finalScale, t);
            yield return null;
        }

        transform.localScale = finalScale; // Asegura que quede exacto al final, del tamano del anillo de tu senora
    }
}

