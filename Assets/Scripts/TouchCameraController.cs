using UnityEngine;

public class TouchCameraController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float zoomSpeed;
    [SerializeField]
    private float rotationSpeed;

    private Vector2 lastTouchPos;
    private float lastTouchDistance;
    private float lastTouchAngle;

    [SerializeField]
    private GameObject prefab;

    void Update()
    {
        if (Input.touchCount == 1)
        {
            // Move
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 delta = touch.deltaPosition;
                Vector3 move = ((transform.forward * -delta.y) + (transform.right * -delta.x)) * moveSpeed * Time.deltaTime;
                
                // Move relative to world axes
                transform.Translate(move, Space.World);
            }
        }
        else if (Input.touchCount == 2)
        {
            Touch t0 = Input.GetTouch(0);
            Touch t1 = Input.GetTouch(1);

            Vector2 t0Prev = t0.position - t0.deltaPosition;
            Vector2 t1Prev = t1.position - t1.deltaPosition;

            // Zoom
            float prevDistance = (t0Prev - t1Prev).magnitude;
            float currentDistance = (t0.position - t1.position).magnitude;
            float distanceDelta = currentDistance - prevDistance;

            Camera.main.transform.Translate(Vector3.forward * distanceDelta * zoomSpeed * Time.deltaTime, Space.Self);

            // Rotate around global Y axis
            float prevAngle = Mathf.Atan2(t1Prev.y - t0Prev.y, t1Prev.x - t0Prev.x) * Mathf.Rad2Deg;
            float currentAngle = Mathf.Atan2(t1.position.y - t0.position.y, t1.position.x - t0.position.x) * Mathf.Rad2Deg;
            float angleDelta = currentAngle - prevAngle;

            transform.Rotate(Vector3.up, angleDelta * rotationSpeed, Space.World);
        }

        this.PlaceGameObject();
    }

    void PlaceGameObject()
    {
        Vector2 position = Vector2.zero;

        // Touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Ended && touch.deltaPosition.magnitude < 5f)
            {
                position = touch.position;
            }
            else
            {
                return; // Do not place if touch is moving
            }
        }
        // Mouse input (for editor testing)
        else if (Input.GetMouseButtonDown(0))
        {
            position = Input.mousePosition;
        }
        else
        {
            return; // No valid input
        }

        Ray ray = Camera.main.ScreenPointToRay(position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            GameObject newObject =  Instantiate(prefab);
            newObject.transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            newObject.transform.rotation = Quaternion.Euler(Vector3.up) * transform.rotation;
        }
    }
}
