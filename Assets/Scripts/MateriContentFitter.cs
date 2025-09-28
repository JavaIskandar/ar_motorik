using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MateriContentFitter : MonoBehaviour
{
    float oldHeight = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float height = GetComponent<RectTransform>().rect.height;
        if (height != oldHeight)
        {
            GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -height / 2, 0);
            oldHeight = height;
        }
    }
}
