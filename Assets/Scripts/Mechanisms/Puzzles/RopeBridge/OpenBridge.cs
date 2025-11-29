using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBridge : MonoBehaviour
{
    public bool[] movedStones;
    public CameraFollow mainCam;

    public Transform wheel;

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
                mainCam.CallMoveAndShake(1, wheel.position);
                return;
            }
            else
            {
                checks++;
                if (checks == 4)
                {
                    mainCam.CallMoveAndShake(3, wheel.position);
                }
            }
        }
    }
}
