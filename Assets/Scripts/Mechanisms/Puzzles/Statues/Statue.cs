using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statue : MonoBehaviour
{
    [SerializeField] private Puzzle_Statues puzzle;

    public int index;


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Choque con algo");
        if (puzzle.solved == false)
        {
            if (other.gameObject.layer == 11)
            {
                Debug.Log("Choque con luz oscura");
                puzzle.CheckStatues(index);
            }
        }
    }
}
