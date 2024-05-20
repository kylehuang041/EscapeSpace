using System.Net.NetworkInformation;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{

  [SerializeField]
  public Animator doorAnimator;
  bool isDoorOpen;

  [SerializeField]
  public float interactionDistance;

  void Awake()
  {
    if (doorAnimator == null)
    {
      Debug.LogError("Animator not assigned!");
      return;
    }
  }

  void Start()
  {
    isDoorOpen = false; ;
  }

  void Update()
  {
    toggleDoor();
  }

  void toggleDoor()
  {
    Ray ray = new Ray(transform.position, transform.forward);
    RaycastHit hit;

    Debug.DrawRay(ray.origin, ray.direction * interactionDistance, Color.red);

    if (Physics.Raycast(ray, out hit, interactionDistance))
    {
      if (hit.collider.gameObject.tag == "door")
      {
        if (Input.GetKeyDown(KeyCode.F))
        {
          isDoorOpen = !isDoorOpen;
          doorAnimator.SetBool("doorUnlocked", isDoorOpen);
        }
      }
    }
  }
}