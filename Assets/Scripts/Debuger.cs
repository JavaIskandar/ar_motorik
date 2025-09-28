using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Debuger : MonoBehaviour
{
    public static Debuger instance;
    [SerializeField]
    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void Log(string msg)
    {
        text.text = msg;
    }
}
