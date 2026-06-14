using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDistortionReset : MonoBehaviour
{
    [SerializeField] private Material _fire;
    [SerializeField] private string _sqrDistName = "_DistDist";

    private void Update()
    {
        _fire.SetFloat(_sqrDistName, 1f);
    }
}
