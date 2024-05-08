using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GoldGrab : MonoBehaviour
{
    // Start is called before the first frame update
    private Outline _outline;
    private Vector3 _rotation;
    public float speed;
    void Start()
    {
        _rotation = new Vector3(0, 0, 1);
        _outline = gameObject.AddComponent<Outline>();

        _outline.OutlineMode = Outline.Mode.OutlineAll;
        _outline.OutlineColor = new Color(191, 140, 0);
        _outline.OutlineWidth = 10f;
        _outline.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(_rotation * Time.deltaTime * speed);
    }

    private void OnMouseEnter()
    {
        _outline.enabled = true;
        GameController.setTooltip("[E]", "Pick up");
        GameController.showTooltip();
    }

    private void OnMouseExit()
    {
        _outline.enabled = false;
        GameController.hideTooltip();
    }
}
