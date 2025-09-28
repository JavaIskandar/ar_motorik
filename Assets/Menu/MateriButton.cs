using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MateriButton : NavigationButton
{
    private FileInfo info;
    private Text title;
    private Text content;
    private MateriFile materiFile;
    
    public override void OnClick()
    {
        base.OnClick();
        title.text = materiFile.Title;
        content.text = materiFile.Content;
    }

    public void AddObjectToActive(GameObject item)
    {
        if (objectToActive == null)
        {
            objectToActive = new List<GameObject>();
        }
        objectToActive.Add(item);
    }
    public void AddObjectToDisable(GameObject item)
    {
        if (objectToDisable == null)
        {
            objectToDisable = new List<GameObject>();
        }
        objectToDisable.Add(item);
    }

    public Text Content { get => content; set => content = value; }
    public Text Title { get => title; set => title = value; }
    public MateriFile MateriFile { get => materiFile; set => materiFile = value; }
}
