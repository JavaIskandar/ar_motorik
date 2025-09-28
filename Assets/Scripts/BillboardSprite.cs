using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardSprite : MonoBehaviour
{
    private Camera camera;
    private void Start()
    {
        camera = GameManager.GetInstance().MainCamera;
    }
    // Update is called once per frame
    void Update()
    {
        if(camera == null)
        {
            camera = GameManager.GetInstance().MainCamera;
        }
        else
        {
            Debuger.print(""+ camera.transform.rotation.y);
            transform.rotation = Quaternion.Euler(transform.rotation.x, camera.transform.rotation.y, transform.rotation.z);

            //Vector3 newDirection = Vector3.RotateTowards(transform.forward, camera.transform.position, 10, 0.0f);

            // Calculate a rotation a step closer to the target and applies rotation to this object
            //transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }
}
