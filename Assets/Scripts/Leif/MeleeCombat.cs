using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCombat : MonoBehaviour
{
    [SerializeField] private GameObject right;
    [SerializeField] private GameObject left;
    [SerializeField] private GameObject leif;
    [SerializeField] private float direction;
    [SerializeField] private bool look = true;

    private void Start()
    {
        leif = GameObject.Find("Leif");
    }
    void Update()
    {
        direction = leif.GetComponent<Personaje>().HorizontalInput;
        if (direction == 1 )
        {
            look = true;
        }

        if (direction == -1)
        {
            look = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            //StartCoroutine("Attack");
            Attack();
        }
    }

    private void Attack()
    {

    }

    /*IEnumerator Attack()
    {
        if (look)
        {
            right.SetActive(true);
            yield return new WaitForSeconds(0.4f);
            right.SetActive(false);
        }

        if (!look)
        {
            left.SetActive(true);
            yield return new WaitForSeconds(0.4f);
            left.SetActive(false);
        }
    }*/
}
