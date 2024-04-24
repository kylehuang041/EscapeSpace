using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class InspectObject : MonoBehaviour
{
    public GameObject Camera;

    public delegate void OnInspect();
    public static OnInspect inspect;
    public delegate Transform PassedObject();
    public static PassedObject inspectObject;

    // Start is called before the first frame update
    void Start()
    {
        inspect = Inspection;
        inspectObject = PassObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Inspection()
    {
        Vector3 cameraPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z - 2);
        GameObject cam = Instantiate(Camera, cameraPosition, Quaternion.identity);
        cam.SetActive(true);
    }

    Transform PassObject() 
    {
        return gameObject.transform;
    }
}
