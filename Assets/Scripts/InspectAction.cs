using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.SceneManagement;

// Brody Soedel
// Script that detects if object that inspect key is pressed on is inspectable or not
// and launches seperate script if that is the case

// TODO: Pause game while inspecting, and not allowing interaction with the worldspace
public class InspectAction : MonoBehaviour
{
    private Camera _camera;
    public Camera inspectCamera;



    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>(); 
    }

    // Update is called once per frame
    void Update()
    {
        // launches ray from mouseposition, which upon hitting detectable object launches inspect
        // camera
        if (Input.GetKeyDown(KeyCode.F))
        {
            RaycastHit RayHit;

            if (CameraToMouseRay(Input.mousePosition, out RayHit))
            {
                if (RayHit.transform.gameObject.tag == "Inspectable")
                {
                    // instantiate object under the scene with directional light
                    // draw camera over current camera
                    GameObject inspectObject = RayHit.transform.gameObject;
                    GameObject inspectClone = Instantiate(inspectObject, new Vector3(1000, 1000, 1000), 
                        Quaternion.identity);
                    Rigidbody physics = inspectClone.GetComponent<Rigidbody>();
                    if (physics != null)
                    {
                        Destroy(physics);
                    }
                    inspectClone.tag = "Untagged";
                    Vector3 size = inspectObject.GetComponent<Renderer>().bounds.size;
                    float cameraDistance = Mathf.Max(size.x, size.y, size.z);
                    // centers object and moves camera far enough back that object doesn't clip through camera
                    Camera inspectCam = Instantiate(inspectCamera, new Vector3(1000, 1000 + size.y / 2, 
                        1000 - cameraDistance), Quaternion.identity);
                    InspectCamera script = inspectCam.GetComponent<InspectCamera>();
                    script.SetObject(inspectClone);
                }
            }
        }
    }

    // mousePosition: position of Mouse
    // RayHit: RaycastHit object which contains information about what it hits, 
    // passed in as reference
    // returns boolean that is true if raycast hits object
    private bool CameraToMouseRay(Vector2 mousePosition, out RaycastHit RayHit)
    {
        Ray Ray = _camera.ScreenPointToRay(mousePosition);

        return Physics.Raycast(Ray, out RayHit);
    }
}
