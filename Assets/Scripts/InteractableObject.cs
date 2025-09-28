using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [SerializeField]
    protected AudioClip clip;
    [SerializeField]
    protected AudioSource audioSource;

    public virtual void Interact()
    {
        if(clip != null && audioSource != null)
        {
            audioSource.clip = clip;
        }
    }

    public virtual void Uninteract()
    {

    }
}
