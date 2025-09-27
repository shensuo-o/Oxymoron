using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Puzzle_Statues : MonoBehaviour, IDataPersistance
{
    [SerializeField] private string id;

    [ContextMenu("Generate id")]

    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    public bool solved;

    public bool[] status;

    public GameObject[] estatuas;

    public List<Rigidbody> doorBranches;

    public FallTrap[] traps;

    public float errorForce;


    public void LoadData(GameData data)
    {
        data.solvedPuzzles.TryGetValue(id, out solved);
    }

    public void SaveData(ref GameData data)
    {
        if (data.solvedPuzzles.ContainsKey(id))
        {
            data.solvedPuzzles.Remove(id);
        }
        data.solvedPuzzles.Add(id, solved);
    }

    private void Awake()
    {
        CheckPuzzle();

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

            for (int p = 0; p < traps.Length; p++)
            {
                traps[p].ResetTrap();
            }
        }
        else if (solved)
        {
            for (int i = 0; i < estatuas.Length - 1; i++)
            {
                estatuas[i].gameObject.GetComponent<Statue>().solved = true;
            }
        }
    }

    public void CheckStatues(int index)
    {
        StartCoroutine(ChangeMaterial(index));
        StartCoroutine(SetBools(index));
    }

    public IEnumerator SetBools(int index)
    {
        yield return new WaitForSeconds(1);

        for (int i = 0; i <= index; i++)
        {
            if (status[i] == false)
            {
                estatuas[index].gameObject.GetComponent<Statue>().error = true;
                estatuas[index].gameObject.GetComponent<Statue>().solved = false;
                yield return new WaitForSeconds(3.2f);
                estatuas[index].gameObject.GetComponent<Statue>().error = false;

                for (int j = 0; j <= index; j++)
                {
                    if (j != index)
                    {
                        estatuas[j].gameObject.GetComponent<Statue>().error = true;
                        estatuas[j].gameObject.GetComponent<Statue>().solved = false;
                        yield return new WaitForSeconds(3.2f);
                        estatuas[j].gameObject.GetComponent<Statue>().error = false;
                    }
                }

                for (int k = 0; k < estatuas.Length; k++)
                {
                    estatuas[k].GetComponent<BoxCollider>().enabled = true;
                }

                yield break;
            }
        }
    }

    public IEnumerator ChangeMaterial(int ind)
    {
        status[ind] = true;
        estatuas[ind].GetComponent<BoxCollider>().enabled = false;

        yield return new WaitForSeconds(1);

        for (int i = 0; i <= ind; i++)
        {
            if (status[i] == false)
            {
                for (int k = 0; k < estatuas.Length; k++)
                {
                    estatuas[k].GetComponent<BoxCollider>().enabled = false;
                }

                status[ind] = false;
                yield return new WaitForSeconds(0.2f);
                estatuas[ind].GetComponent<Statue>().item.layer = 20;
                estatuas[ind].GetComponent<Statue>().pull.GetComponent<Rigidbody>().useGravity = true;
                estatuas[ind].gameObject.GetComponent<Statue>().particles.Play();
                estatuas[ind].GetComponent<Statue>().item.GetComponent<Rigidbody>().AddForce(estatuas[ind].GetComponent<Statue>().direction * errorForce, ForceMode.Impulse);
                yield return new WaitForSeconds(3f);

                for (int j = 0; j <= ind; j++)
                {
                    if (j != ind)
                    {
                        status[j] = false;
                        yield return new WaitForSeconds(0.2f);
                        estatuas[j].GetComponent<Statue>().item.layer = 20;
                        estatuas[j].GetComponent<Statue>().pull.GetComponent<Rigidbody>().useGravity = true;
                        estatuas[j].gameObject.GetComponent<Statue>().particles.Play();
                        estatuas[j].GetComponent<Statue>().item.GetComponent<Rigidbody>().AddForce(estatuas[j].GetComponent<Statue>().direction * errorForce, ForceMode.Impulse);
                        yield return new WaitForSeconds(3f);
                    }
                }

                

                for (int p = 0; p < traps.Length; p++)
                {
                    traps[p].ResetTrap();
                }

                yield break;
            }
        }
        CheckPuzzle();
    }

    public void CheckPuzzle()
    {
        int t = 0;

        for (int i = 0; i < status.Length; i++)
        {
            if (status[i])
            {
                t++;
            }
        }

        if (t == 4)
        {
            solved = true;
            OpenTheDoor();
        }
    }

    public void OpenTheDoor()
    {
        for (int i = 0;i < doorBranches.Count;i++)
        {
            doorBranches[i].useGravity = true;
            doorBranches[i].constraints = RigidbodyConstraints.None;
            doorBranches[i].AddForce(Vector3.right * 2, ForceMode.Impulse);
        }
    }
}
