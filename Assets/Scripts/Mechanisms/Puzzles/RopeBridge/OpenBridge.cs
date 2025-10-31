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
        CheckBridge();
    }

    public void CheckBridge()
    {
        int checks = 0;

        for(int i = 0;i < movedStones.Length; i++)
        {
            if (movedStones[i] == false)
            {
                mainCam.CallMoveAndShake(3, wheel.position);
                animator.SetTrigger(clipError.name);
                return;
            }
            else
            {
                checks++;
                if (checks == 4)
                {
                    mainCam.CallMoveAndShake(5, wheel.position);
                    animator.SetTrigger(clipSucces.name);
                }
            }
        }
    }

    public void Open()
    {
        mainCam.CallMoveAndShake(2, bridge.position);
        animator.SetTrigger(clipOpen.name);
    }
}
