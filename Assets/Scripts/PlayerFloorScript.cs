using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFloorScript : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("DummyFloor")) {
            UnityEngine.Debug.Log("Player collided with dummy floor");
        }
    }
}
