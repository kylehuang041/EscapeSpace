using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.SceneManagement;

// Brody Soedel
// Script that detects if object that inspect key is pressed on is inspectable or not
// and launches seperate script if that is the case
public class InspectAction : MonoBehaviour
{
    public Camera inspectCamera;

    private Camera _camera;


    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.IsPaused()) return;
        // launches ray from mouseposition, which upon hitting detectable object launches inspect
        // camera
        RaycastHit RayHit;
        if (CameraToMouseRay(Input.mousePosition, out RayHit))
        {
            // checks for inspect script
            if (RayHit.transform.gameObject.GetComponent<Inspect>() != null)
            {
                GameObject inspectObject = RayHit.transform.gameObject;
                if (Input.GetKeyDown(KeyCode.F))
                {
                    // instantiate object under the scene with directional light
                    // draw camera over current camera
                    Vector3 size = inspectObject.GetComponent<Renderer>().bounds.size;
                    Outline outline = inspectObject.GetComponent<Outline>();
                    outline.enabled = false;
                    GameObject inspectClone = Instantiate(inspectObject, new Vector3(1000, 1000, 1000),
                        Quaternion.identity);
                    outline.enabled = true;
                    // insantiate rotation point at center of mesh, not object pivot
                    Vector3 center = inspectClone.GetComponent<Renderer>().bounds.center;
                    GameObject axes = new GameObject("pivot");
                    axes.transform.position = center;
                    inspectClone.transform.parent = axes.transform;
                    Rigidbody rb = inspectClone.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        Destroy(rb);
                    }
                    Destroy(inspectClone.GetComponent<Inspect>());
                    Outline cloneOutline = inspectClone.GetComponent<Outline>();
                    cloneOutline.enabled = false;
                    Destroy(inspectClone.GetComponent("OutlineMask"));
                    Destroy(inspectClone.GetComponent("OutlineFill"));
                    float maxDim = Mathf.Max(size.x, size.y, size.z);
                    // centers object and moves camera far enough back that object doesn't clip through camera
                    //.3f is the distance that the camera begins rendering from the camera object
                    center.z -= maxDim + .3f;
                    Camera inspectCam = Instantiate(inspectCamera, center, Quaternion.identity);
                    InspectCamera script = inspectCam.GetComponent<InspectCamera>();
                    script.SetObject(axes);
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
