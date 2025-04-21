using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionMovement : MonoBehaviour
{
    #region VariablesMovimiento

    [SerializeField] private GameObject target;
    [SerializeField] private Rigidbody rb;

    [SerializeField] private float speed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float maxDistancePredict;
    [SerializeField] private float minDistancePredict;
    [SerializeField] private float maxTimePrediction;
    [SerializeField] private float deviationAmount;
    [SerializeField] private float deviationSpeed;
    [SerializeField] private float distance;

    private Vector3 prediction;
    private Vector3 deviation;

    [SerializeField] private Animator animator;

    [SerializeField] private bool isAiming;
    [SerializeField] private Transform mira;

    #endregion

    void Start()
    {
        target = GameObject.Find("CompTarget");
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isAiming = !isAiming;
        }
    }

    #region Movement

    void FixedUpdate()
    {
        var Dis = Vector3.Distance(transform.position, target.transform.position);

        if (Dis >= distance && !isAiming)
        {
            animator.SetBool("IsIdle", false);

            rb.velocity = transform.forward * speed;

            var leadTimePercentage = Mathf.InverseLerp(minDistancePredict, minDistancePredict,
                Vector3.Distance(transform.position, target.transform.position));

            PredictMovement(leadTimePercentage);

            AddDeviation(leadTimePercentage);

            RotateComp();
        }
        else if (Dis < distance && !isAiming) 
        {
            rb.velocity = new Vector3(0, 0, 0);
            animator.SetBool("IsIdle", true);
        }
        else if (isAiming)
        {
            transform.position = mira.transform.position;
            animator.SetBool("IsIdle", false);
            rb.velocity = new Vector3(0, 0, 0);
        }
    }

    private void PredictMovement(float leadTimePrecentage)
    {
        var predictionTime = Mathf.Lerp(0, maxTimePrediction, leadTimePrecentage);

        prediction = target.transform.position + rb.velocity * predictionTime;
    }

    private void AddDeviation(float leadTimePrecentage)
    {
        var dev = new Vector3(Mathf.Cos(Time.time * deviationSpeed), 0, 0);

        var predictionOffset = transform.TransformDirection(dev) * deviationAmount * leadTimePrecentage;

        deviation = prediction + predictionOffset;
    }

    private void RotateComp()
    {
        var heading = deviation - transform.position;

        var rotation = Quaternion.LookRotation(heading);

        rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, rotation, rotateSpeed * Time.deltaTime));
    }
}

#endregion
