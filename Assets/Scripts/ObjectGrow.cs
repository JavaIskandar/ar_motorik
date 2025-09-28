using UnityEngine;

public class ObjectGrow : MonoBehaviour
{
    [SerializeField]
    private float maxGrowth = 1.5f;
    [SerializeField]
    private float growthSpeed = 1.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.localScale = new Vector3(1, 1, 1);
    }

    void OnEnable()
    {
        transform.localScale = new Vector3(1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.localScale.x < maxGrowth)
        {
            transform.localScale += new Vector3(Time.deltaTime * growthSpeed, Time.deltaTime * growthSpeed, Time.deltaTime * growthSpeed);
        }
        else
        {
            transform.localScale = new Vector3(maxGrowth, maxGrowth, maxGrowth);
        }
    }
}
