using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeMenu : MonoBehaviour
{
    [SerializeField]
    private float smoothTime;
    [SerializeField]
    private float releasedTime;
    [SerializeField]
    private ScrollRect scrollView;
    private float childWidth;
    private float position;
    private float targetPoint;
    private float offset;
    private float currentTime;
    private Vector2 velocity;
    void Start()
    {
        Transform child = transform.GetChild(0);
        childWidth      = child.GetComponent<RectTransform>().sizeDelta.x;
        offset          = ((transform.childCount +1) % 2) / 2.0f;
        velocity        = Vector2.zero;
        currentTime     = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 anchoredPosition    = GetComponent<RectTransform>().anchoredPosition;
        position                    = anchoredPosition.x;
        targetPoint                 = (Mathf.Round((position / childWidth) + offset) - offset) * childWidth;

        if (Input.GetMouseButton(0))
        {
            currentTime = 0;
            scrollView.inertia = true;
        }
        else if (currentTime < releasedTime)
        {
            currentTime += Time.deltaTime;
        }
        else if(currentTime >= releasedTime)
        {
            scrollView.inertia = false;
            GetComponent<RectTransform>().anchoredPosition = Vector2.SmoothDamp(anchoredPosition, new Vector2(targetPoint, anchoredPosition.y), ref velocity, smoothTime);
        }
    }
}
