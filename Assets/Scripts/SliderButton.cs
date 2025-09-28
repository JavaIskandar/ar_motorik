using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SliderButton : MonoBehaviour
{
    [SerializeField]
    private SliderButton pairedButton;
    private Stack<GameObject> stackedObjects;
    private static GameObject currentObject;

    public static GameObject CurrentObject { get => currentObject; set => currentObject = value; }

    public void FillStack(Transform parent)
    {
        if (stackedObjects == null)
        {
            stackedObjects = new Stack<GameObject>();
        }

        stackedObjects.Clear();
        pairedButton.Clear();
        pairedButton.gameObject.SetActive(false);

        foreach (Transform child in parent)
        {
            stackedObjects.Push(child.gameObject);
        }

        SetFalseGameObjects();

        currentObject = stackedObjects.Pop();

        currentObject.SetActive(true);
        CheckEnabled();
    }

    public void SetFalseGameObjects()
    {
        foreach(GameObject item in stackedObjects)
        {
            item.SetActive(false);
        }
    }

    public void Clear()
    {
        if(stackedObjects == null)
        {
            stackedObjects = new Stack<GameObject>();
        }
        stackedObjects.Clear();
    }

    public void Onclick()
    {
        pairedButton.stackedObjects.Push(currentObject);
        currentObject.SetActive(false);

        currentObject = stackedObjects.Pop();

        currentObject.SetActive(true);
        CheckEnabled();
        pairedButton.CheckEnabled();
    }

    public void CheckEnabled()
    {
        if(stackedObjects.Count > 0 && !gameObject.activeSelf)
        {
            gameObject.SetActive(true);
        }
        else if(stackedObjects.Count < 1 && gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
    }
}
