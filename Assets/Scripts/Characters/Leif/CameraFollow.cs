using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    #region Variables Movimiento
    [SerializeField] private Transform leif;
    [SerializeField] private float damp;
    [SerializeField] private Vector3 velocity = Vector3.zero;
    [SerializeField] private float offSet;
    [SerializeField] private float offSetSpeed;
    #endregion

    [SerializeField] private AnimationCurve curve;
    [SerializeField] private bool follow;
    [SerializeField] private float dampMove;

    private void Awake()
    {
        leif = GameObject.Find("Leif").GetComponent<Transform>();
    }

    private void Update()
    {
        if (follow)
        {
            if (Input.GetKey(KeyCode.W))
            {
                offSet += offSetSpeed * Time.deltaTime;
                offSet = Mathf.Clamp(offSet, 0, 8);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                offSet -= offSetSpeed * Time.deltaTime;
                offSet = Mathf.Clamp(offSet, 0, 8);
            }
            else
            {
                if (offSet > 4)
                {
                    offSet -= offSetSpeed * Time.deltaTime;
                    offSet = Mathf.Clamp(offSet, 4, 8);
                }
                else if (offSet < 4)
                {
                    offSet += offSetSpeed * Time.deltaTime;
                    offSet = Mathf.Clamp(offSet, 0, 4);
                }
                else
                {
                    offSet = 4;
                }
            }
        }
    }

    void FixedUpdate()
    {
        if (follow)
        {
            var targetPosition = leif.position + new Vector3(0, offSet, 0);
            Vector3 temp = Vector3.SmoothDamp(transform.position, new Vector3(targetPosition.x, targetPosition.y, -50), ref velocity, damp);
            transform.position = new Vector3(temp.x, leif.transform.position.y + offSet, temp.z);
        }
    }

    public void CallShake(float duracion)
    {
        StartCoroutine(CameraShake(duracion));
    }

    IEnumerator CameraShake(float duration)
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(elapsedTime / duration);
            transform.position = startPosition + Random.insideUnitSphere * strength;
            yield return null;
        }
        transform.position = startPosition;
    }

    public void CallMove(float duracion)
    {
        StartCoroutine(CameraMove(duracion));
    }

    IEnumerator CameraMove(float duration)
    {
        float timeBack = 0;
        while (timeBack < duration)
        {
            timeBack += Time.deltaTime;
            Vector3 temp = Vector3.SmoothDamp(transform.position, new Vector3(leif.position.x, leif.position.y + offSet, -50), ref velocity, dampMove);
            transform.position = temp;
            yield return null;
        }
        follow = true;
    }

    public void CallMoveAndShake(float duracion, Vector3 objetivo)
    {
        StartCoroutine(CameraMoveAndShake(duracion, objetivo));
    }

    IEnumerator CameraMoveAndShake(float duration, Vector3 target)
    {
        yield return new WaitForSeconds(1);
        follow = false;
        float time = 0;

        while (time < duration)
        {
            time += Time.deltaTime;
            Vector3 temp = Vector3.SmoothDamp(transform.position, new Vector3(target.x, target.y, target.z - 50), ref velocity, dampMove);
            float strength = curve.Evaluate(time / duration);
            Vector3 shake = temp + Random.insideUnitSphere * strength;
            transform.position = new Vector3 (shake.x, shake.y, target.z - 50);
            yield return null;
        }
        CallMove(duration);
    }
}
