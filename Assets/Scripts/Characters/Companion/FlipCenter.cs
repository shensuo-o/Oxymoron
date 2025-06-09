using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCenter : MonoBehaviour
{
    [SerializeField] private GameObject Companion;
    [SerializeField] private Animator Center;
    [SerializeField] private int index;

    void Awake()
    {
        Companion = GameObject.Find("Companion");
        Center = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        index = Companion.GetComponent<CompanionInventory>().index;
        Center.SetInteger("Index", index);

        if (Companion.transform.rotation.y > 0)
        {
            Center.SetInteger("Index", index);
        }


        if (Companion.transform.rotation.y < 0)
        {
            if (index == 0)
            {
                Center.SetInteger("Index", 2);
                transform.localScale = new Vector3(transform.localScale.x, -0.01f, 0.01f);
            }
            if (index == 1)
            {
                Center.SetInteger("Index", 3);
                transform.localScale = new Vector3(transform.localScale.x, 0.01f, -0.01f);
            }
            if (index == 2)
            {
                Center.SetInteger("Index", 0);
                transform.localScale = new Vector3(transform.localScale.x, -0.01f, 0.01f);
            }
            if (index == 3)
            {
                Center.SetInteger("Index", 1);
                transform.localScale = new Vector3(transform.localScale.x, 0.01f, -0.01f);
            }
        }
    }
}
