using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Statue : MonoBehaviour
{
    [SerializeField] private Puzzle_Statues puzzle;

    public int index;

    public bool solved = false;

    public bool error = false;

    public Transform dock;

    public GameObject item;

    public GameObject pull;

    public GameObject[] parts;

    public ParticleSystem particles;

    public Vector3 direction;

    public float proximity = 1;

    [ColorUsage(hdr: true, showAlpha: true)]
    public Color active, inActive, mistake;

    public Material mActive;

    public Material mInactiveStatues;

    public Material mInactiveItem;

    public Animator animator;

    public AnimationClip clip;

    private void Update()
    {
        if (solved)
        {
            if (error)
            {
                item.GetComponentInChildren<MeshRenderer>().material.color = mistake;
                particles.startColor = mistake;

                for (int i = 0; i < parts.Length; i++)
                {
                    parts[i].GetComponent<MeshRenderer>().material.color = mistake;
                }
            }
            else
            {
                item.transform.position = Vector3.MoveTowards(item.transform.position, dock.position, 5 * Time.deltaTime);

                item.transform.rotation = dock.rotation;

                item.GetComponentInChildren<MeshRenderer>().material.color = active;
                particles.startColor = active;

                for (int i = 0; i < parts.Length; i++)
                {
                    parts[i].GetComponent<MeshRenderer>().material.color = active;
                }
            }
        }
        else if (!solved)
        {
            if (error)
            {
                item.GetComponentInChildren<MeshRenderer>().material.color = mistake;
                particles.startColor = mistake;

                for (int i = 0; i < parts.Length; i++)
                {
                    parts[i].GetComponent<MeshRenderer>().material.color = mistake;
                }
            }
            else
            {
                item.GetComponentInChildren<MeshRenderer>().material.color = inActive;
                particles.startColor = inActive;

                for (int i = 0; i < parts.Length; i++)
                {
                    parts[i].GetComponent<MeshRenderer>().material.color = inActive;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (puzzle.solved == false)
        {
            if (other.gameObject.layer == 20)
            {
                pull.GetComponent<Rigidbody>().useGravity = false;
                puzzle.CheckStatues(index);
                solved = true;
                particles.Play();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!puzzle.solved)
        {
            if (other.gameObject.layer == 20)
            {
                pull.GetComponent<Rigidbody>().useGravity = true;
            }
        }
    }
}
