using UnityEngine;

public class SecurityCameraDetector : MonoBehaviour
{
    private GameObject player;
    private StealthMeter stealthMeter;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        stealthMeter = player.GetComponent<StealthMeter>();
        if (stealthMeter == null)
        {
            UnityEngine.Debug.LogError("StealthMeter component not found on the player.");
        }
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            stealthMeter.DecreaseStealth(Time.deltaTime);
            UnityEngine.Debug.Log("Security Camera is detecting the player!");
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            stealthMeter.StartRegenerating();
        }
    }
}
