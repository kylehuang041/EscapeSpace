using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class KeypadInspect : MonoBehaviour
{
    // Start is called before the first frame update
    private Outline outline;
    private float timer = 0;
    public GameObject keypad;
    void Start()
    {
        outline = gameObject.AddComponent<Outline>();

        outline.OutlineMode = Outline.Mode.OutlineAll;
        outline.OutlineColor = Color.blue;
        outline.OutlineWidth = 10f;
        outline.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < 30) {
            timer++;
        }
        if ((timer > 20) && Input.GetKeyDown(KeyCode.F)) {
            keypad.SetActive(false);
        }
    }

    private void OnMouseEnter()
    {
        GameController.setTooltip("[F]", "Enter Keycode");
        GameController.showTooltip();
        outline.enabled = true;
    }

    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
             // PauseMenu.Pause?.Invoke();
            keypad.SetActive(true);
            timer = 0;
        }
    }

    private void OnMouseExit()
    {
        GameController.hideTooltip();
        outline.enabled = false;
    }
}
