using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCombat : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private int clicks;
    [SerializeField] private bool canAttack;
    public bool isAttacking;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        clicks = 0;
        canAttack = true;
        isAttacking = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            IniciarCombo();
        }
    }

    private void IniciarCombo()
    {
        if (canAttack)
        {
            clicks++;
            isAttacking = true;
        }

        if (clicks == 1)
        {
            animator.SetInteger("AttackCombo", 1);
        }
    }

    private void CheckCombo()
    {
        canAttack = false;

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack1") && clicks == 1)
        {
            animator.SetInteger("AttackCombo", 0);
            canAttack = true;
            clicks = 0;
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack1") && clicks >= 2)
        {
            animator.SetInteger("AttackCombo", 2);
            canAttack= true;
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack2") && clicks == 2)
        {
            animator.SetInteger("AttackCombo", 0);
            canAttack = true;
            clicks = 0;
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack2") && clicks >= 3)
        {
            animator.SetInteger("AttackCombo", 3);
            canAttack = true;
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack3"))
        {
            animator.SetInteger("AttackCombo", 0);
            canAttack = true;
            clicks = 0;
        }
    }
    /*[SerializeField] private float attackRate;
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
        animator.SetTrigger("Attack1");
        yield return new WaitForSeconds(0.08f);
        collision.enabled = true;
        yield return new WaitForSeconds(0.2f);
        collision.enabled = false;
        yield return new WaitForSeconds(0.1f);
        isAttacking = false;
    }*/
}
