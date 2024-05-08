using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeypadScript : MonoBehaviour
{
    // Initialize
    public string password;
    public TMP_InputField passwordScreen;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject button5;
    public GameObject button6;
    public GameObject button7;
    public GameObject button8;
    public GameObject button9;
    public GameObject button0;
    public GameObject clearButton;
    public GameObject enterButton;
    public Animator doorAnimator;
    // Button OnClick Events
    public void Start()
    {
        doorAnimator.SetBool("character_nearby", false);
        doorAnimator.SetBool("doorUnlocked", false);
    }
    public void b1()
    {
        if(passwordScreen.text.Length < password.Length)
            passwordScreen.text += "1";
    }
    public void b2()
    {
        if (passwordScreen.text.Length < password.Length)
            passwordScreen.text += "2";
    }
    public void b3()
    {
        if (passwordScreen.text.Length < password.Length)
            passwordScreen.text += "3";
    }
    public void b4()
    {
        if (passwordScreen.text.Length < password.Length)
            passwordScreen.text += "4";
    }
    public void b5()
    {
        if (passwordScreen.text.Length < password.Length)
            passwordScreen.text += "5";
    }
    public void b6()
    {
        if (passwordScreen.text.Length < password.Length)
            passwordScreen.text += "6";
    }
    public void b7()
    {
        if (passwordScreen.text.Length < password.Length)
            passwordScreen.text += "7";
    }
    public void b8()
    {
        if (passwordScreen.text.Length < password.Length)
            passwordScreen.text += "8";
    }
    public void b9()
    {
        if (passwordScreen.text.Length < password.Length)
            passwordScreen.text += "9";
    }
    public void b0()
    {
        if (passwordScreen.text.Length < password.Length)
            passwordScreen.text += "0";
    }
    public void clearButtonEvent()
    {
        passwordScreen.text = "";
    }
    public void enterButtonEvent()
    {
        if(passwordScreen.text.Equals(password))
        {
            doorAnimator.SetBool("doorUnlocked", true);
        }
        else
        {
            Debug.Log("Failed");
        }
    }
}
