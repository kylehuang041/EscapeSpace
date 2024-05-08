using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCameraDetector : MonoBehaviour
{
    GameObject player;
    StealthMeter stealthMeter;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        stealthMeter = player.GetComponent<StealthMeter>(); // Corrected capitalization
        if (stealthMeter == null)
        {
            Debug.LogError("StealthMeter component not found on the player.");
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            stealthMeter.DecreaseStealth();
            Debug.Log("Security Camera has detected a player!");
        }
    }
}