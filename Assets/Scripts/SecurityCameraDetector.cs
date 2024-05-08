using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCameraDetector : MonoBehaviour
{
    GameObject player;
    StealthMeter stealthMeter;

    void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
        stealthMeter = player.GetComponent<stealthMeter>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            stealthMeter.DecreaseStealth();
            UnityEngine.Debug.Log("Security Camera has detected a player!");
        }
    }
}