using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Status Effect")]

public class EspadaElements : ScriptableObject
{
    public GameObject particles;
    public float extraDamage;
    public float speedChange;
    public float extraKnock;
    public float extraRange;
}
