using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Brody Soedel 
// Inspect Camera that controls rotation and views object that is beeing inspected
public class InspectCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public float deltaRotationX;
    public float deltaRotationY;

    private GameObject _inspectObj;
    private Transform _inspectObjTransform;
    public int rotateSpeed;
    void Start()
    {
        PauseMenu.Pause?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        // switches back to player view
        if (Input.GetKeyDown(KeyCode.F))
        {
            Destroy(_inspectObj);
            Destroy(gameObject);
            PauseMenu.UnPause?.Invoke();
        }

        deltaRotationX = -Input.GetAxis("Mouse X");
        deltaRotationY = Input.GetAxis("Mouse Y");

        // spins object based on axis of rotation and change in rotation along camera axes
        if (Input.GetMouseButton(1) && _inspectObjTransform)
        {
            _inspectObjTransform.rotation =
                Quaternion.AngleAxis(deltaRotationX * rotateSpeed, transform.up) *
                Quaternion.AngleAxis(deltaRotationY * rotateSpeed, transform.right) *
                _inspectObjTransform.rotation;
        }
    }

    // setter fucntion that accepts an object as a parameter which is the object that is going
    // to be inspected. This is passed from InspectAction script usually
    public bool SetObject(GameObject obj)
    {
        if (obj == null)
        {
            return false;
        }
        _inspectObj = obj;
        _inspectObjTransform = obj.transform;
        return true;
    }
}


