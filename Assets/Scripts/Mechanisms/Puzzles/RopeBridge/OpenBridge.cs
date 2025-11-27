using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBridge : MonoBehaviour
{
    public bool[] movedStones;
    public CameraFollow mainCam;

    public Transform wheel;
    public Transform bridge;

    public Animator animator;

    public AnimationClip clipError;
    public AnimationClip clipSucces;
    public AnimationClip clipOpen;

    public Material ropeMaterial;
    public LineRenderer ropeLineRenderer;
    public Transform ropeTarget;

    public Personaje leif;

    private void Awake()
    {
        mainCam = GameObject.Find("Main Camera").GetComponent<CameraFollow>();
    }

    void Start()
    {
        ropeMaterial.SetFloat("_Speed", 0f);
        for (int i = 0; i < movedStones.Length; i++)
        {
            movedStones[i] = false;
        }
    }

    private void Update()
    {
        ropeLineRenderer.SetPosition(0, ropeTarget.position);
    }

    public void StoneMoved(int stoneID)
    {
        movedStones[stoneID] = true;
        StartCoroutine(CheckBridge());
    }

    private IEnumerator CheckBridge()
    {
        int checks = 0;

        for(int i = 0;i < movedStones.Length; i++)
        {
            if (movedStones[i] == false)
            {
                leif.alive = false;
                yield return new WaitForSeconds(1.5f);
                mainCam.CallMoveAndShake(3, wheel.position);
                animator.SetTrigger(clipError.name);
                ropeMaterial.SetFloat("_Speed", -1f); ;
                yield return new WaitForSeconds(1.5f);
                ropeMaterial.SetFloat("_Speed", 1f);
                yield return new WaitForSeconds(1.5f);
                ropeMaterial.SetFloat("_Speed", 0f);
                yield return new WaitForSeconds(1f);
                leif.alive = true;
                yield break;
            }
            else
            {
                checks++;
                if (checks == 4)
                {
                    leif.alive = false;
                    yield return new WaitForSeconds(1.5f);
                    mainCam.CallMoveAndShake(4, wheel.position);
                    animator.SetTrigger(clipSucces.name);
                    ropeMaterial.SetFloat("_Speed", -3f);
                    yield return new WaitForSeconds(4);
                    StartCoroutine(Open());
                }
            }
        }
    }

    private IEnumerator Open()
    {
        mainCam.CallMoveAndShake(3, bridge.position);
        animator.SetTrigger(clipOpen.name);
        yield return new WaitForSeconds(2.5f);
        ropeMaterial.SetFloat("_Speed", 0f);
        yield return new WaitForSeconds(1f);
        leif.alive = true;
    }
}
