using UnityEngine;

public class CameraTurn : MonoBehaviour
{
    public Transform pivotPoint;
    public float rotationSpeed = 5f;
    private bool isLookingLeft = true;
    private float currentAngle = 0f;
    private const float maxAngle = 45f;
    private const float minAngle = -10f;

    void Start()
    {
        StartRotating();
    }

    void StartRotating()
    {
        RotateRight();
    }

    void Update()
    {
        // check if the camera has reached its limits
        if ((isLookingLeft && currentAngle <= minAngle) || (!isLookingLeft && currentAngle >= maxAngle))
        {
            // change direction
            isLookingLeft = !isLookingLeft;
        }

        // rotate camera
        if (isLookingLeft)
        {
            RotateLeft();
        }
        else
        {
            RotateRight();
        }
    }

    void RotateLeft()
    {
        transform.RotateAround(pivotPoint.position, Vector3.up, -rotationSpeed * Time.deltaTime);
        currentAngle -= rotationSpeed * Time.deltaTime;
    }

    void RotateRight()
    {
        transform.RotateAround(pivotPoint.position, Vector3.up, rotationSpeed * Time.deltaTime);
        currentAngle += rotationSpeed * Time.deltaTime;
    }
}
