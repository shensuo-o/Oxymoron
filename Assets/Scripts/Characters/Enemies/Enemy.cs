using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float HP;
    public float Speed;
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

    private Vector3 rotation;

    [SerializeField] private float knockBackForce;

    void Start()
    {
        RB = GetComponent<Rigidbody>();
        Leif = GameObject.Find("Leif").GetComponent<Personaje>();
        currentNode = node1;
    }

    private void Update()
    {
        Vector3 dir = transform.position - currentNode.position;
        rotation = Vector3.RotateTowards(transform.right, new Vector3(dir.x, 0, 0), 100, 0f);
        Vector3 target = transform.position - Leif.transform.position;

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

        if (Physics.Raycast(transform.position, transform.TransformDirection(-Vector3.forward), 6, PlayerMask) || target.magnitude <= 2)
        {
            IsChasing = true;
        }
        else
        {
            IsChasing = false;
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
        Vector3 dir = (transform.position - player.transform.position).normalized;
        RB.velocity = dir * force;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == 7)
        {
            Leif.TakeDamage(Damage);
        }

        if (collision.gameObject.layer == 21)
        {
            HP -= Leif.Damage;
            KnockBack(Leif.transform, knockBackForce);
            if (HP <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.layer == 7)
        {
            Leif.TakeDamage(Damage * Time.deltaTime);
        }
        
        if(collision.gameObject.layer == 11)
        {
            HP -= collision.gameObject.GetComponent<StatsOximorones>().dmg * Time.deltaTime;
        }
    }
}
