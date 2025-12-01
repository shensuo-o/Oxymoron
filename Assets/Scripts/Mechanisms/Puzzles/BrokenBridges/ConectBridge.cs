using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConectBridge : MonoBehaviour
{
    public Animator animator;
    public AnimationClip clip;
    public GameObject piece;
    public GameObject fixedPiece;

    void Start()
    {
        fixedPiece.SetActive(false);
        piece.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 20)
        {
            StartCoroutine(WaitForClip());
        }
    }

    private IEnumerator WaitForClip()
    {
        yield return new WaitForSeconds(0);
        fixedPiece.SetActive(true);
        piece.SetActive(false);
        yield break;
    }
}
