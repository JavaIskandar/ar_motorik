using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    [SerializeField]
    Vector3 target;
    float targetDegree;
    [SerializeField]
    float speed;
    [SerializeField]
    float sensorDistance;
    [SerializeField]
    float rotationSpeed;
    [SerializeField]
    float angle;
    [SerializeField]
    float targetAngle;

    private void Start()
    {
        target = Vector3.zero;
    }
    private void FixedUpdate()
    {
        bool hitted = false;
        int r = (Random.Range(0, 2) * 2) - 1;

        for (int i = 0; i <= 180; i += 30)
        {
            for(int x = r*-1; x * r <= 1; x += r * 2)
            {
                float degree        = (i * x);
                Vector3 direction   = new Vector3( Mathf.Sin(Mathf.Deg2Rad * degree), 0, Mathf.Cos(Mathf.Deg2Rad * degree));

                direction = transform.TransformDirection(direction);

                //direction = transform.right * Mathf.Sin(Mathf.Deg2Rad * degree);
                //direction += transform.forward * Mathf.Cos(Mathf.Deg2Rad * degree);

                if (Physics.Raycast(transform.position, direction, sensorDistance))
                {
                    Debug.DrawRay(transform.position, direction * sensorDistance, Color.red);
                    hitted = true;
                }
                else
                {
                    Debug.DrawRay(transform.position, direction * sensorDistance, Color.red);
                    
                    if (hitted)
                    {
                        target = direction;
                        targetAngle = degree + transform.eulerAngles.y;
                    }

                    return;
                }
            }
        }
    }

    private void Update()
    {
        //Vector3 newDirection = Vector3.RotateTowards(transform.forward, target, rotationSpeed * Time.deltaTime, 0.0f);
        //transform.rotation = Quaternion.LookRotation(newDirection);
        Debug.Log(transform.forward);
        //angle = Vector3.Angle(target, transform.forward);
        angle = Mathf.DeltaAngle(transform.eulerAngles.y, targetAngle);
        transform.Rotate(0, GetRotate(angle, rotationSpeed), 0);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private float GetRotate(float degree, float speed)
    {
        float rotation = 0;

        if(degree != 0)
        {
            rotation = speed * Time.deltaTime * (degree / Mathf.Abs(degree));

            if (Mathf.Abs(rotation) > Mathf.Abs(degree))
            {
                rotation = degree;
            }
        }

        return rotation;
    }
}
