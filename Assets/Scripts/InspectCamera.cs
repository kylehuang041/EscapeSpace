using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public float deltaRotationX;
    public float deltaRotationY;

    private Transform _inspectObjectTransform;

    public int rotateSpeed;
    void Start()
    {
        _inspectObjectTransform = InspectObject.inspectObject?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        deltaRotationX = -Input.GetAxis("Mouse X");
        deltaRotationY = Input.GetAxis("Mouse Y");

        if (Input.GetMouseButton(1) && _inspectObjectTransform)
        {
            _inspectObjectTransform.rotation =
                Quaternion.AngleAxis(deltaRotationX * rotateSpeed, transform.up) *
                Quaternion.AngleAxis(deltaRotationY * rotateSpeed, transform.right) *
                _inspectObjectTransform.rotation;
        }
    }
}
