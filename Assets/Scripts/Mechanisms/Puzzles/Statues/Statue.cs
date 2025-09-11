using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Statue : MonoBehaviour
{
    [SerializeField] private Puzzle_Statues puzzle;

    public int index;

    public bool solved = false;

    public Transform dock;

    public GameObject item;

    public GameObject pull;

    public GameObject[] parts;

    [ColorUsage(hdr: true, showAlpha: true)]
    public Color active;
    public Color inActive;

    private void Update()
    {
        if (solved)
        {
            pull.GetComponent<Rigidbody>().useGravity = false;

            item.transform.position = Vector3.MoveTowards(item.transform.position, dock.position, 4 * Time.deltaTime);
            item.transform.rotation = Quaternion.RotateTowards(item.transform.rotation, dock.rotation, 45 * Time.deltaTime);

            item.GetComponent<MeshRenderer>().material.color = active;

            for (int i = 0; i < parts.Length; i++)
            {
                parts[i].GetComponent<MeshRenderer>().material.color = active;
            }
        }
        else if (!solved)
        {
            item.GetComponent<MeshRenderer>().material.color = inActive;

            for (int i = 0; i < parts.Length; i++)
            {
                parts[i].GetComponent<MeshRenderer>().material.color = inActive;
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
                item = other.gameObject;
                puzzle.CheckStatues(index);
                solved = true;
                item.layer = 0;
            }
        }
    }

    /*private void OnTriggerExit(Collider other)
    {
        if (puzzle.solved == false)
        {
            if (other.gameObject.layer == 11)
            {
                if (solved)
                {
                    pull.GetComponent<Rigidbody>().useGravity = true;
                }
            }
        }
    }*/
}
