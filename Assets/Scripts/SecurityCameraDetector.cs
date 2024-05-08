using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCameraDetector : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            UnityEngine.Debug.Log("Security Camera has detected a player!");
        }
    }
}