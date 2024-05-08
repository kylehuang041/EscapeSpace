using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldGrab : MonoBehaviour
{
    // Start is called before the first frame update
    private Outline outline;
    void Start()
    {
        outline = gameObject.AddComponent<Outline>();

        outline.OutlineMode = Outline.Mode.OutlineAll;
        outline.OutlineColor = new Color(191, 140, 0);
        outline.OutlineWidth = 10f;
        outline.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        outline.enabled = true;
        GameController.setTooltip("[E]", "Pick up");
        GameController.showTooltip();
    }

    private void OnMouseExit()
    {
        outline.enabled = false;
        GameController.hideTooltip();
    }
}
