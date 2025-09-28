using UnityEngine;
using Vuforia;

public class VuforiaCameraFocus : MonoBehaviour
{
    //void OnEnable()
    //{
    //    VuforiaApplication.Instance.OnVuforiaStarted += OnVuforiaStarted;
    //}

    //void OnDisable()
    //{
    //    VuforiaApplication.Instance.OnVuforiaStarted -= OnVuforiaStarted;
    //}

    //private void OnVuforiaStarted()
    //{
    //    SetCameraFocus();
    //}

    //private void OnApplicationPause(bool pauseStatus)
    //{
    //    if (!pauseStatus)
    //    {
    //        // App resumed
    //        SetCameraFocus();
    //    }
    //}

    //private void SetCameraFocus()
    //{
    //    var cameraDevice = VuforiaBehaviour.Instance?.CameraDevice;

    //    if (cameraDevice != null && cameraDevice.SetFocusMode(FocusMode.FOCUS_MODE_CONTINUOUSAUTO))
    //    {
    //        Debug.Log("Autofocus set to CONTINUOUSAUTO.");
    //    }
    //    else
    //    {
    //        Debug.LogWarning("Failed to set autofocus mode.");
    //    }
    //}
}
