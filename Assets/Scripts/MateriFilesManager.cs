using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MateriFilesManager : FilesToUI
{
    UIManager manager;
    List<GameObject> components;

    public MateriFilesManager(string path, string filename, UIManager manager) : base(path, filename)
    {
        this.manager = manager;
        components = MakeComponents();
    }
    public override GameObject MakeUI(TextAsset file)
    {
        return manager.MakeMateriButton(file);
    }
}
