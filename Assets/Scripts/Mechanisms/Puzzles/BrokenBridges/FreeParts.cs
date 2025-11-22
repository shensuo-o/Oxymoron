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
            Debug.Log("touched an attack");
            if (other.GetComponent<Whirlwind>() != null)
            {
                Debug.Log("touched a tornado");
                piece.constraints = RigidbodyConstraints.None;
                //piece.constraints = RigidbodyConstraints.FreezeRotationX;
                for (int i = 0; i < rb.Length; i++)
                {
                    rb[i].constraints = RigidbodyConstraints.None;
                }
            }
        }
    }
}
