using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeParts : MonoBehaviour
{
    public Rigidbody piece;
    public Rigidbody[] rb;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 11)
        {
            if (other.GetComponent<Whirlwind>() != null)
            {
                piece.constraints = RigidbodyConstraints.None;
                for (int i = 0; i < rb.Length; i++)
                {
                    rb[i].constraints = RigidbodyConstraints.None;
                }
            }
        }
    }
}
