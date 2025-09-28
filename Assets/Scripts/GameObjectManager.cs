using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectManager
{
    private Stack<List<GameObject>> enabledObjects;
    private Stack<List<GameObject>> disabledObjects;

    public Stack<List<GameObject>> EnabledObjects { get => enabledObjects; set => enabledObjects = value; }
    public Stack<List<GameObject>> DisabledObjects { get => disabledObjects; set => disabledObjects = value; }

    internal void Pop()
    {
        foreach (GameObject item in enabledObjects.Pop())
        {
            item.SetActive(true);
        }
        foreach (GameObject item in disabledObjects.Pop())
        {
            item.SetActive(false);
        }
    }

    internal void AddDisabledObjects(List<GameObject> objects)
    {
        if (disabledObjects == null)
        {
            disabledObjects = new Stack<List<GameObject>>();
        }

        disabledObjects.Push(objects);
    }

    internal void AddEnabledObjects(List<GameObject> objects)
    {
        if (enabledObjects == null)
        {
            enabledObjects = new Stack<List<GameObject>>();
        }

        enabledObjects.Push(objects);
    }
}
