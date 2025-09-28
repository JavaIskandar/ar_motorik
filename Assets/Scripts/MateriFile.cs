using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MateriFile
{
    private TextAsset file;
    private string title;
    private string content;

    public MateriFile(TextAsset file)
    {
        this.file = file;
        GenerateMateri();
    }

    public string Title { get => title; set => title = value; }
    public string Content { get => content; set => content = value; }

    private void GenerateMateri()
    {
        title = file.name;
        content = file.text;
    }
}
