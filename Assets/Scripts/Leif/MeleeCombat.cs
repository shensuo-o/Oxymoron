using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCombat : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float attackRate;
    [SerializeField] private float nextAttackT;
    [SerializeField] private CapsuleCollider collision;
    [SerializeField] public bool isAttacking;

    private void Start()
    {
        collision.enabled = false;
        isAttacking = false;
    }
    void Update()
    {
        nextAttackT += Time.deltaTime;

        if (nextAttackT >= attackRate)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(Attack());
            }
        }
    }

    private IEnumerator Attack()
    {
        isAttacking = true;
        nextAttackT = 0;
        animator.SetTrigger("Attack");
        yield return new WaitForSeconds(0.08f);
        collision.enabled = true;
        yield return new WaitForSeconds(0.2f);
        collision.enabled = false;
        yield return new WaitForSeconds(0.1f);
        isAttacking = false;
    }
}
