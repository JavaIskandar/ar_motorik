using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private MateriFilesManager materiFiles;

    [SerializeField]
    private GameObject materiButton;
    [SerializeField]
    private GameObject materiScrollContent;
    [SerializeField]
    private GameObject materiListRegion;
    [SerializeField]
    private GameObject materiDetailsRegion;
    [SerializeField]
    private GameObject materiTitle;
    [SerializeField]
    private GameObject materiContent;

    const string MATERI_PATH = "Materi/";
    const string MATERI_FILENAME = "*.txt";

    // Start is called before the first frame update
    void Start()
    {
        materiFiles = new MateriFilesManager(MATERI_PATH, MATERI_FILENAME, this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject MakeMateriButton(TextAsset file)
    {
        GameObject component = Instantiate(materiButton, Vector3.zero, Quaternion.identity, materiScrollContent.transform);
        GameObject label = component.transform.Find("Label").gameObject;
        

        MateriButton button = component.GetComponent<MateriButton>();
        button.MateriFile = new MateriFile(file);
        button.Title = materiTitle.GetComponent<Text>();
        button.Content = materiContent.GetComponent<Text>();
        button.AddObjectToActive(materiDetailsRegion);
        button.AddObjectToDisable(materiListRegion);
        label.GetComponent<Text>().text = button.MateriFile.Title;

        return component;
    }
}
