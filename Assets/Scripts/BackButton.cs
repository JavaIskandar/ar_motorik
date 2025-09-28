using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    private GameObjectManager objectManager;

    public GameObjectManager ObjectManager { get => objectManager; set => objectManager = value; }

    public void OnClick()
    {
        if(objectManager != null)
        {
            objectManager.Pop();
        }

        this.gameObject.SetActive(false);
    }

    public void AddEnabledObjects(List<GameObject> objects)
    {
        objectManager.AddEnabledObjects(objects);
    }

    public void AddDisabledObjects(List<GameObject> objects)
    {
        objectManager.AddDisabledObjects(objects);
    }
}
