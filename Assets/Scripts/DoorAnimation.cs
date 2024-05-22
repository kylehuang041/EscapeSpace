using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator doorAnimator;

    private bool isDoorOpen = false;
    [SerializeField]
    private float interactionDistance = 2f;

    private void Awake()
    {
        if (doorAnimator == null)
        {
            Debug.LogError("Animator not assigned!");
            return;
        }
    }

    private void Update()
    {
        ToggleDoor();
    }

    private void ToggleDoor()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * interactionDistance, Color.red);

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            if (hit.collider.gameObject.CompareTag("door"))
            {
                Debug.Log("Door detected.");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("E key pressed.");
                    isDoorOpen = !isDoorOpen;
                    doorAnimator.SetBool("doorUnlocked", isDoorOpen);
                }
            }
        }
    }
}