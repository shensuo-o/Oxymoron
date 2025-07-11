using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ShadowLightCast : StatsOximorones
{
    [SerializeField] private Vector3 velocity = Vector3.zero;
    [SerializeField] private float damp = 0.03f;

    [SerializeField] private float time = 0;
    [SerializeField] private float coolDown = 0.5f;

    [SerializeField] private AudioSource Source;
    [SerializeField] private AudioClip AudioCast;

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
        time += Time.deltaTime;
        if (time <= coolDown)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 50;
            Vector3 pos = Camera.main.ScreenToWorldPoint(mousePos);

            transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, damp);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 10 || other.gameObject.layer == 16)
        {
            timer += Time.deltaTime;
            if(other.gameObject.GetComponent<Collider>() != null)
            {
                other.gameObject.GetComponent<Rigidbody>().useGravity = false;
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
        if (other.gameObject.layer == 10 || other.gameObject.layer == 16)
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
