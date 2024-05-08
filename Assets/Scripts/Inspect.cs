using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: make tooltip centered
public class Inspect : MonoBehaviour
{
    // Start is called before the first frame update
    private Outline outline;
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
    }

    private void OnMouseEnter()
    {
        GameController.setTooltip("[F]", "Inspect");
        GameController.showTooltip();
        outline.enabled = true;
    }

    private void OnMouseExit()
    {
        GameController.hideTooltip();
        outline.enabled = false;
    }
}
