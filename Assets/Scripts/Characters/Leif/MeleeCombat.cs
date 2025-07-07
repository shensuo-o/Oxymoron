using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.VFX;

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
    [SerializeField] private GameObject[] particles;
    [SerializeField] private Dictionary<String, GameObject> swordParticles = new Dictionary<string, GameObject>();
    [SerializeField] private VisualEffect slashEffect;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        collision = GameObject.Find("Sword").GetComponent<CapsuleCollider>();
        leif = gameObject.GetComponent<Personaje>();
        clicks = 0;
        canAttack = true;
        isAttacking = false;
        collision.enabled = false;

        for (int i = 0; i < particles.Length; i++)
        {
            swordParticles.Add(particles[i].name, particles[i]);
        }
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
            slashEffect.Play(); 
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
            slashEffect.Play();
            clicks = 0;
            isAttacking = false;
            collision.enabled = false;
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack_1") && clicks >= 2)
        {
            animator.SetInteger("AttackCombo", 2);
            collision.enabled = true;
            slashEffect.Play();
            canAttack = true;
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack_2") && clicks == 2)
        {
            animator.SetInteger("AttackCombo", 0);
            canAttack = true;
            slashEffect.Play();
            clicks = 0;
            isAttacking = false;
            collision.enabled = false;
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack_2") && clicks >= 3)
        {
            animator.SetInteger("AttackCombo", 3);
            collision.enabled = true;
            slashEffect.Play();
            canAttack = true;
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack_3"))
        {
            animator.SetInteger("AttackCombo", 0);
            canAttack = true;
            slashEffect.Play();
            clicks = 0;
            isAttacking = false;
            collision.enabled = false;
        }
    }

    public void CheckStatus(int index)
    {
        ResetEffects();
        for (int i = 0; i < 2; i++)
        {
            if (Slots[index].elements[i] != null)
            {
                equipedEffects[i] = Slots[index].elements[i];
            }
            else
            {
                equipedEffects[i] = null;
            }
        }
        ApplyEffects();
        ActivateParticles();
    }

    private void ApplyEffects()
    {
        for (int i = 0; i < equipedEffects.Length; i++)
        {
            if (equipedEffects[i] != null)
            {
                if (equipedEffects[i].swordEffect.extraDamage != 0)
                {
                    leif.Damage += equipedEffects[i].swordEffect.extraDamage;
                }
                if (equipedEffects[i].swordEffect.extraKnock != 0)
                {
                    leif.knockBackForce += equipedEffects[i].swordEffect.extraKnock;
                }
                if(equipedEffects[i].swordEffect.speedChange != 0)
                {
                    leif.slowSpeed = equipedEffects[i].swordEffect.speedChange;
                }
                if(equipedEffects[i].swordEffect.extraRange != 0)
                {
                    sword.height = equipedEffects[i].swordEffect.extraRange;
                    sword.center = new Vector3(0, 1.39f, 0);
                }
            }
        }
    }

    private void ActivateParticles()
    {
        for (int i = 0; i < equipedEffects.Length; i++)
        {
            if (equipedEffects[i] != null)
            {
                if(swordParticles.TryGetValue(equipedEffects[i].elementType, out GameObject particle))
                {
                    particle.SetActive(true);
                }
            }
        }
    }

    public void ResetEffects()
    {
        leif.Damage = 10;
        leif.knockBackForce = 8;
        leif.slowSpeed = 0;
        sword.height = 2;
        sword.center = new Vector3(0, 0.39f, 0);
        foreach (string k in swordParticles.Keys)
        {
            if (swordParticles.TryGetValue(k, out GameObject particle))
            {
                particle.SetActive(false);
            }
        }
    }
}
