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
    [SerializeField] private CapsuleCollider collision;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        collision = GameObject.Find("Sword").GetComponent<CapsuleCollider>();
        clicks = 0;
        canAttack = true;
        isAttacking = false;
        collision.enabled = false;
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
            collision.enabled = true;
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
            isAttacking = false;
            collision.enabled = false;
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack1") && clicks >= 2)
        {
            animator.SetInteger("AttackCombo", 2);
            collision.enabled = true;
            canAttack = true;
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack2") && clicks == 2)
        {
            animator.SetInteger("AttackCombo", 0);
            canAttack = true;
            clicks = 0;
            isAttacking = false;
            collision.enabled = false;
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack2") && clicks >= 3)
        {
            animator.SetInteger("AttackCombo", 3);
            collision.enabled = true;
            canAttack = true;
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack3"))
        {
            animator.SetInteger("AttackCombo", 0);
            canAttack = true;
            clicks = 0;
            isAttacking = false;
            collision.enabled = false;
        }
    }
}
