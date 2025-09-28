using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectEnabler : InteractableObject
{
    [SerializeField]
    protected List<GameObject> enabledObjects;
    [SerializeField]
    protected List<GameObject> disabledObjects;
    [SerializeField]
    private GameObject backButton;

    private void Start()
    {
        audioSource = GameManager.GetInstance().MainAudioSource;
    }

    public override void Interact()
    {
        base.Interact();

        if (backButton != null)
        {
            backButton.SetActive(true);
        }
        
        foreach (GameObject item in enabledObjects)
        {
            item.SetActive(true);
        }

        if(disabledObjects != null)
        {
            foreach (GameObject item in disabledObjects)
            {
                item.SetActive(false);
            }
        }

        GameManager.GetInstance().MainBackButton.AddEnabledObjects(disabledObjects);
        GameManager.GetInstance().MainBackButton.AddDisabledObjects(enabledObjects);
    }

    public override void Uninteract()
    {
        base.Uninteract();
    }
}
