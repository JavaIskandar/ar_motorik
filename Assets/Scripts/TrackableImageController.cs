using System.Collections;
using UnityEngine;
using Vuforia;

public class TrackableImageController : MonoBehaviour
{
    private GameObjectManager objectManager;
    private ObserverBehaviour observerBehaviour;

    private void Awake()
    {
        observerBehaviour = GetComponent<ObserverBehaviour>();

        if (observerBehaviour)
        {
            observerBehaviour.OnTargetStatusChanged += OnTargetStatusChanged;
        }
    }

    private void OnDestroy()
    {
        if (observerBehaviour)
        {
            observerBehaviour.OnTargetStatusChanged -= OnTargetStatusChanged;
        }
    }

    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        if (status.Status == Status.TRACKED || status.Status == Status.EXTENDED_TRACKED)
        {
            OnTrackingFound();
        }
        else
        {
            OnTrackingLost();
        }
    }

    public void OnTrackingFound()
    {
        // Note: VuforiaARController.Instance.SetWorldCenter is deprecated; world center is set via VuforiaConfiguration or Scene
        if (objectManager == null)
        {
            objectManager = new GameObjectManager();
        }

        if (transform.childCount > 0)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }

        Debug.Log("Tracking found");

        GameManager.GetInstance().MainBackButton.ObjectManager = objectManager;
    }

    public void OnTrackingLost()
    {
        if (transform.childCount > 0)
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
