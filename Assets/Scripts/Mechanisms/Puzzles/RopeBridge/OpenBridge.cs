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

    private void Awake()
    {
        mainCam = GameObject.Find("Main Camera").GetComponent<CameraFollow>();
    }

    void Start()
    {
        for (int i = 0; i < movedStones.Length; i++)
        {
            movedStones[i] = false;
        }
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
                mainCam.CallMoveAndShake(3, wheel.position);
                animator.SetTrigger(clipError.name);
                yield break;
            }
            else
            {
                checks++;
                if (checks == 4)
                {
                    mainCam.CallMoveAndShake(4, wheel.position);
                    animator.SetTrigger(clipSucces.name);
                    yield return new WaitForSeconds(4);
                    Open();
                }
            }
        }
    }

    public void Open()
    {
        mainCam.CallMoveAndShake(3, bridge.position);
        animator.SetTrigger(clipOpen.name);
    }
}
