using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StealthMeter : MonoBehaviour
{
    public RectTransform stealthBarFill; // Reference to the fill part of the stealth bar
    public float stealthLevel = 100; // Initial and reset stealth level
    private float walkDecayRate = 20.0f; // Decay rate when walking
    private float recoveryRate = 40.0f; // Recovery rate when crouching
    private float detectRate = 50.0f; // Rate at which stealth decreases when detected
    private bool isMoving = false;
    private bool isGameOver = false;
    private bool isBeingDetected = false;
    private float regenDelay = 1.0f;
    private float regenTimer = 0.0f;
    private float crouchWalkTarget = 75f; // Target stealth level when crouching while walking
    private float crouchStandTarget = 100f; // Target stealth level when crouching while standing still
    private float standStillTarget = 90f; // Target stealth level when standing still

    void Update()
    {
        if (!isGameOver)
        {
            CheckMovement();
            UpdateStealthLevel();
            UpdateStealthDisplay();
        }
        else    {
            SceneManager.LoadScene("SpaceScene");
        }
    }

    void CheckMovement()
    {
        isMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);
    }

    public void DecreaseStealth(float deltaTime)
    {
        isBeingDetected = true;
        regenTimer = 0.0f; // Reset regen timer when being detected
        stealthLevel -= detectRate * deltaTime;
        if (stealthLevel <= 0)
        {
            stealthLevel = 0;
            isGameOver = true;
            UnityEngine.Debug.Log("Game Over due to stealth level reaching zero!");
            // Implement additional game over logic here if necessary
        }
    }

    public void StartRegenerating()
    {
        isBeingDetected = false;
    }

    void UpdateStealthLevel()
    {
        if (!isBeingDetected)
        {
            regenTimer += Time.deltaTime;
            if (regenTimer >= regenDelay)
            {
                if (isMoving)
                {
                    if (Input.GetKey(KeyCode.LeftControl)) // Crouch-walking
                    {
                        stealthLevel -= walkDecayRate * Time.deltaTime;
                        stealthLevel = Mathf.MoveTowards(stealthLevel, crouchWalkTarget, walkDecayRate * Time.deltaTime);
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
                        stealthLevel += recoveryRate * Time.deltaTime;
                        stealthLevel = Mathf.MoveTowards(stealthLevel, crouchStandTarget, recoveryRate * Time.deltaTime);
                    }
                    else // Standing still
                    {
                        stealthLevel += recoveryRate * Time.deltaTime;
                        stealthLevel = Mathf.MoveTowards(stealthLevel, standStillTarget, recoveryRate * Time.deltaTime);
                    }
                }
            }
        }
    }

    void UpdateStealthDisplay()
    {
        stealthBarFill.sizeDelta = new Vector2(stealthLevel * 2, stealthBarFill.sizeDelta.y); // Adjust width
    }
}
