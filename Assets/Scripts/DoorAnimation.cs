using System.Diagnostics;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
  private Animator doorAnimator;
  private bool isDoorOpen = false;

  private void Awake()
  {
    doorAnimator = GetComponent<Animator>();
    if (doorAnimator == null)
    {
      UnityEngine.Debug.LogError("Animator not assigned!");
      return;
    }
  }

  public void ToggleDoor()
  {
    isDoorOpen = !isDoorOpen;
    doorAnimator.SetBool("doorUnlocked", isDoorOpen);
  }
}
