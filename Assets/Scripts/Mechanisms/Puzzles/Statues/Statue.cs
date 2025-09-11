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

    private void Update()
    {
        if (solved)
        {
            item.transform.position = Vector3.MoveTowards(item.transform.position, dock.position, 12 * Time.deltaTime);
            item.transform.rotation = Quaternion.RotateTowards(item.transform.rotation, dock.rotation, 12 * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (puzzle.solved == false)
        {
            if (other.gameObject.layer == 20)
            {
                item = other.gameObject;
                puzzle.CheckStatues(index);
                solved = true;
            }
        }
    }
}
