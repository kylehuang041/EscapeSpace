using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToCameraDetection : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        UnityEngine.Debug.Log("Trigger entered");
        if (collider.tag == "CameraCone")
        {
            UnityEngine.Debug.Log("Security Camera has detected a player!");
        }
    }
}