using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Puzzle_Statues : MonoBehaviour
{
    public bool solved;

    public bool[] status;

    public GameObject[] estatuas;

    public Material active;
    public Material inActive;

    private void Awake()
    {
        if (solved)
        {

        }   
    }

    private void Start()
    {
        if (!solved)
        {
            for (int i = 0; i < estatuas.Length - 1; i++)
            {
                int rand = Random.Range(i, estatuas.Length - 1);
                var temp = estatuas[rand];

                estatuas[rand] = estatuas[i];
                estatuas[rand].GetComponent<Statue>().index = rand;

                estatuas[i] = temp;
                estatuas[i].GetComponent<Statue>().index = i;
            }
        }
    }

    private void Update()
    {
        if (!solved)
        {

        }   
    }

    public void CheckStatues(int index)
    {
        StartCoroutine(ChangeMaterial(index));
    }

    public IEnumerator ChangeMaterial(int ind)
    {
        status[ind] = true;
        estatuas[ind].GetComponentInChildren<MeshRenderer>().material = active;

        yield return new WaitForSeconds(1);

        for (int i = 0; i <= ind; i++)
        {
            if (status[i] == false)
            {
                for (int j = 0; j <= ind; j++)
                {
                    status[j] = false;
                    estatuas[j].GetComponentInChildren<MeshRenderer>().material = inActive;
                }
                status[ind] = false;
                estatuas[ind].GetComponentInChildren<MeshRenderer>().material = inActive;
                yield break;
            }
        }
    }
}
