using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    public static LoadLevel Instance;
    [SerializeField] private Animator animator;
    public GameObject image;

    private void Awake()
    {
        Instance = this;
        animator = GetComponentInChildren<Animator>();
    }

    public void PlayStart()
    {
        animator.SetTrigger("Start");
    }

    public void HideImage()
    {
        image.SetActive(false);
    }

    public void ShowImage()
    {
        image.SetActive(true);
    }
}
