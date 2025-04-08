using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    public float HP;
    public float Speed;
    public float MaxJumpForce;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void TakeDamage(int damage)//Llama a este script cada vez que recibe daño de algo.
    {
        HP -= damage;
    }
}
