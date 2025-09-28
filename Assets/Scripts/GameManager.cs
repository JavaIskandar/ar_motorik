using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Vuforia;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private VuforiaBehaviour mainVuforiaBehaviour;
    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
    private AudioSource mainAudioSource;
    [SerializeField]
    private BackButton mainBackButton;
    [SerializeField]
    private SliderButton forwardSliderButton;
    [SerializeField]
    private GameObject mainNavigationSlider;
    [SerializeField]
    private VideoPlayer mainVideoPlayer;
    [SerializeField]
    private GameObject videoPanel;

    private static GameManager instance;

    public VuforiaBehaviour MainVuforiaBehaviour { get => mainVuforiaBehaviour; set => mainVuforiaBehaviour = value; }
    public Camera MainCamera { get => mainCamera; set => mainCamera = value; }
    public AudioSource MainAudioSource { get => mainAudioSource; set => mainAudioSource = value; }
    public BackButton MainBackButton { get => mainBackButton; set => mainBackButton = value; }
    public SliderButton ForwardSliderButton { get => forwardSliderButton; set => forwardSliderButton = value; }
    public VideoPlayer MainVideoPlayer { get => mainVideoPlayer; set => mainVideoPlayer = value; }
    public GameObject VideoPanel { get => videoPanel; set => videoPanel = value; }
    public GameObject MainNavigationSlider { get => mainNavigationSlider; set => mainNavigationSlider = value; }

    private void Awake()
    {
        instance = this;
    }

    public static GameManager GetInstance()
    {
        return instance;
    }
}
