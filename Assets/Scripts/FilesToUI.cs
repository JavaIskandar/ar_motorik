using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public abstract class FilesToUI
{
    private UnityEngine.Object[] files;
    public FilesToUI(string path, string filename)
    {
        files = Resources.LoadAll(path, typeof(TextAsset));
        Debug.Log(path);
    }

    public List<GameObject> MakeComponents()
    {
        List<GameObject> components = new List<GameObject>();
        foreach(TextAsset file in files)
        {
            components.Add(MakeUI(file));
        }
        return components;
    }

    public abstract GameObject MakeUI(TextAsset file);
}
