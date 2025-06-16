using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeifKnockBack : MonoBehaviour
{
    public float knockBackTime = 0.2f;
    public float directionForce = 10f;
    public float constForce = 5f;
    public float inoutForce = 7.5f;

    [SerializeField] private Rigidbody rb;

    private Coroutine knockBackC;

    public bool isHit { get; private set; }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public IEnumerator KnockBack(Vector3 direction, Vector3 constDir, float inputDir)
    {
        isHit = true;

        Vector3 _hitForce;
        Vector3 _constForce;
        Vector3 _force;
        Vector3 _combForce;

        _hitForce = direction * directionForce;
        _constForce = constDir * constForce;

        float elapsedTime = 0f;

        while (elapsedTime < knockBackTime) 
        { 
            elapsedTime += Time.fixedDeltaTime;

            _force = _hitForce + _constForce;

            if (inputDir != 0)
            {
                _combForce = _force + new Vector3(inputDir, 0f, 0f);
            }
            else
            {
                _combForce = _force;
            }

            rb.velocity = _combForce;

            yield return new WaitForFixedUpdate();
        }

        isHit = false;
    }

    public void Knock(Vector3 direction, Vector3 constDir, float inputDir)
    {
        knockBackC = StartCoroutine(KnockBack(direction, constDir, inputDir));
    }
}
