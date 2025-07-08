using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float HP;
    public float Speed;
    [SerializeField] private float tempSpeed;
    [SerializeField] private float slowDownDuration = 4;
    public Rigidbody RB;
    [SerializeField] private Transform node1;
    [SerializeField] private Transform node2;
    [SerializeField] private Transform currentNode;

    [SerializeField] private float Damage;
    [SerializeField] private Personaje Leif;
    [SerializeField] private bool IsChasing;
    [SerializeField] private LayerMask PlayerMask;
    [SerializeField] private LayerMask GroundMask;
    [SerializeField] private bool IsOnGround;
    [SerializeField] private ParticleSystem hitEffect;

    [SerializeField] private Animator animator;
    [SerializeField] private CapsuleCollider hitbox;
    [SerializeField] private Renderer render;
    [SerializeField] private Material material;
    [SerializeField] private Material dmgMaterial;

    private Vector3 rotation;

    void Start()
    {
        RB = GetComponent<Rigidbody>();
        Leif = GameObject.Find("Leif").GetComponent<Personaje>();
        currentNode = node1;
        tempSpeed = Speed;
    }

    private void Update()
    {
        Vector3 dir = transform.position - currentNode.position;
        rotation = Vector3.RotateTowards(transform.right, new Vector3(dir.x, 0, 0), 100, 0f);
        Vector3 target = transform.position - Leif.transform.position;

        animator.SetFloat("Speed", Speed);

        if (!IsChasing || !IsOnGround)
        {
            Movement();
        }

        if (Vector3.Distance(transform.position, currentNode.position) <= 0.5f && currentNode == node1 && !IsChasing)
        {
            currentNode = node2;
        }

        if (Vector3.Distance(transform.position, currentNode.position) <= 0.5f && currentNode == node2 && !IsChasing)
        {
            currentNode = node1;
        }

        if (IsChasing && IsOnGround)
        {
            Chase();
        }

        if (Physics.Raycast(transform.position, transform.TransformDirection(-Vector3.forward), 8, PlayerMask) || target.magnitude <= 6)
        {
            IsChasing = true;
        }
        else
        {
            IsChasing = false;
        }

        if (target.magnitude <= 4 && animator.GetBool("Attack") == false)
        {
            StartCoroutine(AttackMeele());
        }

        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), 3, GroundMask))
        {
            IsOnGround = true;
        }
        else
        {
            IsOnGround = false;
        }
    }

    private IEnumerator AttackMeele()
    {
        animator.SetBool("Attack", true);
        yield return new WaitForSeconds(2);
        animator.SetBool("Attack", false);
    }

    private void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentNode.position, Speed * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(rotation);
    }

    private void Chase()
    {
        Vector3 dir = transform.position - Leif.transform.position;
        var rot = Vector3.RotateTowards(transform.right, new Vector3(dir.x, 0, 0), 100, 0f);
        transform.position = Vector3.MoveTowards(transform.position, Leif.transform.position, Speed * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(rot);
    }

    private void KnockBack(Transform player, float force)
    {
        Vector3 dir = new Vector3(transform.position.x - player.transform.position.x, 0, 0).normalized;
        RB.velocity = dir * force;
    }

    private IEnumerator ResetGuy()
    {
        yield return new WaitForSeconds(slowDownDuration);
        Speed = tempSpeed;
        render.material = material;
    }

    private IEnumerator Death()
    {
        animator.SetBool("Death", true);
        hitbox.enabled = false;
        Speed = 0;
        RB.velocity = Vector3.zero;
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == 7)
        {
            Leif.TakeDamage(Damage, (Leif.transform.position - transform.position).normalized);
        }

        if (collision.gameObject.layer == 21)
        {
            render.material = dmgMaterial;
            animator.SetTrigger("Hit");
            hitEffect.Play();
            HP -= Leif.Damage;
            Speed -= Leif.slowSpeed;
            StartCoroutine("ResetGuy");
            KnockBack(Leif.transform, Leif.knockBackForce);
            if (HP <= 0)
            {
                StartCoroutine(Death());
            }
        }
    }

    private void OnTriggerStay(Collider collision)
    { 
        if(collision.gameObject.layer == 11)
        {
            HP -= collision.gameObject.GetComponentInParent<StatsOximorones>().dmg * Time.deltaTime;
            if (HP <= 0)
            {
                StartCoroutine(Death());
            }
        }
    }
}
