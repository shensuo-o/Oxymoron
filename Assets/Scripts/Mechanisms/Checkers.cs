using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Checkers : MonoBehaviour
{
    public GameManager GameManager;
    public string Trigger;
    public bool isWater;

    public GameObject animatedObject;
    public AudioSource source;
    public AudioClip AudioCast;


    private void OnTriggerEnter(Collider other)
    {
        /*if (Trigger == "Blue")
        {
            GameManager.CheckAmarillo = true;
            other.transform.position = new Vector3 (transform.position.x, transform.position.y - 0.5f, 0);
            other.gameObject.GetComponent<Collider>().enabled = false;
        }   

        if (Trigger == "Red")
        {    
            GameManager.CheckRojo = true;
            other.transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, 0);
            other.gameObject.GetComponent<Collider>().enabled = false;
        }        

        if (Trigger == "Green")    
        {    
            GameManager.CheckVerde = true;
            other.transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, 0);
            other.gameObject.GetComponent<Collider>().enabled = false;
        }    

        if (Trigger == "Yellow")
        {
            GameManager.CheckRosa = true;
            other.transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, 0);
            other.gameObject.GetComponent<Collider>().enabled = false;
        }*/

        Animator anim = animatedObject.GetComponent<Animator>();


        switch (Trigger)
        {
            case "Blue":
                GameManager.CheckAmarillo = true;
                PlaySound(AudioCast);
                break;
            case "Red":
                GameManager.CheckRojo = true;
                PlaySound(AudioCast);
                break;
            case "Green":
                GameManager.CheckVerde = true;
                PlaySound(AudioCast);
                break;
            case "Yellow":
                GameManager.CheckRosa = true;
                PlaySound(AudioCast);
                break;
        }

        if (anim != null)
        {
            anim.SetBool("Solved", true);
        }

        // Desactiva el objeto que entró (podés usar SetActive(false) si querés ocultarlo completo)
        other.gameObject.SetActive(false);

        if (Trigger == "AttackDetection" && !isWater)
        {
            GameManager.Finish = true;
            SaveSpawn.Instance.transform.position = new Vector3(-274.44f, 3.02f, 0);
        }

        if (Trigger == "AttackDetection" && isWater)
        {
            GameManager.Death = true;
        }    
    }
    public void PlaySound(AudioClip clip)
    {
        source.clip = clip;
        source.Play();
    }
}
