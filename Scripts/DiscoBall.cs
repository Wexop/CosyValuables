using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CosyValuables.Scripts;

public class DiscoBall: MonoBehaviour
{
    private static readonly int Play = Animator.StringToHash("play");
    public AudioSource audioSource;
    public AudioClip clip;
    public Animator animator;
    
    private bool isPlaying = false;
    private bool isDestroy = false;

    public IEnumerator onPlayingSong()
    {
        yield return new WaitUntil(() => audioSource.isPlaying == false);
        audioSource.Stop();
        audioSource.clip = null;
        isPlaying = false;
    }

    public void OnImpact()
    {
        if(isDestroy) return;
        
        if (isPlaying)
        {
            audioSource.Stop();
            audioSource.clip = null;
            isPlaying = false;
            StartCoroutine(onPlayingSong());
        }
        else
        {
            audioSource.PlayOneShot(clip);
            isPlaying = true;
        }
        
        animator.SetBool(Play, isPlaying);
    }

    public void OnDestroy()
    {
        audioSource.Stop();
        audioSource.clip = null;
        isPlaying = false;
        isDestroy = true;
    }
}