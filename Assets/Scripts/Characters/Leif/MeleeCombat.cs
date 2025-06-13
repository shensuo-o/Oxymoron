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
    [SerializeField] private Personaje leif;
    [SerializeField] private Element[] equipedEffects;
    [SerializeField] private OximoronSlot[] Slots;
    [SerializeField] private CapsuleCollider sword;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        collision = GameObject.Find("Sword").GetComponent<CapsuleCollider>();
        leif = gameObject.GetComponent<Personaje>();
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

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack_1") && clicks == 1)
        {
            animator.SetInteger("AttackCombo", 0);
            canAttack = true;
            clicks = 0;
            isAttacking = false;
            collision.enabled = false;
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack_1") && clicks >= 2)
        {
            animator.SetInteger("AttackCombo", 2);
            collision.enabled = true;
            canAttack = true;
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack_2") && clicks == 2)
        {
            animator.SetInteger("AttackCombo", 0);
            canAttack = true;
            clicks = 0;
            isAttacking = false;
            collision.enabled = false;
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack_2") && clicks >= 3)
        {
            animator.SetInteger("AttackCombo", 3);
            collision.enabled = true;
            canAttack = true;
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack_3"))
        {
            animator.SetInteger("AttackCombo", 0);
            canAttack = true;
            clicks = 0;
            isAttacking = false;
            collision.enabled = false;
        }
    }

    public void CheckStatus(int index)
    {
        for (int i = 0; i < 2; i++)
        {
            if (Slots[index].elements[i] != null)
            {
                for (int j = 0; j < equipedEffects.Length; j++)
                {
                    equipedEffects[j] = Slots[index].elements[i];
                }
            }
        }
        ApplyEffects();
    }

    private void ApplyEffects()
    {
        for (int i = 0; i < equipedEffects.Length; i++)
        {
            if (equipedEffects[i] != null)
            {
                leif.Damage += equipedEffects[i].swordEffect.extraDamage;
                leif.knockBack.directionForce += equipedEffects[i].swordEffect.extraKnock;
                leif.slowSpeed = equipedEffects[i].swordEffect.speedChange;
                sword.height = equipedEffects[i].swordEffect.extraRange;
            }
        }
    }
}
