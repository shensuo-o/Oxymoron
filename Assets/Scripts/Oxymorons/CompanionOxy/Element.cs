using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Element : MonoBehaviour
{
    public string elementType;
    public GameObject particles;
    public Sprite icon;
    [SerializeField] private float coolDown;

    [ColorUsage(hdr: true, showAlpha: true)]
    [SerializeField] private Color particleColor;
    [SerializeField] private float intensity;

    public void LightUp()
    {
        particles.GetComponent<ParticleSystem>().GetComponent<ParticleSystemRenderer>().material.SetColor("_Intensity", particleColor * intensity);
    }

    public void LightDown()
    {
        particles.GetComponent<ParticleSystem>().GetComponent<ParticleSystemRenderer>().material.SetColor("_Intensity", particleColor);
    }

    public void SpeedUp()
    {
        particles.GetComponent<ParticleSystem>().playbackSpeed += 0.05f;
    }

    public void SpeedDown()
    {
        particles.GetComponent<ParticleSystem>().playbackSpeed = 1;
    }

    public IEnumerator TurnOffAndOn()
    {
        SpeedDown();
        LightDown();
        gameObject.GetComponent<SphereCollider>().enabled = false;
        particles.SetActive(false);
        yield return new WaitForSeconds(coolDown);
        gameObject.GetComponent<SphereCollider>().enabled = true;
        particles.SetActive(true);
    }

}
