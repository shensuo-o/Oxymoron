using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.ParticleSystem;
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

    public GameObject door;

    public FallTrap[] traps;


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

                for (int j = 0; j <= ind; j++)
                {
                    status[j] = false;
                    estatuas[j].gameObject.GetComponent<Statue>().error = true;
                    estatuas[j].gameObject.GetComponent<Statue>().solved = false;
                    yield return new WaitForSeconds(0.5f);
                    estatuas[j].GetComponent<Statue>().item.layer = 20;
                    estatuas[j].GetComponent<Statue>().pull.GetComponent<Rigidbody>().useGravity = true;
                    estatuas[j].gameObject.GetComponent<Statue>().particles.Play();
                    yield return new WaitForSeconds(3);
                    estatuas[j].gameObject.GetComponent<Statue>().error = false;
                }

                for (int k = 0; k < estatuas.Length; k++)
                {
                    estatuas[k].GetComponent<BoxCollider>().enabled = true;
                }

                estatuas[ind].GetComponent<Statue>().item.GetComponent<Rigidbody>().AddForce(Vector3.right * 10, ForceMode.Impulse);

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
        door.transform.position = new Vector3(door.transform.position.x, 22);
    }
}
