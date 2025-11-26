using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class CompanionAnimations : MonoBehaviour
{
    public Animator animator;

    public MeshRenderer[] animationRenderers;
    public MeshRenderer[] gameplayRenderers;
    public TrailRenderer trail;
    public Light spotLightAnimation;
    public Light SpotLightGameplay;

    public void PlayAnimation(AnimationClip clip, bool value)
    {
        animator.SetBool(clip.name, value);
        SetMeshOnAndOff();
    }

    public void SetMeshOnAndOff()
    {
        for (int i = 0; i < animationRenderers.Length; i++)
        {
            animationRenderers[i].enabled = !animationRenderers[i].enabled;
        }

        trail.enabled = !trail.enabled;
        spotLightAnimation.enabled = !spotLightAnimation.enabled;
        SpotLightGameplay.enabled = !SpotLightGameplay.enabled;

        for (int i = 0;i < gameplayRenderers.Length;i++)
        {
            gameplayRenderers[i].enabled = !gameplayRenderers[i].enabled;
        }
    }
}
