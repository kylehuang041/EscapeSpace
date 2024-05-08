using UnityEngine;
using UnityEngine.UI;

public class StealthMeter : MonoBehaviour
{
    public RectTransform stealthBarFill; // Reference to the fill part of the stealth bar
    public float stealthLevel = 100; // Initial and reset stealth level
    private float walkDecayRate = 20.0f; // Decay rate when walking
    private float recoveryRate = 40.0f; // Recovery rate when crouching
    private bool isMoving = false;

    void Update()
    {
        CheckMovement();
        UpdateStealthLevel();
        UpdateStealthDisplay();
    }

    void CheckMovement()
    {
        isMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);
    }

    void UpdateStealthLevel()
    {
        if (isMoving)
        {
            if (Input.GetKey(KeyCode.LeftControl)) // Crouch-walking
            {
                stealthLevel -= walkDecayRate * Time.deltaTime;
                stealthLevel = Mathf.Max(stealthLevel, 75); // Cap at 75
            }
            else // Walking
            {
                stealthLevel -= walkDecayRate * Time.deltaTime;
                stealthLevel = Mathf.Max(stealthLevel, 50); // Cap at 50
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftControl)) // Crouching
            {
                stealthLevel = stealthLevel += recoveryRate * Time.deltaTime;
                stealthLevel = Mathf.Min(stealthLevel, 100);
            }
            else // Standing still
            {
                stealthLevel = stealthLevel += recoveryRate * Time.deltaTime;
                stealthLevel = Mathf.Min(stealthLevel, 90);
            }
        }
    }

    void UpdateStealthDisplay()
    {
        stealthBarFill.sizeDelta = new Vector2(stealthLevel * 2, stealthBarFill.sizeDelta.y); // Adjust width
    }
}
