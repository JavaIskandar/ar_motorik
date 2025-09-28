using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoContent : MonoBehaviour
{
    [SerializeField]
    private VideoClip clip;
    // Start is called before the first frame update

    private void OnEnable()
    {
        GameManager.GetInstance().VideoPanel.gameObject.SetActive(true);
        GameManager.GetInstance().MainVideoPlayer.clip = clip;
        GameManager.GetInstance().MainVideoPlayer.Play();
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        Debuger.instance.Log("OnEnable");
    }

    private void OnDisable()
    {
        GameManager.GetInstance().VideoPanel.gameObject.SetActive(false);
        Screen.orientation = ScreenOrientation.Portrait;
        Debuger.instance.Log("OnDisable");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
