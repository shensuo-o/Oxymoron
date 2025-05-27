using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ManageAnimations : MonoBehaviour
{
    [SerializeField] private Personaje leif;
    [SerializeField] private MeleeCombat combat;
    [SerializeField] private float direction;

    void Awake()
    {
        leif = GetComponent<Personaje>();
        combat = GetComponent<MeleeCombat>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = leif.HorizontalInput;
        if (direction == 1 && combat.isAttacking == false)
        {
            transform.localScale = new Vector3(direction, transform.localScale.y, transform.localScale.z);
        }
        if (direction == -1 && combat.isAttacking == false)
        {
            transform.localScale = new Vector3(direction, transform.localScale.y, transform.localScale.z);
        }
    }
}
