using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Experimental;
using UnityEngine;

public class ShadowLightCast : StatsOximorones
{
    [SerializeField] private Vector3 velocity = Vector3.zero;
    [SerializeField] private float damp = 0.03f;

    [SerializeField] private AudioSource Source;
    [SerializeField] private AudioClip AudioCast;

    [SerializeField] private ParticleSystem[] particles;
    [SerializeField] private GameObject endParticles;
    [SerializeField] private RingScaler esfera;

    private void Start()
    {
        Destroy(this.gameObject, lifeTime);
    }

    private void Awake()
    {
        PlaySound(AudioCast);
    }

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 50;
            Vector3 pos = Camera.main.ScreenToWorldPoint(mousePos);

            transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, damp);
        }
        if(Input.GetMouseButtonUp(1))
        {
            Source.Stop();
            for (int i = 0; i < particles.Length; i++)
            {
                particles[i].gameObject.SetActive(false);
            }
            endParticles.SetActive(true);
            esfera.EarlyScale(new Vector3(0.8f, 0.8f, 0.8f), Vector3.zero, 1);
            Destroy(this.gameObject, 0.5f);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10 || other.gameObject.layer == 3)
        {
            if (other.gameObject.GetComponent<Collider>() != null)
            {
                other.gameObject.GetComponent<Rigidbody>().useGravity = false;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 10 || other.gameObject.layer == 3)
        {
            timer += Time.deltaTime;
            if (other.gameObject.GetComponent<Collider>() != null)
            {
                other.gameObject.transform.position = Vector3.MoveTowards(other.transform.position, transform.position, force * Time.deltaTime);
                if (timer >= lifeTime - 0.5f)
                {
                    other.gameObject.GetComponent<Rigidbody>().useGravity = true;
                }
            }
        } 
    }

    

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 10 || other.gameObject.layer == 3)
        {
            other.gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }

    public void PlaySound(AudioClip clip)
    {
        Source.clip = clip;
        Source.Play();
    }
}
