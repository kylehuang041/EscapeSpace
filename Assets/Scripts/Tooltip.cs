using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// TODO: make tooltip centered

public class Tooltip : MonoBehaviour
{
    public GameObject key;
    public GameObject instructions;
    // Start is called before the first frame update
    void Start()
    {
        GameController.tooltipKey = key.GetComponent<TextMeshProUGUI>();
        GameController.tooltipInstructions = instructions.GetComponent<TextMeshProUGUI>();
        GameController.tooltip = gameObject;
        GameController.hideTooltip();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
