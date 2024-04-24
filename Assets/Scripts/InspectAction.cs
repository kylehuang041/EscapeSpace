using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectAction : MonoBehaviour
{
    private Camera _camera; 




    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            RaycastHit RayHit;

            if (CameraToMouseRay(Input.mousePosition, out RayHit))
            {
                if (RayHit.transform.gameObject.tag == "Inspectable")
                {
                    InspectObject.inspect.Invoke();
                    
                }
            }
        }
    }

    private bool CameraToMouseRay(Vector2 mousePosition, out RaycastHit RayHit)
    {
        Ray Ray = _camera.ScreenPointToRay(mousePosition);

        return Physics.Raycast(Ray, out RayHit);
    }
}
