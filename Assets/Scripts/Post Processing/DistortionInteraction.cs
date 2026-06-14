using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistortionInteraction : MonoBehaviour
{
    [Header("<color=green>Rendering</color>")]
    [SerializeField] private string _sqrDistName = "_DistDist";
    [SerializeField] private Material _fire;
    [SerializeField] private GameObject _chimenea;
    private ParticleSystem _particleSystem;

    private GameObject player;

    [Header("<color=yellow>Gizmo</color>")]
    [SerializeField] private float distortionRadius = 10f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Leif");
        _particleSystem = _chimenea.GetComponentInChildren<ParticleSystem>();
    }

    private void Update()
    {
        if (player == null || _particleSystem == null || !_particleSystem.gameObject.activeInHierarchy) return;

        float distance = Vector3.Distance(_chimenea.transform.position, player.transform.position);
        float intensity = Mathf.Clamp01(distance / distortionRadius);

        float current = _fire.GetFloat(_sqrDistName);
        _fire.SetFloat(_sqrDistName, Mathf.Min(current, intensity));
    }

    private void OnDrawGizmosSelected()
    {
        if (_chimenea == null) return;

        Gizmos.color = new Color(1f, 0.5f, 0f, 0.3f);
        Gizmos.DrawSphere(_chimenea.transform.position, distortionRadius);

        Gizmos.color = new Color(1f, 0.5f, 0f, 1f);
        Gizmos.DrawWireSphere(_chimenea.transform.position, distortionRadius);
    }
}
