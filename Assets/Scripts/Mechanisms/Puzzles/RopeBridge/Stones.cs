using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stones : MonoBehaviour
{
    public OpenBridge bridge;
    public int ID;
    public Rigidbody[] stones;
    [SerializeField] private AnimationCurve curve;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 11)
        {
            if (other.gameObject.GetComponent<Whirlwind>())
            {
                bridge.StoneMoved(ID); 
                for (int i = 0; i < stones.Length; i++)
                {
                    stones[i].constraints = RigidbodyConstraints.None;
                }
            }
            if (other.gameObject.GetComponent<ShadowLight>())
            {
                for (int i = 0; i < 30; i++)
                {
                    i++;
                    i++;
                    stones[i].constraints = RigidbodyConstraints.None;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<ShadowLight>())
        {
            for (int i = 0; i < 10; i++)
            {
                stones[i].constraints = RigidbodyConstraints.FreezeAll;
            }
        }
    }
}
