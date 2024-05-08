using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor;
using UnityEngine;

// Brody Soedel
// rudimentary pause menu function to pause behavior while inspect occurs
public class PauseMenu : MonoBehaviour
{
    public GameObject canvas;
    public delegate void PauseDelegate();
    public static PauseDelegate Pause;
    public static PauseDelegate UnPause;
    
    private static bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        Pause = PauseGame;
        UnPause = UnPauseGame;
    }

    // Update is called once per frame
    void Update()
    {
        canvas.SetActive(!isPaused);
    }

    public static bool IsPaused() { return isPaused; }

    private static void PauseGame()
    {
        Debug.Log("paused");
        isPaused = true;
    }

    private static void UnPauseGame()
    {
        Debug.Log("unpaused");
        isPaused = false;
    }
}
