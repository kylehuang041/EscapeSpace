using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;
    public Transform orientation;
    float xRotation;
    float yRotation;
    float maxDistance;
    private float offsetDist;


    void Awake()
    {
        maxDistance = 2f;
        offsetDist = 0.15f;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);

        Vector3 offset = orientation.forward * offsetDist;
        transform.position = orientation.position + offset;

        // check for interaction with door
        if (Input.GetKeyDown(KeyCode.E))
        {
            InteractWithDoor();
        }
    }

    void InteractWithDoor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            GameObject door = hit.collider.gameObject;
            UnityEngine.Debug.Log(door.name);
            if (door.name.Contains("glass_panel_1_door"))
            {
                DoorAnimation doorAnimation = door.GetComponentInParent<DoorAnimation>();
                if (doorAnimation != null)
                {
                    doorAnimation.ToggleDoor();
                }
                else
                {
                    Debug.Log("DoorAnimation component not found on " + door.name);
                }
            } else if (door.name.Contains("glass_panel_1_with_door")) {
                DoorAnimation doorAnimation = door.GetComponent<DoorAnimation>();
                doorAnimation.ToggleDoor();
            }
        }
    }
}