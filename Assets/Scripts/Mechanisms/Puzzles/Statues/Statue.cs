using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statue : MonoBehaviour
{
    [SerializeField] private Puzzle_Statues puzzle;

    public int index;


    private void OnTriggerEnter(Collider other)
    {
        if (puzzle.solved == false)
        {
            if (other.gameObject.layer == 11)
            {
                puzzle.CheckStatues(index);
            }
        }
    }
}
