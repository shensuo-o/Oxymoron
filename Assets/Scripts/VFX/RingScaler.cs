using System.Collections;
using UnityEngine;

public class RingScaler : MonoBehaviour
{
    public Vector3 finalScale = new Vector3(1, 1, 1); // Que tan grandote va a tar el anillo
    public float duration = 2f;
    public float shrinkDuration = 2f;
    public float totalVisibleTime = 8f;

    private void OnEnable()
    {
        transform.localScale = Vector3.zero;
        StartCoroutine(ScaleRoutine());
    }

    private IEnumerator ScaleRoutine()
    {
        yield return StartCoroutine(ScaleOverTime(Vector3.zero, finalScale, duration));

        float waitTime = Mathf.Max(0f, totalVisibleTime - duration);
        yield return new WaitForSeconds(waitTime);

        yield return StartCoroutine(ScaleOverTime(finalScale, Vector3.zero, shrinkDuration));
    }

    private IEnumerator ScaleOverTime(Vector3 start, Vector3 end, float time)
    {
        float elapsed = 0f;
        while (elapsed < time)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / time;
            transform.localScale = Vector3.Lerp(start, end, t);
            yield return null;
        }

        transform.localScale = end;
    }
}


