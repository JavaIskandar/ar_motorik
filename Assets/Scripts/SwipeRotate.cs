using UnityEngine;

public class SwipeRotate : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 1;
    private bool isSwiping = false;
    private Vector2 lastTouchposition;

    void Update()
    {
        #if UNITY_EDITOR || UNITY_STANDALONE
                HandleMouseInput();
        #else
                HandleTouchInput();
        #endif
    }

    private void HandleMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isSwiping = true;
            lastTouchposition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0) && isSwiping)
        {
            RotateObject(Input.mousePosition.x - lastTouchposition.x);
            lastTouchposition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isSwiping = false;
        }
    }

    private void HandleTouchInput()
    {
        if(Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                isSwiping = true;
                lastTouchposition = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved && isSwiping)
            {
                RotateObject(touch.position.x - lastTouchposition.x);
                lastTouchposition = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                isSwiping = false;
            }
        }
        
    }

    private void RotateObject(float deltaX)
    {
        transform.Rotate(0, -(deltaX * rotationSpeed), 0);
    }
}
